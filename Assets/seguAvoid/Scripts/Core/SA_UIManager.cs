using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SA_UIManager : MonoBehaviour
{
    public static SA_UIManager instance;
    public Image healthBar;
    public Text scoreText;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("씬에 두 개 이상의 UI 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    public void Health(int HP)  // 플레이어의 체력
    {
        healthBar.fillAmount = HP / 100f;
    }

    public void Score(int score)
    {
        scoreText.text = score+"/13";
    }
}
