using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContrioller : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    private int playerSpeed = 15;
    private float xRange = 20.0f;
    public GameObject projectilePrefab;    
    public Transform projectileSpawnPoint;
    
    void Start()
    {
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0 && isValidOffsetX(horizontalInput))
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerSpeed);
        if (verticalInput != 0 && isValidOffsetZ(verticalInput))
            transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * playerSpeed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectilePrefab.transform.rotation);
        }
    }

    private bool isValidOffsetX(float offsetX)
    {
        if (transform.position.x + offsetX >= xRange 
          || transform.position.x + offsetX <= -xRange)
            return (false);
                // || transform.position.y + verticalInput <= -1 || transform.position.y + verticalInput >= 15)
        return (true);
    }
    private bool isValidOffsetZ(float offsetZ)
    {
        if (transform.position.z + offsetZ >= 15.5 
            || transform.position.z + offsetZ <= -1.5)
            return (false);
        // || transform.position.y + verticalInput <= -1 || transform.position.y + verticalInput >= 15)
        return (true);
    }
}
