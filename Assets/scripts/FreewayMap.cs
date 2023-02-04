using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FreewayMap : MonoBehaviour
{
    [SerializeField]
    private SpawnManager _SpawnManager;

    
    // Start is called before the first frame update
    void Start()
    {
        _SpawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    public void startGame()
    {
        _SpawnManager.startCarSpawn();
    }
}
