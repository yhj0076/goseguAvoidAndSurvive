using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*      들어가는 장애물들

0. 화면이 거꾸로라 불편하신가요?
1. ㅔㅔㅔ with 비챤
2. 아잇 개 with 징버거
3. 눼눼
4. 마시마싯는
5. 즙나기
6. 닥터고
7. 나대지마
8. 원칩
9. 잔상입니다만
10. 무7련
11. 피아올많
12. 오렌지 오렌지(관 각)



추가되었으면 하는 것
* 나만 봄 신기전
* 트리가드
* 세구야 사랑해 with 아이네
* 실버버튼(추가 확정)
* 별주부전 하이라이트
* 군대컨텐츠(이건 방송을 봐야할 듯?)
* 허숙희...? (이건 논란이 있을 지도...)
* 도박
* 오징어게임 입밴
 */

public class SA_StageManager : MonoBehaviour
{
    public static SA_StageManager instance;

    int nowStage = 1;
    int choice = 0;

    public GameObject Player;
    // public bool hit = false;
    public int score = 0;
    public bool end = false;
    AudioSource soundPlayer;
    public GameObject SoundPlayer;
    public AudioClip doctorGo;

    public string NowPattern = "NULL";

    GameObject soundManager;
    public GameObject cam;
    public GameObject Added;
    public int isSpinned = 0;
    //bool isScoreGiven = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            soundManager = GameObject.Find("SoundManager");
            if(soundManager == null)
            {
                GameObject.Instantiate(SoundPlayer, Vector3.zero, Quaternion.identity);
                soundManager = GameObject.Find("SoundManager(Clone)");
                choice = 0;
            }
            else
            {
                soundManager.SetActive(true);
            }
        }
        else
        {
            Debug.LogError("씬에 두 개 이상의 스테이지 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    public enum STAGE_STATE
    {
        SS_NONE,    // 아무것도 아님
        SS_THINK,   // 생각중
        SS_DO       // 실행중
    }

    public STAGE_STATE state
    {
        get;
        set;
    }

    private void OnEnable()
    {
        state = STAGE_STATE.SS_NONE;
        //hit = true;
        isSpinned = 0;
    }

    private void OnDisable()
    {
        for(int i = 0; i<13 ;i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        Think();
        WhenStageEnd();
    }

    void Think()
    {
        
        if (state == STAGE_STATE.SS_THINK)
        {
            if (Random.Range(0, 4) == 0&&nowStage!=0)
            {
                nowStage = 0;
            }
            else
            {
                choice++;
                nowStage = choice;
            }
            switch (nowStage)
            {
                case 0:
                    NowPattern = "고정관념";
                    break;
                case 1:
                    NowPattern = "ㅔ? ㅔ? ㅔ?";
                    break;
                case 2:
                    NowPattern = "아잇 개";
                    break;
                case 3:
                    NowPattern = "눼눼";
                    break;
                case 4:
                    NowPattern = "마시마싯는";
                    break;
                case 5:
                    NowPattern = "즙나기";
                    break;
                case 6:
                    NowPattern = "닥터 고";
                    break;
                case 7:
                    NowPattern = "나대지마";
                    break;
                case 8:
                    NowPattern = "원칩";
                    break;
                case 9:
                    NowPattern = "잔상입니다만";
                    break;
                case 10:
                    NowPattern = "무7련";
                    break;
                    // 여기서부터 추가된 스테이지
                case 11:
                    NowPattern = "피아올많";
                    break;
                case 12:
                    NowPattern = "오렌지";
                    break;
                default:
                    Debug.LogError("계산 초과");
                    break;
            }
            transform.GetChild(nowStage).gameObject.SetActive(true);
            if(nowStage == 5)
            {
                soundManager.GetComponent<SA_SoundManager>().musicDown_Zero();
            }
            else
            {
                soundManager.GetComponent<SA_SoundManager>().musicDown();
            }
            state = STAGE_STATE.SS_DO;
            if(nowStage == 0&& choice == 0)
            {
                SA_UIManager.instance.Score(1);
            }
            else
            {
                SA_UIManager.instance.Score(choice);
            }
        }
    }

    void WhenStageEnd()
    {
        if(state == STAGE_STATE.SS_NONE)
        {
            StartCoroutine("WasPlayerHurt");
        }
    }

    IEnumerator WasPlayerHurt()
    {
        //if (hit == false && isScoreGiven == false)
        //{
        //    // 100점 추가
        //    //Invoke("AddScore",2);
        //    if (beforeIndex != 3)
        //    {
        //        AddScore();
        //    }
        //    if(beforebeforeIndex == 3)
        //    {
        //        AddScore();
        //    }
        //}
        if (isSpinned == 0)
        {
            cam.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        soundManager.GetComponent<SA_SoundManager>().musicBack();
        yield return new WaitForSeconds(5);
        if(isSpinned > 0)
        {
            isSpinned = isSpinned - 1;
        }
        //hit = false;
        state = STAGE_STATE.SS_THINK;
        StopCoroutine("WasPlayerHurt");
    }

    void hundred()
    {
        score += 100;
        Added.SetActive(true);
    }
}
