using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSESoundManager : MonoBehaviour
{
    private static MenuSESoundManager instance;

    public AudioClip OK;
    public AudioClip Cancel;
    public AudioClip Click;
    public AudioClip GameStart;
    public AudioClip Money;
    public AudioClip NewCard;
    public AudioClip Win;
    public AudioClip Lose;

    AudioSource audioSource;

    public static MenuSESoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                var manager = GameObject.Find("MenuSESoundManager");
                instance = manager.GetComponent<MenuSESoundManager>();
            }
            return instance;
        }
    }

    private void Start()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += ApplyVolume;
        IsMenuMode = true;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        if (this == Instance) instance = null;
    }

    void ApplyVolume(Scene next, LoadSceneMode mode)
    {
        ApplyVolume();
    }

    public void ApplyVolume()
    {
        if (IsMenuMode)
        {
            audioSource.volume = SettingSceneControl.SEVolume;
        }
        else
        {
            audioSource.volume = 0;
        }
    }

    bool IsMenuMode;

    public void StopSE()
    {
        IsMenuMode = false;
        audioSource.volume = 0;
    }

    public void StartSE()
    {
        IsMenuMode = true;
        audioSource.volume = SettingSceneControl.SEVolume;
    }

    public void PlayOK()
    {
        audioSource.PlayOneShot(OK);
    }

    public void PlayCancel()
    {
        audioSource.PlayOneShot(Cancel);
    }

    public void PlayClick()
    {
        audioSource.PlayOneShot(Click);
    }

    public void PlayGameStart()
    {
        audioSource.PlayOneShot(GameStart);
    }

    public void PlayGacha()
    {
        audioSource.PlayOneShot(Money);
    }

    public void PlayMoney()
    {
        audioSource.PlayOneShot(Money);
    }

    public void PlayNewCard()
    {
        audioSource.PlayOneShot(NewCard);
    }

    public void PlayWin()
    {
        audioSource.PlayOneShot(Win);
    }

    public void PlayLose()
    {
        audioSource.PlayOneShot(Lose);
    }
}
