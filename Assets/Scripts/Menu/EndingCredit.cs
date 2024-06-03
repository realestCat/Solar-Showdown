using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCredit : MonoBehaviour
{

    //// Ending Credit
    public GameObject EC;
    public GameObject basicBGM;
    public GameObject PlayerAndMonster;
    public GameObject Bar;

    private BGMPlay theBGM;
    private BGMManager BGM;
    private OrderManager theOrder;
    private FadeManager theFade;

    // Start is called before the first frame update
    void Start()
    {
        theBGM = FindObjectOfType<BGMPlay>();
        BGM = FindObjectOfType<BGMManager>();
        theOrder = FindObjectOfType<OrderManager>();
        theFade = FindObjectOfType<FadeManager>();

        basicBGM.SetActive(false);
        Bar.SetActive(false);
        theOrder.NotMove();
        PlayerAndMonster.SetActive(false);
        BGM.Stop();


        EC.SetActive(true);
        StartCoroutine(WaitCoroutine1());
       

        StartCoroutine(WaitCoroutine2());

    }

    IEnumerator WaitCoroutine1()
    {
        yield return new WaitForSeconds(6.5f);
        theBGM.playMusucTrack = 2;
        BGM.Play(theBGM.playMusucTrack);
    }

    IEnumerator WaitCoroutine2()
    {
        yield return new WaitForSeconds(18f);
        theFade.FadeOut();
        StartCoroutine(WaitCoroutine3());
        SceneManager.LoadScene("Title");
    }

    IEnumerator WaitCoroutine3()
    {
        yield return new WaitForSeconds(2f);
    }

}
