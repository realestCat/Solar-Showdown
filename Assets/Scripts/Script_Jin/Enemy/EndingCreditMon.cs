using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class EndingCreditMon : MonoBehaviour
{
    public static EndingCreditMon instance;

    public int hp;
    public int currentHp;
    public int atk;
    public int def;
   // public int exp;
    public string deathSound;
    public GameObject effect;

    // Ending Credit
    public GameObject EC;
    public GameObject Bars;


    public GameObject healthBarBackground;
    public Image healthBarFilled;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentHp = hp;
        healthBarFilled.fillAmount = 1f;
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
            Instantiate(effect, vector, Quaternion.Euler(Vector3.zero));
            AudioManager.instance.Play(deathSound);
            Destroy(this.gameObject);
           // PlayerStat.instance.currentExp += exp;
            EC.SetActive(true);
            Bars.SetActive(false);

        }

        healthBarFilled.fillAmount = (float)currentHp / hp;
        healthBarBackground.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(WaitCoroutine());

        return dmg;
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(3f);
        healthBarBackground.SetActive(false);
    }
}
