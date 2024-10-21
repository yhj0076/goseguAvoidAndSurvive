using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_OneChipController : MonoBehaviour
{
    public GameObject OB;
    AudioSource soundPlayer;
    public float waitTime;

    public bool StageOn;
    // Update is called once per frame
    void Update()
    {
        if(StageOn)
        {
            transform.GetChild(1).localPosition = Vector2.Lerp(transform.GetChild(1).localPosition,new Vector2(-6.41f, -2.068301f),0.08f);   // 고세구 몸뚱애리
            transform.GetChild(2).localPosition = Vector2.Lerp(transform.GetChild(2).localPosition,new Vector2(0.4384303f, 0.35f),0.08f);   // 쥬시쿨
        }
        else
        {
            transform.GetChild(1).localPosition = Vector2.Lerp(transform.GetChild(1).localPosition, new Vector2(-10.99f, -2.068301f), 0.08f); // 고세구 몸뚱애리
            transform.GetChild(2).localPosition = Vector2.Lerp(transform.GetChild(2).localPosition, new Vector2(0.4384303f, -3.51f), 0.08f);   // 쥬시쿨
        }


        if (soundPlayer.isPlaying == false)
        {
            StageOn = false;
            Invoke("delayFalse",1f);
        }
    }
    private void OnEnable()
    {
        OB.GetComponent<SA_OutOfBound>().DamageOn = false;
        StageOn = true;
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.PlayDelayed(waitTime);
        transform.GetChild(0).gameObject.SetActive(true);   //PAQUI
        Invoke("delayAnime",waitTime);
    }

    void delayFalse()
    {
        gameObject.SetActive(false);
    }

    void delayAnime()
    {
        transform.GetChild(1).GetComponent<SA_goseguAnimation_Onechip>().timer = true;
    }

    private void OnDisable()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).GetComponent<SA_goseguAnimation_Onechip>().timer = false;
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
