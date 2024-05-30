using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    private DatabaseManager theDatabase;

    public int itemID;
    public string pickUpSound;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            AudioManager.instance.Play(pickUpSound);
            theDatabase.UseItem(itemID);
            Destroy(this.gameObject);

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        theDatabase = FindObjectOfType<DatabaseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
