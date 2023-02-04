using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Player2 : Agent
{
    private float horizontalInput;
    private float verticalInput;
    [SerializeField]
    private SpawnManager _SpawnManager;
    public Transform Target;
    Rigidbody2D rBody;

    private float initialSpeed = 5.0f;

    private float screenLimitBotton = -5.15f;

    private float screenLimitLeft = -14.94f;

    private float screenLimitRight = 14.94f;

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

        transform.position = new Vector3(4,screenLimitBotton,0);
    }

    void Update()
    {
        moveUsingKeyborad();
    }

    //Allows the player to control the spaceship using the keyboard
    private void moveUsingKeyborad()
    {
        var speed = initialSpeed;
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

        if (transform.position.y < screenLimitBotton) {
            transform.position = new Vector3(transform.position.x, screenLimitBotton, 0);
        }

        if (transform.position.x > screenLimitRight) {
            transform.position = new Vector3(screenLimitRight, transform.position.y, 0);
        } else if (transform.position.x < screenLimitLeft) {
            transform.position = new Vector3(screenLimitLeft, transform.position.y, 0);
        }

        // Reached target
        if (transform.position.y > Target.position.y)
        {
            targetReached();
        }
    }

    private void targetReached()
    {
        _uiManager.updateScore();
        resetPosition();
    }

    private void resetPosition()
    {
        transform.position = new Vector3(4,screenLimitBotton,0);
    }

    public void finish() {
        lives -= 1;
        _uiManager.updateLives(lives);
        if(lives == 0) {
            lives = 3;
            _uiManager.updateLives(lives);
        }
        resetPosition();
    }
}
