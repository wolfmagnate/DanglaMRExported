using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hologla;
using UnityEngine.SceneManagement;

public class Stage6SceneControl : StageControl
{
    protected override void StartMethod() { }

    private int KillCount = 0;
    public void AddKillCounter()
    {
        KillCount++;
        Score += 800f / 33f;
    }


    protected override void UpdateMethod()
    {

    }

    protected override bool CheckDefeated() => playerStatus.HP <= 0 || playerStatus.MP < ShootPlayer.usingMagic.MP;

    protected override void WinMethod()
    {
        Score += 1000;
        ResultSceneControl.Score = Mathf.RoundToInt(Score);
        ResultSceneControl.HasWin = true;
        ResultSceneControl.Kill = KillCount;
        ResultSceneControl.PreviousStageNumber = 6;
        SceneManager.LoadScene("Project/Result/Result");
    }

    protected override void LoseMethod()
    {
        ResultSceneControl.Score = Mathf.RoundToInt(Score);
        ResultSceneControl.HasWin = false;
        ResultSceneControl.Kill = KillCount;
        ResultSceneControl.PreviousStageNumber = 6;
        SceneManager.LoadScene("Project/Result/Result");
    }
}
