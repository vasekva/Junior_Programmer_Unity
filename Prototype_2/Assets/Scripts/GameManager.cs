using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int lives = 3;
    
    public void AddLives(int value)
    {
        lives += value;

        if (lives <= 0)
        {
            lives = 0;
            Debug.Log(("GameOver!"));
            Debug.Log("Your score: " + score);
            Application.Quit();
        }
        Debug.Log("Lives: " + lives);
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score: " + score);
    }
}
