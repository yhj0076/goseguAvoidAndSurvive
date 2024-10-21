using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SA_SettingOn : MonoBehaviour
{
    public static SA_SettingOn instance;

    public GameObject Setting;
    public AudioMixer masterMixer;
    public Slider audioSlider1;
    public Slider audioSlider2;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("씬에 두 개 이상의 세팅 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (SecurityPlayerPrefs.GetFloat("volumeControl_BGM", -1) == -1)
        {
            SecurityPlayerPrefs.SetFloat("volumeControl_BGM", audioSlider1.value);
        }
        else
        {
            if (audioSlider1 != null)
            {
                audioSlider1.value = SecurityPlayerPrefs.GetFloat("volumeControl_BGM", -1);
            }
        }

        if (SecurityPlayerPrefs.GetFloat("volumeControl_SFX", -1) == -1)
        {
            SecurityPlayerPrefs.SetFloat("volumeControl_SFX", audioSlider2.value);
        }
        else
        {
            if (audioSlider2 != null)
            {
                audioSlider2.value = SecurityPlayerPrefs.GetFloat("volumeControl_SFX", -1);
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Setting.activeSelf)
            {
                SetOFF();
            }
            else
            {
                SetON();
            }
        }
    }

    public void SetON()
    {
        Setting.SetActive(true);
    }

    public void SetOFF()
    {
        Setting.SetActive(false);
    }

    public void AudioControlBGM()
    {
        SecurityPlayerPrefs.SetFloat("volumeControl_BGM", audioSlider1.value);
        if (SecurityPlayerPrefs.GetFloat("volumeControl_BGM",0) == -40f)
        {
            masterMixer.SetFloat("BGM", -80);
        }
        else
        {
            masterMixer.SetFloat("BGM", SecurityPlayerPrefs.GetFloat("volumeControl_BGM", 0));
        } 
    }

    public void AudioControlSFX()
    {
        SecurityPlayerPrefs.SetFloat("volumeControl_SFX", audioSlider2.value);
        if (SecurityPlayerPrefs.GetFloat("volumeControl_SFX", 0) == -40f)
        {
            masterMixer.SetFloat("SFX", -80);
        }
        else
        {
            masterMixer.SetFloat("SFX", SecurityPlayerPrefs.GetFloat("volumeControl_SFX", 0));
        }
    }

    public void OnDropdownEvent(int index)
    {
        switch (index)
        {
            case 4:
                Screen.SetResolution(640,360,false);
                break;
            case 3:
                Screen.SetResolution(960, 540, false);
                break;
            case 2:
                Screen.SetResolution(1280, 720, false);
                break;
            case 1:
                Screen.SetResolution(1600, 900, false);
                break;
            case 0:
                Screen.SetResolution(1920, 1080, false);
                break;
        }
    }
}
