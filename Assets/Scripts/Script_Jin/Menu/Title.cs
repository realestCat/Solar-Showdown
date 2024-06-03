using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class Title : MonoBehaviour
{
    //public AudioSource theAudio;
    public GameObject start;
    public GameObject quit;

    private FadeManager theFade;
    private AudioManager theAudio;

    public string click_sound;

    //private PlayerManager thePlayer;
    // private GameManager theGM;


    // Start is called before the first frame update
    void Start()
    {
         theFade = FindObjectOfType<FadeManager>();
        theAudio = FindObjectOfType<AudioManager>();
        // thePlayer = FindObjectOfType<PlayerManager>();
        // theGM = FindObjectOfType<GameManager>();
        //theAudio = GetComponent<AudioSource>();

    }

    public void StartGame()
    {
        StartCoroutine(GameStartCoroutine());
    }

    IEnumerator GameStartCoroutine()
    {
        theFade.FadeOut();
        theAudio.Play(click_sound);
        //theAudio.Play();
        start.SetActive(false);
        quit.SetActive(false);
        yield return new WaitForSeconds(2f);
        //Color color = thePlayer.GetComponent<SpriteRenderer>().color;
        //color.a = 1f;
        //thePlayer.GetComponent<SpriteRenderer>().color = color;
        //thePlayer.currentMapName = "Title";
        //thePlayer.currentSceneName = "Jinyang";
        // theGM.LoadStart();
        
        SceneManager.LoadScene("Main");


    }

    public void QuitGame()
    {
         theAudio.Play(click_sound);
       // theAudio.Play();
        UnityEngine.Application.Quit();
    }

}
