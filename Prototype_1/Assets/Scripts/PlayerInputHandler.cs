using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public string inputId;
    public KeyCode switchKey;
    
    private Move mover;
    private int cameraId = 0;
    private float horizontalInput;
    private float verticalInput;
    private bool  isBraking;
    
    private void Awake()
    {
        mover = GetComponent<Move>();
    }

    void FixedUpdate()
    {
        GetInput();
        // HandleMotor();
        // HandleSteering();
        // UpdateWheels();
    }
    
    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputId);
        verticalInput = Input.GetAxis("Vertical" + inputId);
        isBraking = Input.GetKey(KeyCode.Space);

        mover.SetMoveVector(new Vector2(horizontalInput, verticalInput));
        
        if (Input.GetKeyUp(switchKey))
        {
            Debug.Log("CAMERA");
            cameraId = cameraId == 0 ? 1 : 0;
            if (cameraId == 0)
                GetComponent<ToggleCamera>().ShowFirstPersonView();
            else
                GetComponent<ToggleCamera>().ShowOverheadView();
        }
    }
    
    // public void OnMove(InputAction.CallbackContext context)
    // {
    //     mover.SetMoveVector(context.ReadValue<Vector2>());
    // }
    //
    // public void ChangeCamera()
    // {
    //     cameraId = cameraId == 0 ? 1 : 0;
    //     if (cameraId == 0)
    //         GetComponent<ToggleCamera>().ShowFirstPersonView();
    //     else
    //         GetComponent<ToggleCamera>().ShowOverheadView();
    // }
}
