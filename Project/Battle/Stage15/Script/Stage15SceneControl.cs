using Hologla;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Stage15SceneControl : StageControl
{
    public void Win()
    {
        HasWin = true;
    }


    protected override void Display()
    {
        HP.fillAmount = playerStatus.HP / playerStatus.MaxHP;
        MP.fillAmount = playerStatus.MP / playerStatus.MaxMP;
        ScoreText.text = $"ScoreÅF{Score}";
        bossStatus ??= GetComponent<Stage15EnemyGenerator>()?.enemyCash?.GetComponent<EnemyStatusController>();
        if (bossStatus != null)
        {
            BossHP.fillAmount = bossStatus.HP / BossMaxHP;
        }
    }


    Image BossHP;
    float BossMaxHP;
    EnemyStatusController bossStatus;
    protected override void StartMethod()
    {
        BossHP = GameObject.Find("UICanvas/BossHP/Progress").GetComponent<Image>();
        BossMaxHP = GetComponent<Stage15EnemyGenerator>().enemy.GetComponent<EnemyStatusController>().HP;
    }

    protected override void UpdateMethod()
    {
    }

    protected override bool CheckDefeated()
    {
        return playerStatus.HP <= 0;
    }

    protected override void WinMethod()
    {
        StartCoroutine(WinRoutine());
    }

    protected override void LoseMethod()
    {
        Score = 0;
        ResultSceneControl.Score = 0;
        ResultSceneControl.HasWin = false;
        ResultSceneControl.Kill = 0;
        ResultSceneControl.PreviousStageNumber = 15;
        SceneManager.LoadScene("Project/Result/Result");
    }

    IEnumerator WinRoutine()
    {
        yield return new WaitForSeconds(10);
        Score = 2000000;
        ResultSceneControl.Score = Mathf.RoundToInt(Score);
        ResultSceneControl.HasWin = true;
        ResultSceneControl.Kill = 1;
        ResultSceneControl.PreviousStageNumber = 15;
        SceneManager.LoadScene("Project/Result/Result");
    }
}
