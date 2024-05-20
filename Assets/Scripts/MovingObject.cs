using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public string characterName;

    public float speed;
    protected Vector3 vector;

    public int walkCount;
    protected int currentWalkCount;

    public Animator animator;
    public BoxCollider2D boxCollider;
    public LayerMask layerMask;

    public Queue<string> queue;

    private bool notCoroutine = false;

    public void Move(string _dir, int _frequency = 5)
    {
        queue.Enqueue(_dir);
        if(!notCoroutine)
        {
            notCoroutine = true;
            StartCoroutine(MoveCoroutine(_dir, _frequency)); }
       
    }

    IEnumerator MoveCoroutine(string _dir, int _frequency)
    {
        while(queue.Count != 0) 
        {
            switch (_frequency)
            {
                case 1:
                    yield return new WaitForSeconds(4f);
                    break;
                case 2:
                    yield return new WaitForSeconds(3f);
                    break;
                case 3:
                    yield return new WaitForSeconds(2f);
                    break;
                case 4:
                    yield return new WaitForSeconds(1f);
                    break;
                case 5:
                    break;

            }

            string direction = queue.Dequeue();
            vector.Set(0, 0, vector.z);


            switch (direction)
            {
                case "UP":
                    vector.y = 1f;
                    break;
                case "DOWN":
                    vector.y = -1f;
                    break;
                case "RIGHT":
                    vector.x = 1f;
                    break;
                case "LEFT":
                    vector.x = -1f;
                    break;
            }

            //animator.SetFloat("DirX", vector.x);
            //animator.SetFloat("DirY", vector.y);

            while (true)
            {
                bool checkCollisionFlag = CheckCollison();
                if (checkCollisionFlag) {
                    //animator.SetBool("Walking", false);
                    yield return new WaitForSeconds(1f); }
                else { break; }
            }


            //animator.SetBool("Walking", true);

            boxCollider.offset = new Vector2(vector.x * 0.3f * speed * walkCount, vector.y * 0.3f * speed * walkCount);

            while (currentWalkCount < walkCount)
            {
                transform.Translate(vector.x * speed, vector.y * speed, 0);
                currentWalkCount++;
                if(currentWalkCount == walkCount * 0.5f * 2) 
                {
                    boxCollider.offset = Vector2.zero;
                }
                yield return new WaitForSeconds(0.01f);
            }
            currentWalkCount = 0;
            //if (_frequency != 5)
            //    animator.SetBool("Walking", false);
        }
        //animator.SetBool("Walking", false);
        notCoroutine = false;
    }

    protected bool CheckCollison()
    {
        RaycastHit2D hit;

        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(vector.x * speed * walkCount, vector.y * speed * walkCount);

        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, layerMask);
        boxCollider.enabled = true;

        if (hit.transform != null)
            return true;
        return false;

    }
}
