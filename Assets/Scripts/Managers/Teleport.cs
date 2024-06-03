using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private PlayerManager thePlayer;
    public Transform target;
    public GameObject teleport;
    public string Sound;
    private AudioManager theAudio;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>();
        theAudio = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            teleport.SetActive(true);
            theAudio.Play(Sound);
            thePlayer.transform.position = target.transform.position;
            StartCoroutine(WaitCoroutine());
            
        }
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(0.45f);
        teleport.SetActive(false);

    }
}
