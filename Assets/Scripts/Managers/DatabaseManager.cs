using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    static public DatabaseManager instance;

    private PlayerStat thePlayerStat;

    public GameObject prefabs_Floating_Text;
    public GameObject parent;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    public string[] var_name;
    public float[] var;

    public string[] switch_name;
    public string[] switches;

    public List<Item> itemList = new List<Item>();

    private void FloatingText(int number, string color)
    {
        Vector3 vector = thePlayerStat.transform.position;
        vector.y += 17;
    }

    public void UseItem(int _itemID)
    {
        switch( _itemID) 
        {
            case 10001:
                if(thePlayerStat.hp >= thePlayerStat.currentHP + 5)
                thePlayerStat.currentHP += 5;
                else
                    thePlayerStat.currentHP = thePlayerStat.hp;
                break;

            case 10002:
                if (thePlayerStat.hp >= thePlayerStat.currentHP + 8)
                    thePlayerStat.currentHP += 8;
                else
                    thePlayerStat.currentHP = thePlayerStat.hp;
                break;

            case 10003:
                if (thePlayerStat.hp >= thePlayerStat.currentHP + 11)
                    thePlayerStat.currentHP += 11;
                else
                    thePlayerStat.currentHP = thePlayerStat.hp;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        thePlayerStat = FindObjectOfType<PlayerStat>();
        itemList.Add(new Item(10001, "Red Potion", "+5 hp", Item.ItemType.Use));
        itemList.Add(new Item(10002, "Red Potion", "+8 hp", Item.ItemType.Use));
        itemList.Add(new Item(10003, "Red Potion", "+11 hp", Item.ItemType.Use));
    }
}
