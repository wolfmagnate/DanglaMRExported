using UnityEngine;
using UnityEngine.UI;
using Hologla;
using UnityEngine.SceneManagement;

public class Stage11SceneControl : StageControl
{
    protected override void StartMethod() { }

    private int KillCount = 0;
    public void AddKillCounter()
    {
        KillCount++;
        Score += 50000f / 33f;
    }


    protected override void UpdateMethod()
    {

    }

    protected override bool CheckDefeated() => playerStatus.HP <= 0 || playerStatus.HP <= 0 || playerStatus.MP < ShootPlayer.usingMagic.MP;

    protected override void WinMethod()
    {
        Score += 50000;
        ResultSceneControl.Score = Mathf.RoundToInt(Score);
        ResultSceneControl.HasWin = true;
        ResultSceneControl.Kill = KillCount;
        ResultSceneControl.PreviousStageNumber = 11;
        SceneManager.LoadScene("Project/Result/Result");
    }

    protected override void LoseMethod()
    {
        ResultSceneControl.Score = Mathf.RoundToInt(Score);
        ResultSceneControl.HasWin = false;
        ResultSceneControl.Kill = KillCount;
        ResultSceneControl.PreviousStageNumber = 11;
        SceneManager.LoadScene("Project/Result/Result");
    }
}
