using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public GameObject basicBGM;

    public BGMPlay theBGM;
    BGMManager BGM;
    AttackEnemy mouseAttack;

    public GameObject go;
    public GameObject hpBar;
    public AudioManager theAudio;

    public string call_sound;
    public string cancel_sound;

    public OrderManager theOrder;

    private bool activated;

    // Start is called before the first frame update
    void Start()
    {
        theBGM = FindObjectOfType<BGMPlay>();
        BGM = FindObjectOfType<BGMManager>();
        mouseAttack = FindObjectOfType<AttackEnemy>();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        activated = false;
        go.SetActive(false);
        hpBar.SetActive(true);
        theOrder.Move();
        theAudio.Play(cancel_sound);
    }

    public void MusicPlay1()
    {
        basicBGM.SetActive(false);
        theAudio.Play(cancel_sound);
        theBGM.playMusucTrack = 0;
        BGM.Play(theBGM.playMusucTrack);

    }

    public void MusicPlay2()
    {
        basicBGM.SetActive(false);
        theAudio.Play(cancel_sound);
        theBGM.playMusucTrack = 1;
        BGM.Play(theBGM.playMusucTrack);

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mouseAttack.enabled = false;
            activated = !activated;
            hpBar.SetActive(false);

            if (activated)
            {
                theOrder.NotMove();
                go.SetActive(true);
                theAudio.Play(call_sound);
            }
            else
            {
                go.SetActive(false);
                theAudio.Play(cancel_sound);
                mouseAttack.enabled = true;
                hpBar.SetActive(true);
                theOrder.Move();
            }
        }

        
    }
}

