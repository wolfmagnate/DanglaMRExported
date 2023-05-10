using Hologla;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage12SceneControl : StageControl
{
    GameObject[] HelpPoints;
    int KillCount = 0;

    // Start is called before the first frame update
    protected override void StartMethod()
    {
        HelpPoints = GameObject.FindGameObjectsWithTag("HelpPoint");
    }
    public void AddKillCounter()
    {
        KillCount++;
        Score += 100000f / 30f;
    }

    protected override void UpdateMethod()
    {
    }

    protected override bool CheckDefeated()
    {
        if (playerStatus.HP <= 0 || playerStatus.MP < ShootPlayer.usingMagic.MP)
        {
            return true;
        }
        foreach (var x in HelpPoints)
        {
            if (x.GetComponent<PlayerStatus>().HP <= 0)
            {
                return true;
            }
        }
        return false;
    }

    protected override void WinMethod()
    {
        Score += 100000;
        ResultSceneControl.Score = Mathf.RoundToInt(Score);
        ResultSceneControl.HasWin = true;
        ResultSceneControl.Kill = KillCount;
        ResultSceneControl.PreviousStageNumber = 12;
        SceneManager.LoadScene("Project/Result/Result");
    }

    protected override void LoseMethod()
    {
        ResultSceneControl.Score = Mathf.RoundToInt(Score);
        ResultSceneControl.HasWin = false;
        ResultSceneControl.Kill = KillCount;
        ResultSceneControl.PreviousStageNumber = 12;
        SceneManager.LoadScene("Project/Result/Result");
    }
}
