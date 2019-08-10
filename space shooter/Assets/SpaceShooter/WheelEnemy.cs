using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelEnemy : MonoBehaviour
{
    public float movementSpeed;
    public float changeAngleRate;

    Rigidbody rb;

    private float nextAngleChange;
    private float isNextAngleNegative;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        isNextAngleNegative = Random.Range(0.0f, 1.0f); 
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        LookAtRandomAngle();
    }

    private void Move()
    {
        rb.velocity = -transform.forward * movementSpeed;
    }

    private void LookAtRandomAngle()
    {
        if (Time.time > nextAngleChange)
        {
            nextAngleChange = Time.time + changeAngleRate;
            Quaternion targetAngle = Quaternion.Euler(0.0f, Random.Range(-45.0f, 45.0f), 0.0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetAngle, 1);
        }
    }
}
