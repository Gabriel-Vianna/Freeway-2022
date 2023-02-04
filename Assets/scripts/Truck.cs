using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    [SerializeField]
    private float truckSpeed = 6f;

    [SerializeField]
    private bool isGoingToTravel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player") {
            Player player = other.GetComponent<Player>();
            player.finish();
        }else {
            Player2 player2 = other.GetComponent<Player2>();
            player2.finish();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isGoingToTravel) {
            transform.Translate(Vector3.left * truckSpeed * Time.deltaTime);

            if(transform.position.x < -17.0f) {
                Destroy(this.gameObject);
            }
        }else {
            transform.Translate(Vector3.right * truckSpeed * Time.deltaTime);

            if(transform.position.x > 17.0f) {
                Destroy(this.gameObject);
            }
        }
    }
}
