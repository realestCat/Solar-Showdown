using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class Title : MonoBehaviour
{
    public GameObject start;
    public GameObject quit;

    private FadeManager theFade;
    private AudioManager theAudio;

    public string click_sound;

    // Start is called before the first frame update
    void Start()
    {
         theFade = FindObjectOfType<FadeManager>();
        theAudio = FindObjectOfType<AudioManager>();

    }

    public void StartGame()
    {
        StartCoroutine(GameStartCoroutine());
    }

    IEnumerator GameStartCoroutine()
    {
        theFade.FadeOut();
        theAudio.Play(click_sound);
        start.SetActive(false);
        quit.SetActive(false);
        yield return new WaitForSeconds(2f);
        
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
         theAudio.Play(click_sound);
        UnityEngine.Application.Quit();
    }

}
