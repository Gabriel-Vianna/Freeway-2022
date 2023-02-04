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

    private float screenLimitBotton = -5.15f;

    private float screenLimitLeft = -14.94f;

    private float screenLimitRight = 14.94f;

    private float movedDistance = -5.15f;

    public int lives = 3;

    private UIManager _uiManager;
    
    private GameManager _gameManager;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (_uiManager) {
            _uiManager.updateLives(lives);
        }
    }

    public override void OnEpisodeBegin()
    {
        transform.position = new Vector3(0, screenLimitBotton , 0);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Target and Agent positions
        sensor.AddObservation(Target.localPosition.x);
        sensor.AddObservation(this.transform.localPosition);

        sensor.AddObservation(movedDistance);

        // Agent velocity
        sensor.AddObservation(rBody.velocity.x);
        sensor.AddObservation(rBody.velocity.y);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actions.ContinuousActions[0];
        controlSignal.y = actions.ContinuousActions[1];
        
        transform.Translate(controlSignal * speed * Time.deltaTime);

        if(this.transform.position.y > movedDistance) {
            AddReward(0.05f);
        }else {
            AddReward(-0.05f);
        }
        movedDistance = this.transform.position.y;

        // Reached target
        if (transform.position.y > Target.position.y)
        {
            earnedReward();
        }

        if (transform.position.y < screenLimitBotton) {
            EndEpisode();
        }

        if (transform.position.x > screenLimitRight || transform.position.x < screenLimitLeft) {
            EndEpisode();
        }
    }

    public void finish() {
        lives -= 1;
        _uiManager.updateLives(lives);
        if(lives == 0) {
            lives = 3;
            _uiManager.updateLives(lives);
        }
        SetReward(-5.0f);
        EndEpisode();
    }

    public void earnedReward() {
        SetReward(5.0f);
        _uiManager.updateScore();
        EndEpisode();
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");
    }
}
