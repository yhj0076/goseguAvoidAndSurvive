using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_FishBreadRain : MonoBehaviour
{
    public GameObject fishBread;
    public GameObject OB;
    AudioSource soundPlayer;

    private void OnEnable()
    {
        OB.GetComponent<SA_OutOfBound>().DamageOn = false;
        soundPlayer = GetComponent<AudioSource>(); 
        soundPlayer.Play();
        Invoke("delayOn",7);
    }

    void delayOn()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(soundPlayer.isPlaying == false)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
