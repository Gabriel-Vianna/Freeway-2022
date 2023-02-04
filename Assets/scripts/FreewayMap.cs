using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FreewayMap : MonoBehaviour
{
    [SerializeField]
    private SpawnManager _SpawnManager;
    public SpriteRenderer spriteRenderer;

    
    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        _SpawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _SpawnManager.startCarSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showCoverImage()
    {
        this.spriteRenderer.color = Color.black;
    }
}
