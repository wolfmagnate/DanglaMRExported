using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hologla;
using UnityEngine.SceneManagement;


public class Stage14SceneControl : StageControl
{
    int KillCount = 0;
    public PlayerStatus helpPointStatus { get; private set; }
    public EnemyPointStatus enemyPointStatus { get; private set; }

    public void AddKillCounter()
    {
        KillCount++;
        Score += 400000f / 39f;
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

    protected override bool CheckDefeated()
    {
        return helpPointStatus.HP <= 0;
    }

    protected override void WinMethod()
    {
        Score += 400000;
        ResultSceneControl.Score = Mathf.RoundToInt(Score);
        ResultSceneControl.HasWin = true;
        ResultSceneControl.Kill = KillCount;
        ResultSceneControl.PreviousStageNumber = 14;
        SceneManager.LoadScene("Project/Result/Result");
    }

    protected override void LoseMethod()
    {
        ResultSceneControl.Score = Mathf.RoundToInt(Score);
        ResultSceneControl.HasWin = false;
        ResultSceneControl.Kill = KillCount;
        ResultSceneControl.PreviousStageNumber = 14;
        SceneManager.LoadScene("Project/Result/Result");
    }
}
