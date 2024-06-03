using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[System.Serializable]
public class TestTurn
{
    public string name;
    public string direction;
}
public class theOrder_Turn : MonoBehaviour
{
    [SerializeField]

    public string direction;
    private OrderManager theOrder;

    // Start is called before the first frame update
    void Start()
    {
        theOrder = FindObjectOfType<OrderManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            theOrder.PreLoadCharacter();
            theOrder.Turn("monster1", direction);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
