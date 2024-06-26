using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public GameObject projectilePrefab1;
    public GameObject projectilePrefab2;
    public string atkSound1;
    public string atkSound2;
    public GameObject Fire_CoolDown;

    public float attackDelay;
    private float currentAttackDelay;
    bool Fire = true;

    public float projectileSpeed = 200f;

   // private Animator animator;

    void Start()
    {
      //  animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            GameObject projectile = Instantiate(projectilePrefab1, transform.position, Quaternion.identity);

            Vector2 direction = (mousePosition - transform.position).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            //if (angle >= -45 && angle <= 45)
            //{
            //    animator.Play("Character_Attack_Right");
            //    UnityEngine.Debug.Log("Right");
            //}
            //else if (angle > 45 && angle <= 135)
            //{

            //    animator.Play("Character_Attack_Up");
            //    UnityEngine.Debug.Log("Up");
            //}
            //else if (angle > 135 && angle <= 225)
            //{

            //    animator.Play("Character_Attack_Left");
            //    UnityEngine.Debug.Log("Left");
            //}
            //else
            //{
            //    animator.Play("Character_Attack_Down");
            //    UnityEngine.Debug.Log("Down");
            //}

            rb.velocity = direction * projectileSpeed;

            AudioManager.instance.Play(atkSound1);
        }
       else if (Input.GetMouseButtonDown(1) && Fire)
        {
            Fire_CoolDown.SetActive(false);

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            GameObject projectile = Instantiate(projectilePrefab2, transform.position, Quaternion.identity);

            Vector2 direction = (mousePosition - transform.position).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSpeed;

            AudioManager.instance.Play(atkSound2);

            Fire_CoolDown.SetActive(true);

            currentAttackDelay = attackDelay;
            Fire = false;

        }


        if (!Fire)
        {
            currentAttackDelay -= Time.deltaTime;

            if (currentAttackDelay <= 0)
            {
                Fire = true;
            }
        }
    }
}