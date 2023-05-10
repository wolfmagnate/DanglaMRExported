using Hologla;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class StageControl : MonoBehaviour
{
    protected HologlaCameraManager cameraManager;
    protected PlayerStatus playerStatus;
    protected float Score;
    protected Image HP;
    protected Image MP;
    protected Text ScoreText;
    public bool HasWin { get; set; } = false;
    public bool HasDefeated { get; set; } = false;

    // Start is called before the first frame update
    protected void Start()
    {
        cameraManager = GameObject.Find("HologlaCamera").GetComponent<HologlaCameraManager>();
        cameraManager.SwitchEyeModeSingle();
        if (SettingSceneControl.eyeMode == EyeMode.AR)
        {
            cameraManager.SwitchViewModeAR();
            cameraManager.SwitchEyeModeSingle();
            var canvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }
        if(SettingSceneControl.eyeMode == EyeMode.MR1)
        {
            cameraManager.SwitchViewModeMR();
            cameraManager.SwitchEyeModeSingle();
            var canvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }
        if(SettingSceneControl.eyeMode == EyeMode.MR2)
        {
            cameraManager.SwitchViewModeMR();
            cameraManager.SwitchEyeModeTwo();
            var canvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.worldCamera = GameObject.Find("HologlaCamera").GetComponent<Camera>();
            var canvasTransform = GameObject.Find("UICanvas").transform;
            canvasTransform.localScale = 0.0005f * Vector3.one;
            canvasTransform.position = new Vector3(0, 0, 1.5f);
            GameObject.Find("UICanvas").GetComponent<UICanvasTrack>().StartTrack(GameObject.Find("HologlaCamera").transform);
        }

        cameraManager.ApplyIPD(SettingSceneControl.IPD);

        playerStatus = GameObject.Find("HologlaCamera").GetComponent<PlayerStatus>();
        HP = GameObject.Find("UICanvas/HP/Progress").GetComponent<Image>();
        MP = GameObject.Find("UICanvas/MP/Progress").GetComponent<Image>();
        ScoreText = GameObject.Find("UICanvas/Score").GetComponent<Text>();
        ScoreText.text = $"ScoreÅF{Score}";

        MenuSESoundManager.Instance.StopSE();
        MenuBGMSoundManager.Instance.StopBGM();
        GameObject.Find("BGM").GetComponent<AudioSource>().volume = SettingSceneControl.BGMVolume;

        StartMethod();
    }

    protected abstract void StartMethod();

    protected void Update()
    {
        Display();
        UpdateMethod();
        if (CheckDefeated())
        {
            HasDefeated = true;
        }
        if (HasWin)
        {
            WinMethod();
        }
        if (HasDefeated)
        {
            LoseMethod();
        }
    }

    protected virtual void Display()
    {
        HP.fillAmount = playerStatus.HP / playerStatus.MaxHP;
        MP.fillAmount = playerStatus.MP / playerStatus.MaxMP;
        ScoreText.text = $"ScoreÅF{Score}";
    }
    protected abstract void UpdateMethod();
    protected abstract bool CheckDefeated();
    protected abstract void WinMethod();
    protected abstract void LoseMethod();
}
