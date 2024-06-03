using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MonsterControll : MonoBehaviour
{

    public GameObject target;

    public int atk;
    public float attactDelay;
    public float speed;
    float time;

    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        time = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        dir = target.transform.position - transform.position;
        dir.Normalize();
        transform.position += speed * dir * time;
    }
}
