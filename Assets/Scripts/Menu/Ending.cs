using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject go;

    public OrderManager theOrder;

    void Start()
    {
        theOrder.NotMove();
        go.SetActive(true);
    }

}
