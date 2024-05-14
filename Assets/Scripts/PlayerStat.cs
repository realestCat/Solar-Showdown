using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat Instance;

    public int character_Lv;
    public int[] needExp;
    public int currentExp;

    public int hp;
    public int currentHP;
    public int mp;
    public int currentMP;

    public int atk;
    public int def;

    //public int recover_hp;
    //public int recover_mp;

    //public string dmgSound;

    //public float time;
    //private float current_time;

    //public GameObject prefabs_Floating_text;
    //public GameObject parent;

    public Slider hpSlider;
    public Slider mpSlider;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        currentHP = hp;
        currentMP = mp;
        //current_time = time;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.maxValue = hp;
        mpSlider.maxValue = mp;

        hpSlider.value = currentHP;
        mpSlider.value = currentMP;

        
    }
}
