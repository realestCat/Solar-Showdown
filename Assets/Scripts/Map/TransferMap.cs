using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TransferMap : MonoBehaviour
{
    public string transferMapName;
    public string Sound;

    public Transform target;
    public BoxCollider2D targetBound;

    public GameObject hpSlider;

    private PlayerManager thePlayer;
    private CameraManager theCamera;
    private FadeManager theFade;
    private OrderManager theOrder;
    private AudioManager theAudio;


    // Start is called before the first frame update
    void Start()
    {
        theCamera = FindObjectOfType<CameraManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        theFade = FindObjectOfType<FadeManager>();
        theOrder = FindObjectOfType<OrderManager>();
        theAudio = FindObjectOfType<AudioManager>();
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
        theAudio.Play(Sound);
        theOrder.NotMove();
        hpSlider.SetActive(false);
        theFade.FadeOut();
        yield return new WaitForSeconds(1f);
        thePlayer.currentMapName = transferMapName;
        theCamera.SetBound(targetBound);
        theCamera.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, theCamera.transform.position.z);
        thePlayer.transform.position = target.transform.position;
        theFade.FadeIn();
        yield return new WaitForSeconds(0.5f);
        hpSlider.SetActive(true);
        theOrder.Move();

    }
}


