using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TransferScene : MonoBehaviour
{
   // static public TransferScene instance;
    public string transferMapName;
    // public GameObject bars;
    private PlayerManager thePlayer;
   // private FadeManager theFade;
    //private OrderManager theOrder;

    //public void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //    else
    //    {
    //        DontDestroyOnLoad(this.gameObject);
    //        instance = this;
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>();
        //theFade = FindObjectOfType<FadeManager>();
        //theOrder = FindObjectOfType<OrderManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(TransferCoroutine());
      
        }
    }

    IEnumerator TransferCoroutine()
    {
        //theOrder.NotMove();
        //theFade.FadeOut();
       // yield return new WaitForSeconds(1f);
        thePlayer.currentMapName = transferMapName;
        //theOrder.Move();
       // bars.SetActive(false);
        SceneManager.LoadScene(transferMapName);
        //theFade.FadeIn();
        yield return new WaitForSeconds(0.5f);
       // bars.SetActive(true);



    }
}

