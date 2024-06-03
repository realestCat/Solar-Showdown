using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string Sound;
    public GameObject BasicBGM;
    public GameObject PlayerAndMonster;
    public GameObject GameOver_;
    private FadeManager theFade;
    private AudioManager theAudio;
    private BGMManager BGM;
    // Start is called before the first frame update
    void Start()
    {
        theFade = FindObjectOfType<FadeManager>();
        theAudio = FindObjectOfType<AudioManager>();
        BGM = FindObjectOfType<BGMManager>();
        BasicBGM.SetActive(false);
        BGM.Stop();
        StartCoroutine(WaitCoroutine());
    }

      IEnumerator WaitCoroutine()
        {

            
             PlayerAndMonster.SetActive(false);
            theFade.FadeOut();
            yield return new WaitForSeconds(3f);
            GameOver_.SetActive(true);
            theAudio.Play(Sound);
             StartCoroutine(WaitCoroutine2());
        }

        IEnumerator WaitCoroutine2()
        { 
            yield return new WaitForSeconds(4.5f);
            SceneManager.LoadScene("Title");
        }
   
}
