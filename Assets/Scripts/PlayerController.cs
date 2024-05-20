using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Vector3 vector;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

            if (vector.x != 0)
                transform.Translate(vector.x * Time.deltaTime * speed, 0, 0);

            else if (vector.y != 0)
                transform.Translate(0, vector.y * Time.deltaTime * speed, 0);
        }
    }
}
