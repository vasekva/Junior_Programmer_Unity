using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using YamlDotNet.Core.Tokens;

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
    private float currentBreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteeringAngle;
    
    [SerializeField] private WheelCollider fl_wheelCollider;
    [SerializeField] private WheelCollider fr_wheelCollider;
    [SerializeField] private WheelCollider rl_wheelCollider;
    [SerializeField] private WheelCollider rr_wheelCollider;

    [SerializeField] private Transform fl_wheelTransform;
    [SerializeField] private Transform fr_wheelTransform;
    [SerializeField] private Transform rl_wheelTransform;
    [SerializeField] private Transform rr_wheelTransform;
    
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        // horizontalInput = Input.GetAxis("Horizontal");
        // verticalInput = Input.GetAxis("Vertical");
        // transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        // transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
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

    private void HandleSteering()
    {
        currentSteeringAngle = maxSteeringAngle * horizontalInput;
        fl_wheelCollider.steerAngle = currentSteeringAngle;
        fr_wheelCollider.steerAngle = currentSteeringAngle;
    }

    private void HandleMotor()
    {
        fl_wheelCollider.motorTorque = verticalInput * motorForce;
        fr_wheelCollider.motorTorque = verticalInput * motorForce;
        currentBreakForce = isBreaking ? breakForce : 0f;
        if (isBreaking)
        {
            ApplyBreaking();
        }
    }

    private void ApplyBreaking()
    {
        fl_wheelCollider.brakeTorque = currentBreakForce;
        fr_wheelCollider.brakeTorque = currentBreakForce;
        rl_wheelCollider.brakeTorque = currentBreakForce;
        rr_wheelCollider.brakeTorque = currentBreakForce;
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }
}
