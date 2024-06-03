using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCount : MonoBehaviour
{
    private PlayerStat thePlayer;
    private CameraManager theCamera;

    public GameObject MapTransfer1;
    public GameObject MapTransfer2;
    public GameObject MapTransfer3;

    //public BoxCollider2D Bound1;
    //public BoxCollider2D Bound2;
    //public BoxCollider2D Bound3;


    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerStat>();
        //theCamera = FindObjectOfType<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer.killCount == 1)
        {
            MapTransfer1.SetActive(true);
           // theCamera.SetBound(Bound1);
        }
            
        if (thePlayer.killCount == 2)
        {
            MapTransfer2.SetActive(true);
            //theCamera.SetBound(Bound2);
        }

        if (thePlayer.killCount == 3)
        {
            MapTransfer3.SetActive(true);
            //theCamera.SetBound(Bound2);
        }
    }
}
