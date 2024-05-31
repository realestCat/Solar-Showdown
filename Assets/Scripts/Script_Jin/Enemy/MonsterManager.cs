using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonMove
{
    [Tooltip("MonMove를 체크하면 몬스터가 움직임")]
    public bool MONmove;

    public string[] direction; // 움질일 방향

    [Range(1, 5)][Tooltip("1 = 천천히, 2 = 조금 천천히, 3 = 보통, 4 = 빠르게, 5 = 연속적으로")]
    public int frequency; // 얼마나 빠르게
}

public class MonsterManager : MovingObject
{
    [SerializeField]
    public MonMove monster;

    // Start is called before the first frame update
    void Start()
    {
        queue = new Queue<string>();
        StartCoroutine(MoveCoroutine());
    }

    public void SetMove()
    {
       // StartCoroutine(MoveCoroutine());
    }
    public void SetNotMove()
    {
       // StopAllCoroutines();
    }

    IEnumerator MoveCoroutine() 
    {
        if(monster.direction.Length != 0)
        { 
            for(int i = 0; i < monster.direction.Length; i++) 
            {

                yield return new WaitUntil(() => queue.Count < 2);
                base.Move(monster.direction[i], monster.frequency);
                
                if (i == monster.direction.Length - 1)
                {
                    i = -1;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
