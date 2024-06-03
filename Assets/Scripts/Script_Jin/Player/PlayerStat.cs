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
    public GameObject player;
    public static PlayerStat instance;
    public GameObject thePlayer;

    public int killCount = 0;

    //public int character_Lv;
    //public int[] needExp;
    //public int currentExp;

    
    public GameObject GameOver;

    public int hp;
    public int currentHP;
    //public int mp;
    //public int currentMP;

    public int atk;
    public int def;

    //public int recover_hp;
    //public int recover_mp;

     public string dmgSound;

    //public float time;
    //private float current_time;

    public GameObject prefabs_Floating_text;
    public GameObject parent; // canvas

    public Slider hpSlider;
    //public Slider mpSlider;

    private AudioManager theAudio;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentHP = hp;
        // currentMP = mp;
        // current_time = time;
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
        { // UnityEngine.Debug.Log("Game Over");

            GameOver.SetActive(true);
        }

            theAudio.Play(dmgSound);

        Vector3 vector = this.transform.position;
        vector.y += 17;


        GameObject clone = Instantiate(prefabs_Floating_text, vector, Quaternion.Euler(Vector3.zero));
        clone.GetComponent<FloatingText>().text.text = dmg.ToString();
        clone.GetComponent<FloatingText>().text.color = Color.blue;
        clone.GetComponent<FloatingText>().text.fontSize = 10;
        clone.transform.SetParent(parent.transform);
        StopAllCoroutines();
        StartCoroutine(HitCoroutine());
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
       // mpSlider.maxValue = mp;

        hpSlider.value = currentHP;
      //  mpSlider.value = currentMP;


        //if (currentExp >= needExp[character_Lv]) 
        //{
        //    character_Lv++;
        //    hp += character_Lv * 2;
        //    mp += character_Lv + 3;

        //    currentHP = hp;
        //    currentMP = mp;
        //    atk++;
        //    def++;
        //}
        //hpSlider.maxValue = hp;
        //mpSlider.maxValue = mp;

        //hpSlider.value = currentHP;
        //mpSlider.value = currentMP;


    }
}
