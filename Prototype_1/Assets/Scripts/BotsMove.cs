using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BotsMove : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.position += Vector3.back * Time.deltaTime;
    }
}
