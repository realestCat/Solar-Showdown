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


    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerStat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer.killCount == 4)
        {
            MapTransfer1.SetActive(true);
        }
            
        if (thePlayer.killCount == 12)
        {
            MapTransfer2.SetActive(true);
        }

        if (thePlayer.killCount == 20)
        {
            MapTransfer3.SetActive(true);
        }
    }
}
