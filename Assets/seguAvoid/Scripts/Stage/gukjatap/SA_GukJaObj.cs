using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_GukJaObj : MonoBehaviour
{
    AudioSource soundPlayer;
    GameObject spawner;

    private void Start()
    {
        spawner = FindObjectOfType<SA_Nadaejima>().gameObject;
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawner.GetComponent<SA_Nadaejima>().GukJa == false)
        {
            Destroy(gameObject);
        }
    }
}
