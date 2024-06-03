using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject prefabs_Floating_Text;
    public GameObject effect;

    public int atk;
    private EnemyStat theEnemyStat;


    // Start is called before the first frame update
    void Start()
    {
        int projectileLayer = gameObject.layer;
        int noPassingLayer = LayerMask.NameToLayer("No Passing");
        //Physics2D.IgnoreLayerCollision(projectileLayer, noPassingLayer, true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "King Enemy")
        {

            EnemyStat enemyStat = collision.gameObject.GetComponent<EnemyStat>();
            if (enemyStat != null)
            {
                enemyStat.Hit(atk);
            }

            if (collision.gameObject.tag == "King Enemy")
            {
                enemyStat.Credit();
            }

            Vector3 vector = collision.transform.position;

            Instantiate(effect, vector, Quaternion.Euler(Vector3.zero));
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

    }
}
