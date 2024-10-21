﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_raindrop : MonoBehaviour
{
    public GameObject tear;
    public GameObject Player;
    public GameObject OB;

    AudioSource soundPlayer;

    float time = 0;
    float time2 = 0;

    public float[] onTime;
    public GameObject[] words;
    public bool[] created;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 13 && time < 25)
        {
            time2 += Time.deltaTime;
            if (time2 > 0.1f)
            {
                float RandX = Random.Range(-8.5f, 8.5f);
                var crying = Instantiate(tear, new Vector2(RandX, transform.position.y), Quaternion.identity);
                time2 = 0;
            }
        }

        if (time >= onTime[0] && time < onTime[1] && created[0])
        {
            var createWord = Instantiate(words[0],new Vector2(Player.transform.position.x, 5.6f),Quaternion.identity);
            created[0] = false;
        }
        else if (time >= onTime[1] && time < onTime[2] && created[1])
        {
            var createWord = Instantiate(words[1], new Vector2(Player.transform.position.x, 5.6f), Quaternion.identity);
            created[1] = false;
        }
        else if (time >= onTime[2] && time < onTime[3] && created[2])
        {
            var createWord = Instantiate(words[2], new Vector2(Player.transform.position.x, 5.6f), Quaternion.identity);
            created[2] = false;
        }
        else if (time >= onTime[3] && time < onTime[4] && created[3])
        {
            created[3] = false;
            var createWord = Instantiate(words[3], new Vector2(Player.transform.position.x, 5.6f), Quaternion.identity);
        }
        else if (time >= onTime[4] && time < onTime[5] && created[4])
        {
            created[4] = false;
            var createWord = Instantiate(words[4], new Vector2(Player.transform.position.x, 5.6f), Quaternion.identity);
        }
        else if (time >= onTime[5] && time < onTime[6] && created[5])
        {
            created[5] = false;
            var createWord = Instantiate(words[5], new Vector2(Player.transform.position.x, 5.6f), Quaternion.identity);
        }
        else if (time >= onTime[6] && time < onTime[7] && created[6])
        {
            created[6] = false;
            var createWord = Instantiate(words[6], new Vector2(Player.transform.position.x, 5.6f), Quaternion.identity);
        }
        else if (time >= onTime[7] && time < onTime[8] && created[7])
        {
            created[7] = false;
            var createWord = Instantiate(words[7], new Vector2(Player.transform.position.x, 5.6f), Quaternion.identity);
        }
        else if (time >= onTime[8] && time < onTime[9] && created[8])
        {
            created[8] = false;
            var createWord = Instantiate(words[8], new Vector2(Player.transform.position.x, 5.6f), Quaternion.identity);
        }
        else if (time >= onTime[9] && time < onTime[10] && created[9])
        {
            created[9] = false;
            var createWord = Instantiate(words[9], new Vector2(Player.transform.position.x, 5.6f), Quaternion.identity);
        }
        else if (time >= onTime[10] && created[10])
        {
            created[10] = false;
            var createWord = Instantiate(words[10], new Vector2(Player.transform.position.x, 5.6f), Quaternion.identity);
        }

        if (soundPlayer.isPlaying == false)
        {
            gameObject.SetActive(false);
        }

    }

    private void OnEnable()
    {
        OB.GetComponent<SA_OutOfBound>().DamageOn = false;
        soundPlayer = GetComponent<AudioSource>();
        time = 0;
        time2 = 0;
        soundPlayer.Play();
        for(int i = 0;i<6;i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);   // 응원봉 on
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < 6; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);  // 응원봉 off
        }
        for(int j = 0; j < 11;j++)
        {
            created[j] = true;
        }
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
