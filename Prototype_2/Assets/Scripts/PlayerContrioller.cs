using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContrioller : MonoBehaviour
{
    private float horizontalInput;

    public int playerSpeed;
    private float xRange = 20.0f;
    public GameObject projectilePrefab;    
    
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        } else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
