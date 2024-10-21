using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_jansangController : MonoBehaviour
{
    AudioSource soundPlayer;
    public GameObject OB;
    float time = -2;

    bool jansang1 = false;
    bool jansang2 = false;
    bool jansang3 = false;
    bool jansang4 = false;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0f && time < 3.3f && jansang1 == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            jansang1 = true;
        }
        else if (time>=3.3f&&time<6.2f&&jansang2==false)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            jansang2 = true;
        }
        else if (time >= 6.2f && time < 9.3f && jansang3 == false)
        {
            transform.GetChild(2).gameObject.SetActive(true);
            jansang3 = true;
        }
        else if (time >= 9.3f && jansang4 == false)
        {
            transform.GetChild(3).gameObject.SetActive(true);
            jansang4 = true;
        }

        if(soundPlayer.isPlaying==false)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        OB.GetComponent<SA_OutOfBound>().DamageOn = false;
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.PlayDelayed(2);
        time = -2;
        for (int i = 0; i < 15; i++)
        {
            transform.GetChild(4).GetChild(i).gameObject.SetActive(true);
        }
        jansang1 = false;
        jansang2 = false;
        jansang3 = false;
        jansang4 = false;
    }

    private void OnDisable()
    {
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
