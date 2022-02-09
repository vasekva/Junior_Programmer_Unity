using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 1.0f;
    private float verRotationSpeed = 100.0f;
    private float horRotationSpeed = 100.0f;
    private float verticalInput;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        
        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);
        transform.Rotate(Vector3.right, Time.deltaTime * verRotationSpeed * verticalInput);
        transform.Rotate(new Vector3(0, 0, -1), Time.deltaTime * horRotationSpeed * horizontalInput);

        // tilt the plane up/down based on up/down arrow keys
        // transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
    }
}
