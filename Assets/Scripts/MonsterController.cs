using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MonsterControll : MonoBehaviour
{

    public GameObject target;
    Vector3 dir;
    public float speed;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        // speed = 3.0f;
        time = Time.deltaTime;
        // target = GameObject.Find("Player");


    }

    // Update is called once per frame
    void Update()
    {
        dir = target.transform.position - transform.position;
        dir.Normalize();
        transform.position += speed * dir * time;
    }
}
