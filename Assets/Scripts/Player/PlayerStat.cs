using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat instance;

    public int killCount = 0;
    public int hp;
    public int currentHP;
    public int atk;
    public int def;
    public string dmgSound;


    public GameObject GameOver;
    public GameObject prefabs_Floating_text;
    public GameObject parent; // canvas

    public Slider hpSlider;

    private AudioManager theAudio;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentHP = hp;
        theAudio = FindObjectOfType<AudioManager>();
    }

    
    public void Hit(int _enemyAtk)
    {
        int dmg;
        if (def >= _enemyAtk)
        {
            dmg = 0;
        }
        else
            dmg = _enemyAtk - def;

        currentHP -= dmg;

        if (currentHP <= 0)
        { 
            GameOver.SetActive(true);
        }

            theAudio.Play(dmgSound);
    }


    IEnumerator HitCoroutine()
    {
        Color color = GetComponent<SpriteRenderer>().color;
        color.a = 0;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 1f;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 0;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 1f;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 0;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.1f);
        color.a = 1f;
        GetComponent<SpriteRenderer>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.maxValue = hp;
        hpSlider.value = currentHP;
    }
}
