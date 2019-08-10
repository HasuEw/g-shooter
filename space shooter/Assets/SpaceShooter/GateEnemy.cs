using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateEnemy : MonoBehaviour
{
    public float movementSpeed;
    public float turnSpeed;

    Rigidbody rb;

    private float nextAngleChange;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Rotate();
    }

    private void Move()
    {
        rb.velocity = Vector3.back * movementSpeed;
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * turnSpeed);
    }
}
