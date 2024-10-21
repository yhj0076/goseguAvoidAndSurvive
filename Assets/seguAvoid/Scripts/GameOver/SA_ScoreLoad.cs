using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SA_ScoreLoad : MonoBehaviour
{
    public GameObject Ending;

    public Text score;
    public Text Rank;
    public Text DeveloperTalk;
    public Text BESTScore;

    public int D;
    public int C;
    public int B;
    public int A;
    public int S;
    public int SS;
    public int SSS;
    // Start is called before the first frame update
    void Start()
    {
        int LastScore = SecurityPlayerPrefs.GetInt("LastScore",-1);
        int BestScore = SecurityPlayerPrefs.GetInt("BestScore",-1);
        score.text = "점수 : " + LastScore;
        BESTScore.text = "최고점수 : " + BestScore;

        if(LastScore >= D && LastScore < C)
        {
            Rank.text = "D";
            DeveloperTalk.text = "어...나쁘지 않았다..";
        }
        else if(LastScore >= C && LastScore < B)
        {
            Rank.text = "C";
            DeveloperTalk.text = "나름 선방했다!";
        }
        else if (LastScore >= B && LastScore < A)
        {
            Rank.text = "B";
            DeveloperTalk.text = "오!! 이게 되네!!";
        }
        else if (LastScore >= A && LastScore < S)
        {
            Rank.text = "A";
            DeveloperTalk.text = "거의 다 왔다..!!";
        }
        else if (LastScore >= S && LastScore < SS)
        {
            Rank.text = "S";
            DeveloperTalk.text = "쿵쾅쿵광 달려라!!";
        }
        else if (LastScore >= SS && LastScore < SSS)
        {
            Rank.text = "SS";
            DeveloperTalk.text = "해냈다~ 해냈어~";
        }
        else if (LastScore >= SSS)
        {
            Rank.text = "SSS";
            DeveloperTalk.text = "나이스 킹~아!! ^ㅁ^ㅁ^ㅁ^ㅁ^";
        }
        else if (LastScore == 107)
        {
            Rank.text = "F";
            DeveloperTalk.text = "어떻게 사람 점수가 107? ㅋㅋㅋㅋㅋ";
        }
        else
        {
            Rank.text = "F";
            DeveloperTalk.text = "에반데";
        }

        if(BestScore >= SS)
        {
            Ending.SetActive(true);
        }
    }
}
