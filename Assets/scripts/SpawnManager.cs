using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject carGoingToTravelGameObject;

    [SerializeField]
    private GameObject carBackingFromTravelGameObject;

    [SerializeField]
    private float carSpeedRespawn = 1.0f;

    [SerializeField]
    private GameObject truckGoingToTravelGameObject;

    [SerializeField]
    private GameObject truckBackingFromTravelGameObject;

    [SerializeField]
    private float truckSpeedRespawn = 2.0f;

    [SerializeField]
    private GameObject MotorCycleGoingToTravelGameObject;

    [SerializeField]
    private GameObject MotorCycleBackingFromTravelGameObject;

    [SerializeField]
    private float motorCycleSpeedRespawn = 3;

    // Start is called before the first frame update
    public void startCarSpawn()
    {
        StartCoroutine("getCars"); 
        StartCoroutine("getTrucks");
        StartCoroutine("getMotorCycles");
    }

    public IEnumerator getCars()
    {
        while (true) {
            transform.position = new Vector3(15.8f, 3.45f, 0);
            Instantiate(carGoingToTravelGameObject, transform.position, Quaternion.identity);

            transform.position = new Vector3(-15.8f, -3.45f, 0);
            Instantiate(carBackingFromTravelGameObject, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(carSpeedRespawn); 
        }
    }

    public IEnumerator getTrucks()
    {
        while (true) {
            transform.position = new Vector3(16.8f, 2.08f, 0);
            Instantiate(truckGoingToTravelGameObject, transform.position, Quaternion.identity);

            transform.position = new Vector3(-16.8f, -2.08f, 0);
            Instantiate(truckBackingFromTravelGameObject, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(truckSpeedRespawn);
        }
    }

    public IEnumerator getMotorCycles()
    {
        while (true) {
            transform.position = new Vector3(16.0f, 0.75f, 0);
            Instantiate(MotorCycleGoingToTravelGameObject, transform.position, Quaternion.identity);

            transform.position = new Vector3(-16.0f, -0.75f, 0);
            Instantiate(MotorCycleBackingFromTravelGameObject, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(motorCycleSpeedRespawn);
        }
    }
}
