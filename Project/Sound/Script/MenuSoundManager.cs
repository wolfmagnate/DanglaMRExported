using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSoundManager : MonoBehaviour
{
    private static MenuSoundManager instance;

    public static MenuSoundManager Instance
    {
        get
        {
            if(instance == null)
            {
                var manager = GameObject.FindGameObjectWithTag("MenuSoundManager");
                instance = manager.GetComponent<MenuSoundManager>();
            }
            return instance;
        }
    }

    private void Start()
    {
        if(this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += ApplyVolume;
        IsMenuMode = true;
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
            GetComponent<AudioSource>().volume = SettingSceneControl.BGMVolume;
        }
        else
        {
            GetComponent<AudioSource>().volume = 0;
        }
    }

    bool IsMenuMode;

    public void StopBGM()
    {
        IsMenuMode = false;
        GetComponent<AudioSource>().volume = 0;
    }

    public void StartBGM()
    {
        IsMenuMode = true;
        GetComponent<AudioSource>().volume = SettingSceneControl.BGMVolume;
    }
}
