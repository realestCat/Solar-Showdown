using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlay : MonoBehaviour
{
    BGMManager BGM;
    public int playMusucTrack;

    // Start is called before the first frame update
    void Start()
    {
        BGM = FindObjectOfType<BGMManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BGM.Play(playMusucTrack);
        this.gameObject.SetActive(false);
    }

}
