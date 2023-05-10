using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EyeMode
{
    AR,MR1,MR2
}

public class SettingSceneControl : MonoBehaviour
{
    static readonly string BGMVolumeKey = "kjdri5409fneh30refdnhnq0t";
    static readonly string SEVolumeKey = "iuciet09injonenfn0q_3nkkdb";
    static readonly string IPDKey = "ojnhugfy6u7ip8yhbiufcdsedrwt";
    static readonly string EyeModeKey = "okaednczlkew890z4qdtrrokmls";

    public static EyeMode eyeMode { get; private set; } = EyeMode.AR;
    public static float BGMVolume { get; set; } = 1;
    public static float SEVolume { get; set; } = 1;
    public static float IPD { get; private set; } = 65;
    Toggle ARToggle;
    Toggle MRToggle1;
    Toggle MRToggle2;
    Slider BGMSlider;
    Slider SESlider;

    MenuBGMSoundManager BGMSoundManager;
    MenuSESoundManager SESoundManager;

    // Start is called before the first frame update
    void Start()
    {
        ARToggle = transform.Find("EyeMode/ARToggle").GetComponent<Toggle>();
        MRToggle1 = transform.Find("EyeMode/MRToggle1").GetComponent<Toggle>();
        MRToggle2 = transform.Find("EyeMode/MRToggle2").GetComponent<Toggle>();
        SESlider = transform.Find("SEVolume").GetComponent<Slider>();
        BGMSlider = transform.Find("BGMVolume").GetComponent<Slider>();
        Load();
        if(eyeMode == EyeMode.AR)
        {
            ARToggle.isOn = true;
        }
        if(eyeMode == EyeMode.MR1)
        {
            MRToggle1.isOn = true;
        }
        if (eyeMode == EyeMode.MR2)
        {
            MRToggle2.isOn = true;
        }
        SESlider.value = SEVolume;
        BGMSlider.value = BGMVolume;

        transform.Find("IPD/Number").GetComponent<Text>().text = $"{IPD}";

        transform.Find("IPD/Down").gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            SESoundManager.PlayClick();
            IPD -= 0.5f;
            transform.Find("IPD/Number").GetComponent<Text>().text = $"{IPD}";
        });
        transform.Find("IPD/Up").gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            SESoundManager.PlayClick();
            IPD += 0.5f;
            transform.Find("IPD/Number").GetComponent<Text>().text = $"{IPD}";
        });

        BGMSoundManager = MenuBGMSoundManager.Instance;
        SESoundManager = MenuSESoundManager.Instance;
    }

    public void BGMVolumeChange()
    {
        BGMVolume = BGMSlider.value;
        if(BGMSoundManager != null)
        {
            BGMSoundManager.ApplyVolume();
        }
        Save();
    }

    public void SEVolumeChange()
    {
        SEVolume = SESlider.value;
        if(SESoundManager != null)
        {
            SESoundManager.ApplyVolume();
        }
        Save();
    }

    public void EyeChangeAR()
    {
        MenuSESoundManager.Instance.PlayClick();
        eyeMode = EyeMode.AR;
        Save();
    }
    public void EyeChangeMR1()
    {
        MenuSESoundManager.Instance.PlayClick();
        eyeMode = EyeMode.MR1;
        Save();
    }
    public void EyeChangeMR2()
    {
        MenuSESoundManager.Instance.PlayClick();
        eyeMode = EyeMode.MR2;
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetFloat(BGMVolumeKey, BGMSlider.value);
        PlayerPrefs.SetFloat(SEVolumeKey, SESlider.value);
        PlayerPrefs.SetInt(EyeModeKey, (int)eyeMode);
        PlayerPrefs.SetFloat(IPDKey, IPD);
    }

    public static void Load()
    {
        if (PlayerPrefs.HasKey(BGMVolumeKey))
        {
            BGMVolume = PlayerPrefs.GetFloat(BGMVolumeKey);
        }
        if (PlayerPrefs.HasKey(SEVolumeKey))
        {
            SEVolume = PlayerPrefs.GetFloat(SEVolumeKey);
        }
        if (PlayerPrefs.HasKey(EyeModeKey))
        {
            eyeMode = (EyeMode)PlayerPrefs.GetInt(EyeModeKey);
        }
        if (PlayerPrefs.HasKey(IPDKey))
        {
            IPD = PlayerPrefs.GetFloat(IPDKey);
        }
    }
}
