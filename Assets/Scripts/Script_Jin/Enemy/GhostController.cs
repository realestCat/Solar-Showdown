using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class GhostController : MovingObject
{
    public float attackDelay;

    public float inter_MoveWaitTime;
    private float current_interMWT;

   // public string atkSound;

    private Vector2 PlayerPos;

    private int random_int;
    private string direction;
    public GameObject healthBar;


    // Start is called before the first frame update
    void Start()
    {
        queue = new Queue<string>();
        current_interMWT = inter_MoveWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        current_interMWT -= Time.deltaTime;

        if (current_interMWT <= 0)
        {
            current_interMWT = inter_MoveWaitTime;

            if(NearPlayer())
            {
                Flip();
                return;
            }

            RandomDirection();

            if (base.CheckCollison())
                return;
            base.Move(direction);
        }


    }

    private void Flip()
    {
        Vector3 flip = transform.localScale;
        if (PlayerPos.x > this.transform.position.x)
            flip.x = -2f;
        else
            flip.x = 2f;
        this.transform.localScale = flip;

        healthBar.transform.localScale = flip/2;

        animator.SetTrigger("Attack");
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(attackDelay);
        //AudioManager.instance.Play(atkSound);
        if(NearPlayer())
        {
           PlayerStat.instance.Hit(GetComponent<EnemyStat>().atk);
        }
    }

    private bool NearPlayer()
    {
        PlayerPos = PlayerManager.instance.transform.position;

        if(Mathf.Abs(Mathf.Abs(PlayerPos.x) - Mathf.Abs(this.transform.position.x)) <= speed * walkCount * 2.5f) 
        {
            if (Mathf.Abs(Mathf.Abs(PlayerPos.y) - Mathf.Abs(this.transform.position.y)) <= speed * walkCount * 1f)
            {
                return true;
            }

        }

        if (Mathf.Abs(Mathf.Abs(PlayerPos.y) - Mathf.Abs(this.transform.position.y)) <= speed * walkCount * 2.5f)
        {
            if (Mathf.Abs(Mathf.Abs(PlayerPos.x) - Mathf.Abs(this.transform.position.x)) <= speed * walkCount * 1f)
            {
                return true;
            }

        }
        return false;
    }

    private void RandomDirection()
    {
        vector.Set(0, 0, vector.z);
        random_int = UnityEngine.Random.Range(0, 4);

        switch (random_int)
        {
            case 0:
                vector.y = 1f;
                direction = "UP";
                break;
            case 1:
                vector.y = -1f;
                direction = "DOWN";
                break;
            case 2:
                vector.x = 1f;
                direction = "RIGHT";
                break;
            case 3:
                vector.x = -1f;
                direction = "LEFT";
                break;
        }
    }
}
