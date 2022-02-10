using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int camId;

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }

    private void HandleTranslation()
    {
        if (camId == 0)
        {
            var targetPosition = target.TransformPoint(offset);
            transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = target.transform.position + offset;
        }
    }

    private void HandleRotation()
    {
        Vector3 targetPosition = target.position;
        Vector3 direction = Vector3.zero;
        var rotation = new Quaternion();

        if (camId == 0)
        {
            direction = targetPosition - transform.position;
            rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        else
        {
            direction = (targetPosition + new Vector3(0, 0, 10)) - transform.position;
            rotation = target.rotation * Quaternion.Euler(20, 0, 0); // changes x-axis' angle by 20
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
