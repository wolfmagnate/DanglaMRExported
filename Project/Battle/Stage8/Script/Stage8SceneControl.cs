using Hologla;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage8SceneControl : StageControl
{
    Image Time;
    Text Kill;
    int KillCounter = 0;

    public void AddKillCounter()
    {
        KillCounter++;
        Score += 100;
    }
    // タイマーを操作する
    IEnumerator Timer()
    {
        int Count = 250;
        while (true)
        {
            Time.fillAmount = Count / 250.0f;
            Count--;
            yield return new WaitForSeconds(1);
            if (Count == 0) { break; }
        }
        HasDefeated = true;
    }

    protected override void StartMethod()
    {
        Time = GameObject.Find("UICanvas/Time/Progress").GetComponent<Image>();
        Kill = GameObject.Find("UICanvas/Kill").GetComponent<Text>();
        StartCoroutine(Timer());
    }

    protected override void Display()
    {
        base.Display();
        Kill.text = $"Kill：{KillCounter}";
    }

    protected override void UpdateMethod()
    {
        if (KillCounter >= 30)
        {
            HasWin = true;
        }
    }

    protected override bool CheckDefeated() => playerStatus.HP <= 0 || playerStatus.MP < ShootPlayer.usingMagic.MP;


    protected override void WinMethod()
    {
        Score += 3000;
        ResultSceneControl.Score = Mathf.RoundToInt(Score);
        ResultSceneControl.HasWin = true;
        ResultSceneControl.Kill = KillCounter;
        ResultSceneControl.PreviousStageNumber = 8;
        SceneManager.LoadScene("Project/Result/Result");
    }

    protected override void LoseMethod()
    {
        ResultSceneControl.Score = Mathf.RoundToInt(Score);
        ResultSceneControl.HasWin = false;
        ResultSceneControl.Kill = KillCounter;
        ResultSceneControl.PreviousStageNumber = 8;
        SceneManager.LoadScene("Project/Result/Result");
    }
}
