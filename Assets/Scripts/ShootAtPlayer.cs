using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!target)
        {
            GetTarget();
        }
    }
}
