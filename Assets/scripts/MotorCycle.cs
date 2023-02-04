using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCycle : MonoBehaviour
{
    [SerializeField]
    private float motorCycleSpeed = 6.0f;

    [SerializeField]
    private bool isGoingToTravel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        player.finish();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGoingToTravel) {
            transform.Translate(Vector3.left * motorCycleSpeed * Time.deltaTime);

            if(transform.position.x < -17.0f) {
                Destroy(this.gameObject);
            }
        }else {
            transform.Translate(Vector3.right * motorCycleSpeed * Time.deltaTime);

            if(transform.position.x > 17.0f) {
                Destroy(this.gameObject);
            }
        }
    }
}
