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


        GameObject clone = Instantiate(prefabs_Floating_Text, vector, Quaternion.Euler(Vector3.zero));
        clone.GetComponent<FloatingText>().text.text = number.ToString();

        if(color == "GREEN")
        clone.GetComponent<FloatingText>().text.color = Color.green;
        else if (color == "RED")
            clone.GetComponent<FloatingText>().text.color = Color.red;


        clone.GetComponent<FloatingText>().text.fontSize = 10;
        clone.transform.SetParent(parent.transform);
    }

    public void UseItem(int _itemID)
    {
        switch( _itemID) 
        {
            case 10001:
                if(thePlayerStat.hp >= thePlayerStat.currentHP + 30)
                thePlayerStat.currentHP += 30;
                else
                    thePlayerStat.currentHP = thePlayerStat.hp;
                FloatingText(30, "GREEN");
                break;
            
                //case 10002:
            //    Debug.Log("+50 mp");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        thePlayerStat = FindObjectOfType<PlayerStat>();
        itemList.Add(new Item(10001, "Red Potion", "+30 hp", Item.ItemType.Use));
    }
}
