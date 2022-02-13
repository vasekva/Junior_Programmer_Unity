using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // private float speed = 20;
    // private float turnSpeed = 25;
    // private float horizontalInput;
    // private float verticalInput;
    private Move mover;
    
    private float horizontalInput;
    private float verticalInput;

    private bool  isBraking;

    // [SerializeField] private WheelCollider fl_wheelCollider;
    // [SerializeField] private WheelCollider fr_wheelCollider;
    // [SerializeField] private WheelCollider rl_wheelCollider;
    // [SerializeField] private WheelCollider rr_wheelCollider;
    //
    // [SerializeField] private Transform fl_wheelTransform;
    // [SerializeField] private Transform fr_wheelTransform;
    // [SerializeField] private Transform rl_wheelTransform;
    // [SerializeField] private Transform rr_wheelTransform;

    private int cameraId = 0;

    private void Awake()
    {
        mover = GetComponent<Move>();
    }
    
    void FixedUpdate()
    {
        // GetInput();
        // HandleMotor();
        // HandleSteering();
        // UpdateWheels();
    }

    // public void OnMove(InputAction.CallbackContext context)
    // {
    //     mover.SetMoveVector(context.ReadValue<Vector2>());
    // }
    //
    // private void GetInput()
    // {
    //     horizontalInput = Input.GetAxis("Horizontal");
    //     verticalInput = Input.GetAxis("Vertical");
    //     isBraking = Input.GetKey(KeyCode.Space);
    //
    //     if (Input.GetKeyUp(KeyCode.C))
    //     {
    //         Debug.Log("CAMERA");
    //         cameraId = cameraId == 0 ? 1 : 0;
    //         if (cameraId == 0)
    //             GetComponent<ToggleCamera>().ShowFirstPersonView();
    //         else
    //             GetComponent<ToggleCamera>().ShowOverheadView();
    //     }
    // }
}
