using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


public class EnemyStat : MonoBehaviour
{
   // public static EnemyStat instance;

    public int hp;
    public int currentHp;
    public int atk;
    public int def;
    public string deathSound;
    public GameObject effect;
    public GameObject E_Credit;

    private PlayerStat thePlayer;

    public GameObject healthBarBackground;
    public Image healthBarFilled;
    private AudioManager theAudio;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = hp;
        healthBarFilled.fillAmount = 1f;
        thePlayer = FindObjectOfType<PlayerStat>();
        theAudio = FindObjectOfType<AudioManager>();
    }

    public int Hit(int _playerAtk)
    {
        int playerAtk = _playerAtk;
        int dmg;

        if (def >= playerAtk)
        { dmg = 1; }
        else
        { dmg = playerAtk - def; }

        currentHp -= dmg;

        Vector3 vector = this.transform.position;

        if (currentHp <= 0)
        {
            thePlayer.killCount++;
            Instantiate(effect, vector, Quaternion.Euler(Vector3.zero));
            theAudio.Play(deathSound);
            Destroy(this.gameObject);
        }

        healthBarFilled.fillAmount = (float) currentHp/hp;
        healthBarBackground.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(WaitCoroutine());

        return dmg;
    }

    public void Credit()
    {
        if (currentHp <= 0)
        {

            E_Credit.SetActive(true);
        }
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(3f);
        healthBarBackground.SetActive(false);
    }

    
}
