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
    private GameObject truckGoingToTravelGameObject;

    [SerializeField]
    private GameObject truckBackingFromTravelGameObject;

    [SerializeField]
    private GameObject MotorCycleGoingToTravelGameObject;

    [SerializeField]
    private GameObject MotorCycleBackingFromTravelGameObject;

    [SerializeField]
    private float vehicleSpeedRespawn = 1f;

    public void startCarSpawn()
    {
        StartCoroutine("goinToTravelVehicles"); 
        StartCoroutine("backingFromTravelVehicles"); 
    }

    public IEnumerator goinToTravelVehicles()
    {
        while (true) {
            var vehicleRandom = Random.Range(0, 3);
            var positionRandom = Random.Range(0, 3);
            float[] positions = {3.45f, 2.08f, 0.75f};
            GameObject[] vehicles = {carGoingToTravelGameObject, truckGoingToTravelGameObject, MotorCycleGoingToTravelGameObject};
            transform.position = new Vector3(15.8f, positions[positionRandom], 0);
            Instantiate(vehicles[vehicleRandom], transform.position, Quaternion.identity);

            yield return new WaitForSeconds(vehicleSpeedRespawn); 
        }
    }

    public IEnumerator backingFromTravelVehicles()
    {
        while (true) {
            var vehicleRandom = Random.Range(0, 3);
            var positionRandom = Random.Range(0, 3);
            float[] positions = {-3.45f, -2.08f, -0.75f};
            GameObject[] vehicles = {carBackingFromTravelGameObject, truckBackingFromTravelGameObject, MotorCycleBackingFromTravelGameObject};

            transform.position = new Vector3(-15.8f, positions[positionRandom], 0);
            Instantiate(vehicles[vehicleRandom], transform.position, Quaternion.identity);

            yield return new WaitForSeconds(vehicleSpeedRespawn);
        }
    }
}
