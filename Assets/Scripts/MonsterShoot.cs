using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    
    public Transform target;

    public float distanceToShoot = 5f;
    public Transform firingPoint;

    public float projectileSpeed = 10f;
    
    public float fireRate;
    private float _timeToFire;

    private void Start()
    {
        _timeToFire = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            GetTarget();
        }

        if (Vector2.Distance(target.position, transform.position) <= distanceToShoot)
        {
            Shoot();
        }
    }

    private void GetTarget()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            target = player.transform;
        }
    }

    private void Shoot()
    {
        print(_timeToFire);
        if (_timeToFire <= 0f)
        {
            RotateTowardsTarget();
            GameObject projectile = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = firingPoint.up * projectileSpeed; 
            
            _timeToFire = fireRate;
        }
        else
        {
            _timeToFire -= Time.deltaTime;
        }
    }

    
    void RotateTowardsTarget()
    {
        Vector3 direction = target.position - firingPoint.position;
        direction.z = 0f;

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        firingPoint.rotation = rotation;
    }
}

