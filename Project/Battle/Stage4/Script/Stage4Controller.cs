using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hologla;
using UnityEngine.SceneManagement;

public class Stage4Controller : StageControl
{
    int KillCount = 0;
    public PlayerStatus helpPointStatus { get; private set; }
    public EnemyPointStatus enemyPointStatus { get; private set; }

    public void AddKillCounter()
    {
        KillCount++;
        Score += 90f / 39f;
    }

    protected override void StartMethod()
    {
        helpPointStatus = GameObject.FindGameObjectWithTag("HelpPoint").GetComponent<PlayerStatus>();
        enemyPointStatus = GameObject.FindGameObjectWithTag("EnemyHelpPoint").GetComponent<EnemyPointStatus>();
    }

    protected override void UpdateMethod()
    {
        if (enemyPointStatus.HP <= 0)
        {
            HasWin = true;
        }
    }

    protected override bool CheckDefeated() => helpPointStatus.HP <= 0 || playerStatus.HP <= 0 || playerStatus.MP < ShootPlayer.usingMagic.MP;

    protected override void WinMethod()
    {
        Score += 90;
        ResultSceneControl.Score = Mathf.RoundToInt(Score);
        ResultSceneControl.HasWin = true;
        ResultSceneControl.Kill = KillCount;
        ResultSceneControl.PreviousStageNumber = 4;
        SceneManager.LoadScene("Project/Result/Result");
    }

    protected override void LoseMethod()
    {
        ResultSceneControl.Score = Mathf.RoundToInt(Score);
        ResultSceneControl.HasWin = false;
        ResultSceneControl.Kill = KillCount;
        ResultSceneControl.PreviousStageNumber = 4;
        SceneManager.LoadScene("Project/Result/Result");
    }
}
