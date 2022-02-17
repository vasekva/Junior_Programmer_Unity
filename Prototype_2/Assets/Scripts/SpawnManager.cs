using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 2, 1.5f);
    }

    void Update()
    {
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Quaternion rotation = animalPrefabs[animalIndex].transform.rotation;
        Vector3 spawnPoz;
        
        if (Random.Range(0, 2) == 0)
        {
            spawnPoz = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, 25);
        }
        else
        {
            if (Random.Range(0, 2) == 0) // left
            {
                spawnPoz = new Vector3(-30, 0, Random.Range(15, 5));
                rotation *= Quaternion.Euler(0, -90, 0);
            }
            else
            {
                spawnPoz = new Vector3(30, 0, Random.Range(15, 5));
                rotation *= Quaternion.Euler(0, 90, 0);
            }
        }
        Instantiate(animalPrefabs[animalIndex], spawnPoz, rotation);
    }
}
