using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    public GameObject player;
    public GameObject player2;
    public FreewayMap freewayMap;
    private UIManager _uiManager;
    
    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _uiManager.showCoverImage();
    }
    void Update()
    {
        if (gameOver) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                gameOver = false;
                _uiManager.hideCoverImage();
                freewayMap.startGame();
            }
        }
    }

    public void endGame()
    {
        _uiManager.showCoverImage();
    }
}
