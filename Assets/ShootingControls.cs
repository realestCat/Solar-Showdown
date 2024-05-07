using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingControl : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float projectileSpeed = 10f;
    public float shootCooldown = 0.5f;
    public float shootTimer = 0f;

    void Update()
    {
        shootTimer -= Time.deltaTime;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        RotateTowardsMouse(mouseWorldPosition);

        if (Input.GetKeyDown(KeyCode.Space) && shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootCooldown;
        }
    }

    void RotateTowardsMouse(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        direction.z = 0f;

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        shootPoint.rotation = rotation;
        transform.rotation = rotation;
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = shootPoint.up * projectileSpeed;
        rb.gravityScale = 0f;
    }

}

