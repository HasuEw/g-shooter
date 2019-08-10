using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyShot;
    public float fireRate;
    public Transform shotSpawn;
    public Transform player;
    public float movementSpeed;

    Rigidbody rb;

    private float nextFire;

    private float stoppingDistance;
    private float retreatDistance;

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
        Shoot();
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
        stoppingDistance = Random.Range(7.0f, 11.0f);
        retreatDistance = Random.Range(4.0f, 7f);
        movementSpeed = Random.Range(1.0f, 4.0f);

        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
            rb.velocity = transform.forward * movementSpeed;
        else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
            rb.velocity = -transform.forward * movementSpeed;
    }

    private void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bolt = Instantiate(enemyShot, shotSpawn.position, transform.rotation);
        }
    }
}
