using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    
    // private float speed = 20;
    // private float turnSpeed = 25;
    // private float horizontalInput;
    // private float verticalInput;

    private float horizontalInput;
    private float verticalInput;
    private float currentSteeringAngle;
    private float currentBrakeForce;
    private bool  isBraking;

    [SerializeField] private float motorForce;
    [SerializeField] private float brakeForce;
    [SerializeField] private float maxSteeringAngle;
    
    [SerializeField] private WheelCollider fl_wheelCollider;
    [SerializeField] private WheelCollider fr_wheelCollider;
    [SerializeField] private WheelCollider rl_wheelCollider;
    [SerializeField] private WheelCollider rr_wheelCollider;

    [SerializeField] private Transform fl_wheelTransform;
    [SerializeField] private Transform fr_wheelTransform;
    [SerializeField] private Transform rl_wheelTransform;
    [SerializeField] private Transform rr_wheelTransform;

    private int cameraId = 0;
    
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBraking = Input.GetKey(KeyCode.Space);

        if (Input.GetKeyUp(KeyCode.C))
        {
            Debug.Log("CAMERA");
            cameraId = cameraId == 0 ? 1 : 0;
            if (cameraId == 0)
                GetComponent<ToggleCamera>().ShowFirstPersonView();
            else
                GetComponent<ToggleCamera>().ShowOverheadView();
        }
    }

    void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void HandleMotor()
    {
        fl_wheelCollider.motorTorque = verticalInput * motorForce;
        fr_wheelCollider.motorTorque = verticalInput * motorForce;
        if (isBraking && currentBrakeForce != 0)
            currentBrakeForce = 0f;
        else
            currentBrakeForce = brakeForce;
        if (isBraking)
        {
            ApplyBreaking();
        } 
    }

    private void ApplyBreaking()
    {
        // fl_wheelCollider.brakeTorque = currentBreakForce;
        // fr_wheelCollider.brakeTorque = currentBreakForce;
        rl_wheelCollider.brakeTorque = currentBrakeForce;
        rr_wheelCollider.brakeTorque = currentBrakeForce;
    }
    
    private void HandleSteering()
    {
        currentSteeringAngle = maxSteeringAngle * horizontalInput;
        fl_wheelCollider.steerAngle = currentSteeringAngle;
        fr_wheelCollider.steerAngle = currentSteeringAngle;
    }
    
    private void UpdateWheels()
    {
        UpdateSingleWheel(fl_wheelCollider, fl_wheelTransform);
        UpdateSingleWheel(fr_wheelCollider, fr_wheelTransform);
        UpdateSingleWheel(rl_wheelCollider, rl_wheelTransform);
        UpdateSingleWheel(rr_wheelCollider, rr_wheelTransform);
    }
    
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
    }
}
