using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private Move mover;
    private int cameraId = 0;
    
    // private bool  isBraking;
    
    private void Awake()
    {
        mover = GetComponent<Move>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        mover.SetMoveVector(context.ReadValue<Vector2>());
    }

    public void ChangeCamera()
    {
        cameraId = cameraId == 0 ? 1 : 0;
        if (cameraId == 0)
            GetComponent<ToggleCamera>().ShowFirstPersonView();
        else
            GetComponent<ToggleCamera>().ShowOverheadView();
    }
}
