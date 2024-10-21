using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SA_Nadaejima : MonoBehaviour
{
    public bool GukJa = false;
    public GameObject gukJaObj1;
    public GameObject gukJaObj2;
    public GameObject cam;
    public GameObject OB;
    public GameObject Siling;
    public GameObject Player;
    AudioSource soundPlayer;
    public AudioClip kkang;

    Vector3 lastCamPos;
    Vector2 camPos;
    float time = 0;
    float stageTime = 0;

    private void OnEnable()
    {
        OB.GetComponent<SA_OutOfBound>().DamageOn = true;
        soundPlayer = GetComponent<AudioSource>();
        time = 2.9f;
        stageTime = 0;
        soundPlayer.Play();
        camPos = cam.transform.position;
        lastCamPos = cam.transform.position;
        GukJa = true;
        Siling.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(soundPlayer.isPlaying == false)
        {
            time += Time.deltaTime;
            stageTime += Time.deltaTime;
        }
        cam.transform.position = new Vector3(cam.transform.position.x,stageTime*1.5f, cam.transform.position.z);
        if(time >= 3)
        {
            int choice = Random.Range(0,2);
            if (choice == 0)
            {
                if (Random.Range(0, 2) == 0)
                {
                    GameObject.Instantiate(gukJaObj1, new Vector2(cam.transform.position.x, cam.transform.position.y), Quaternion.Euler(0, 0, 60));
                }
                else
                {
                    GameObject.Instantiate(gukJaObj1, new Vector2(cam.transform.position.x, cam.transform.position.y), Quaternion.Euler(0, 0, -60));
                }
                
            }
            else
            {
                if (Random.Range(0, 2) == 0)
                {
                    GameObject.Instantiate(gukJaObj2, new Vector2(cam.transform.position.x, cam.transform.position.y), Quaternion.Euler(0, 0, 60));
                }
                else
                {
                    GameObject.Instantiate(gukJaObj2, new Vector2(cam.transform.position.x, cam.transform.position.y), Quaternion.Euler(0, 0, -60));
                }
            }
            time = 0;
        }

        if(stageTime >= 14)
        {
            cam.transform.position = lastCamPos;
            GukJa = false;
            gameObject.SetActive(false);
        }
    }

    

    private void OnDisable()
    {
        OB.GetComponent<SA_OutOfBound>().DamageOn = false;
        Player.transform.position = new Vector2(0, cam.transform.position.y - 3);
        Siling.SetActive(true);
        SA_StageManager.instance.state = SA_StageManager.STAGE_STATE.SS_NONE;
    }
}
