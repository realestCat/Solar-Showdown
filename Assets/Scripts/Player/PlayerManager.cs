using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerManager : MovingObject
{
    static public PlayerManager instance;

    public string currentMapName;
    //public string currentSceneName;

    public string walkSound_1;
    public string walkSound_2;
    public string walkSound_3;
    public string walkSound_4;

    private AudioManager theAudio;

    public float runSpeed;
    private float applyRunSpeed;
    private bool applyRunFlag = false;


    private bool canMove = true;
    public bool notMove = false;

    private bool attacking = false;
    public float attackDelay;
    private float currentAttackDelay;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
            queue = new Queue<string>();
            boxCollider = GetComponent<BoxCollider2D>();
            //audioSource = GetComponent<AudioSource>();
            animator = GetComponent<Animator>();
            theAudio = FindObjectOfType<AudioManager>();
    }

    IEnumerator MoveCoroutine()
    {
        while ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && !notMove && !attacking)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                applyRunSpeed = runSpeed;
                applyRunFlag = true;
            }
            else
            {
                applyRunFlag = false;
                applyRunSpeed = 0;

            }

            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);


            if (vector.x != 0)
                vector.y = 0;

            animator.SetFloat("DirX", vector.x);
            animator.SetFloat("DirY", vector.y);

            bool checkCollisionFlag = base.CheckCollison();
            if(checkCollisionFlag) { break; }

            animator.SetBool("Walking", true);

            int temp = UnityEngine.Random.Range(1, 5);

            switch (temp)
            {
                case 1:
                    theAudio.Play(walkSound_1);
                    break;
                case 2:
                    theAudio.Play(walkSound_2);
                    break;
                case 3:
                    theAudio.Play(walkSound_3);
                    break;
                case 4:
                    theAudio.Play(walkSound_4);
                    break;
            }
            //         //theAudio.setVolume(walkSound_2, 0.5f);
            //         //theAudio.stop(walkSound_2);
            //         //theAudio.SetLoop(walkSound_2);

           

            boxCollider.offset = new Vector2(vector.x * 0.3f * speed * walkCount, vector.y * 0.3f * speed * walkCount);

            while (currentWalkCount < walkCount)
            {
                if (vector.x != 0)
                {
                    transform.Translate(vector.x * (speed + applyRunSpeed), 0, 0);
                }
                else if (vector.y != 0)
                {
                    transform.Translate(0, vector.y * (speed + applyRunSpeed), 0);
                }
                if (applyRunFlag) { currentWalkCount++; }
                currentWalkCount++;

                if (currentWalkCount == 12)
                {
                    boxCollider.offset = Vector2.zero;
                }
                yield return new WaitForSeconds(0.01f);
            }

            currentWalkCount = 0;
        }
        animator.SetBool("Walking", false);
        canMove = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && !notMove && !attacking)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                canMove = false;
                StartCoroutine(MoveCoroutine());
            }
        }

        if(!notMove && !attacking)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                currentAttackDelay = attackDelay;
                attacking = true;
                animator.SetBool("Attacking", true);
            }
        }

        if(attacking)
        {
            currentAttackDelay -= Time.deltaTime;
            if(currentAttackDelay <= 0)
            {
                animator.SetBool("Attacking", false);
                attacking = false;
            }
        }

    }
}
