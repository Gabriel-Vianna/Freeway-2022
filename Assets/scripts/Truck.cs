using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    [SerializeField]
    private float truckSpeed = 4.0f;

    [SerializeField]
    private bool isGoingToTravel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        player.finish();
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
