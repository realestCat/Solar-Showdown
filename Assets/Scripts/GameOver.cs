using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject thePlayer;
    private FadeManager theFade;
    // Start is called before the first frame update
    void Start()
    {
        theFade = FindObjectOfType<FadeManager>();
        StartCoroutine(WaitCoroutine());
    }

      IEnumerator WaitCoroutine()
        {
            thePlayer.SetActive(false);
            theFade.FadeOut();
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("Title");
        }
   
}
