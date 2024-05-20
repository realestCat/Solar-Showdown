using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonMove
{
    [Tooltip("MonMove�� üũ�ϸ� ���Ͱ� ������")]
    public bool MONmove;

    public string[] direction; // ������ ����

    [Range(1, 5)][Tooltip("1 = õõ��, 2 = ���� õõ��, 3 = ����, 4 = ������, 5 = ����������")]
    public int frequency; // �󸶳� ������
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
