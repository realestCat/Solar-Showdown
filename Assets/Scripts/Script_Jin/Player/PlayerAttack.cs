using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject prefabs_Floating_Text;
    //public GameObject parent;
    public GameObject effect;
    public int atk;
    // public string atkSound;

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
        if (collision.gameObject.tag == "Enemy")
        {

            EnemyStat enemyStat = collision.gameObject.GetComponent<EnemyStat>();
            if (enemyStat != null)
            {
                enemyStat.Hit(atk);
            }

            //AudioManager.instance.Play(atkSound);

            Vector3 vector = collision.transform.position;

            Instantiate(effect, vector, Quaternion.Euler(Vector3.zero));
            Destroy(this.gameObject);

            //vector.y += 17;

            //GameObject clone = Instantiate(prefabs_Floating_Text, vector, Quaternion.Euler(Vector3.zero));
            //clone.GetComponent<FloatingText>().text.text = atk.ToString();
            //clone.GetComponent<FloatingText>().text.color = Color.white;
            //clone.GetComponent<FloatingText>().text.fontSize = 10;
            //clone.transform.SetParent(parent.transform);
        }

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

    }
}
