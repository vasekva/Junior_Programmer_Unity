using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Colliding");
        // Debug.Log(tag);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player");
            gameManager.AddLives(-3);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Food"))
        {
            Debug.Log("Animal");
            gameManager.AddScore(5);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
