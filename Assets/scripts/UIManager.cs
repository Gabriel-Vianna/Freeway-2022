using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImageDisplay;
    public Text scoreText;
    public int score = 0;
    public GameObject coverImage;

    public void updateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
    }

    public void updateScore()
    {
        score += 10;
        scoreText.text = "Pontos: " + score;
    }

    public void showCoverImage()
    {
        coverImage.SetActive(true);
    }

    public void hideCoverImage()
    {
        coverImage.SetActive(false);
    }
}
