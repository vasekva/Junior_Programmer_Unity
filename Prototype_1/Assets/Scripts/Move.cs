using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float currentSteeringAngle;
    private float currentBrakeForce;

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

    private Vector2 moveVector;

    public void SetMoveVector(Vector2 vectorValue)
    {
        moveVector = vectorValue;
    }

    void FixedUpdate()
    {
        Debug.Log("Move");
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }
    
    private void HandleMotor()
    {
        fl_wheelCollider.motorTorque = moveVector.y * motorForce;
        fr_wheelCollider.motorTorque = moveVector.y * motorForce;
        // if (isBraking && currentBrakeForce != 0)
        //     currentBrakeForce = 0f;
        // else
        //     currentBrakeForce = brakeForce;
        // if (isBraking)
        // {
        //     ApplyBreaking();
        // } 
    }
    
    // private void ApplyBreaking()
    // {
    //     fl_wheelCollider.brakeTorque = currentBrakeForce;
    //     fr_wheelCollider.brakeTorque = currentBrakeForce;
    //     rl_wheelCollider.brakeTorque = currentBrakeForce;
    //     rr_wheelCollider.brakeTorque = currentBrakeForce;
    // }
    
    private void HandleSteering()
    {
        currentSteeringAngle = maxSteeringAngle * moveVector.x;
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
        wheelTransform.position = pos;
    }
}

