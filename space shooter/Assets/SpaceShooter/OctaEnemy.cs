using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctaEnemy : MonoBehaviour
{
    public float movementSpeed;

    Rigidbody rb;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        Vector3 lookVector = player.transform.position - transform.position;
        lookVector.y = transform.position.y;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
    }

    private void Move()
    {
        rb.velocity = transform.forward * movementSpeed;
    }
}
