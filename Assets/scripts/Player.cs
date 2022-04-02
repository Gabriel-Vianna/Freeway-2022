using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Player : Agent
{
    private float speed = 5.0f;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField]
    private SpawnManager _SpawnManager;
    public Transform Target;
    Rigidbody2D rBody;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        // transform.position = new Vector3(0.22f, -4.15f , 0);
        _SpawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _SpawnManager.startCarSpawn();
    }

    // Update is called once per frame
    // void Update()
    // {
        // var positions = new List<float> { -4.5f, -3.45f, -2.10f, -0.75f, 0.75f, 2.10f, 3.45f, 4.5f };

        // if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
        //     if (position < 7) {
        //         position++;
        //     }
        //     transform.position = new Vector3(0.0f, positions[position] , 0);
        // }

        // if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
        //     if (position > 0) {
        //         position--;
        //     }
        //     float positionY = transform.position.y;
        //     transform.position = new Vector3(0.0f, positions[position] , 0);
        // }

        // horizontalInput = Input.GetAxis("Horizontal");
        // verticalInput = Input.GetAxis("Vertical");
        // transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        // transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
    // }

    public override void OnEpisodeBegin()
    {
        transform.position = new Vector3(0, -4.5f , 0);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Target and Agent positions
        sensor.AddObservation(Target.localPosition);
        sensor.AddObservation(this.transform.localPosition);

        // Agent velocity
        sensor.AddObservation(rBody.velocity.x);
        sensor.AddObservation(rBody.velocity.y);
    }

    public float forceMultiplier = 2;
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Actions, size = 2
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actionBuffers.ContinuousActions[0];
        controlSignal.y = actionBuffers.ContinuousActions[1];
        // rBody.AddForce(controlSignal * forceMultiplier);
        transform.Translate(controlSignal * speed * Time.deltaTime);
        // transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

        // Rewards
        float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);

        // Reached target
        if (transform.position.y > Target.position.y)
        {
            SetReward(1.0f);
            finish();
        }

        if (transform.position.y < -5.0f) {
            transform.position = new Vector3(transform.position.x, -5.0f, 0);
        }

        if (transform.position.x > 14.94f) {
            transform.position = new Vector3(14.94f, transform.position.y, 0);
        } else if (transform.position.x < -14.94f) {
            transform.position = new Vector3(-14.94f, transform.position.y, 0);
        }
    }

    public void finish() {
        EndEpisode();
    }

    public void earnedReward() {
        SetReward(1.0f);
        EndEpisode();
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");
    }
}
