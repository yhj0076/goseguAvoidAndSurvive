using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_MuSeven : MonoBehaviour
{
    AudioSource soundPlayer;

    bool StageOn = false;
    float time = 0;

    public GameObject Fox;
    public GameObject JRR;
    public GameObject Mu7ryun;
    public GameObject Player;
    public GameObject OB;
    bool fox = false;
    bool jrr = false;
    bool m7r = false;
    private void OnEnable()
    {
        OB.GetComponent<SA_OutOfBound>().DamageOn = false;
        time = 0;
        soundPlayer = GetComponent<AudioSource>();
        soundPlayer.PlayDelayed(1f);
        StageOn = true;
        fox = false;
        jrr = false;
        m7r = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time>=1.3f&&time<2.6f&&fox == false)
        {
            GameObject.Instantiate(Fox, transform.GetChild(0).GetChild(0).position,Quaternion.identity).transform.parent = transform;
            fox = true;
        }
        else if(time>=2.6f&&time<10.2f&&jrr == false)
        {
            GameObject.Instantiate(JRR, transform.GetChild(0).GetChild(0).position, Quaternion.identity).transform.parent = transform;
            jrr = true;
        }
        else if(time>=10.2f&&m7r == false)
        {
            GameObject.Instantiate(Mu7ryun, new Vector2(transform.GetChild(1).GetChild(0).position.x,Player.transform.position.y), Quaternion.identity);
            m7r = true;
        }




        if(StageOn)
        {
            transform.GetChild(0).localPosition = Vector2.Lerp(transform.GetChild(0).localPosition,new Vector2(0,0),0.08f);
            transform.GetChild(1).localPosition = Vector2.Lerp(transform.GetChild(1).localPosition,new Vector2(0.73f,0.44f),0.08f);
        }
        else
        {
            transform.GetChild(0).localPosition = Vector2.Lerp(transform.GetChild(0).localPosition, new Vector2(-12.15f, 0), 0.08f);
            transform.GetChild(1).localPosition = Vector2.Lerp(transform.GetChild(1).localPosition, new Vector2(5.73f, 0.44f), 0.08f);
        }

        if(soundPlayer.isPlaying == false)
        {
            StageOn = false;
            Invoke("delayFalse",0.1f);
        }
    }

    void delayFalse()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        Destroy(transform.GetChild(2).gameObject);
        Destroy(transform.GetChild(3).gameObject);
        transform.GetChild(0).localPosition = new Vector2(-12.15f, 0);
        transform.GetChild(1).localPosition = new Vector2(5.73f, 0.44f);
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
