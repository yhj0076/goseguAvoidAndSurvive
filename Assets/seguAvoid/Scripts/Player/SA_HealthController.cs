using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SA_HealthController : MonoBehaviour
{
    public GameObject cam;
    public GameObject stage;
    GameObject BGM;

    public int Maxhealth;
    int health;

    AudioSource soundManager;
    public enum PLAYER_STATE
    {
        PS_NONE,
        PS_POWWWER,
        PS_DIE
    }

    public PLAYER_STATE state
    {
        get;
        private set;
    }

    private void Start()
    {
        health = Maxhealth;
        soundManager = GetComponent<AudioSource>();
        BGM = GameObject.Find("SoundManager");
        if (BGM == null)
        {
            BGM = GameObject.Find("SoundManager(Clone)");
        }
    }

    private void Update()
    {
        if(health>Maxhealth)
        {
            health = Maxhealth;
        }
    }

    public void Damaged(int power)
    {
        if (state != PLAYER_STATE.PS_POWWWER)
        {
            //StageManager_SA.instance.hit = true;
            state = PLAYER_STATE.PS_POWWWER;
            health -= power;
            SA_UIManager.instance.Health(health);
            if (health <= 0)
            {
                if (Random.Range(0,3) == 0)
                {
                    //부활
                    BGM.GetComponent<SA_SoundManager>().pauseMusic();
                    soundManager.Play();
                    transform.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                    stage.SetActive(false);
                    Invoke("revive", 10);
                }
                else
                {
                    SA_StageManager.instance.StopCoroutine("WasPlayerHurt");
                    state = PLAYER_STATE.PS_DIE;
                    SecurityPlayerPrefs.SetInt("LastScore", SA_StageManager.instance.score);
                    if (SA_StageManager.instance.score > SecurityPlayerPrefs.GetInt("BestScore", -1))
                    {
                        SecurityPlayerPrefs.SetInt("BestScore", SA_StageManager.instance.score);
                    }
                    Die();
                }
            }
            StartCoroutine("hurtEffect");
            Invoke("EffectComeback", 1);
        }
    }

    void revive()
    {
        Debug.Log("댕같이 부활");
        health = 50;
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        transform.position = new Vector3(0, -3, 0);
        state = PLAYER_STATE.PS_NONE;
        SA_UIManager.instance.Health(health);
        BGM.GetComponent<SA_SoundManager>().playMusic();
        GameObject.Find("Main Camera").GetComponent<SA_CamShake>().Shake = false;
        if (SA_StageManager.instance.isSpinned > 0)
        {
            SA_StageManager.instance.isSpinned = 0;
        }
        stage.SetActive(true);
    }

    IEnumerator hurtEffect()
    {
        transform.GetComponent<SpriteRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.03f);
        transform.GetComponent<SpriteRenderer>().material.color = Color.gray;
    }
    void EffectComeback()
    {
        state = PLAYER_STATE.PS_NONE;
        transform.GetComponent<SpriteRenderer>().material.color = Color.white;
    }

    public void Heal(int power)
    {
        health += power;
        SA_UIManager.instance.Health(health);        
    }

    public void Die()
    {
        SA_GameManager.instance.GameOver();
    }
}
