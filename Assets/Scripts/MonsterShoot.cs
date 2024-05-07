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
    private float timeToFire;

    private void Start()
    {
        timeToFire = fireRate;
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
        if (timeToFire <= 0f)
        {
            GameObject projectile = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = firingPoint.up * projectileSpeed; 
            
            timeToFire = fireRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }
}
