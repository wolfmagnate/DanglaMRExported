using Hologla;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage10SceneControl : StageControl
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
        bossStatus ??= GetComponent<Stage10EnemyGenerator>()?.enemyCash?.GetComponent<EnemyStatusController>();
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
        BossMaxHP = GetComponent<Stage10EnemyGenerator>().enemy.GetComponent<EnemyStatusController>().HP;
    }

    protected override void UpdateMethod()
    {
    }

    protected override bool CheckDefeated() => playerStatus.HP <= 0 || playerStatus.HP <= 0 || playerStatus.MP < ShootPlayer.usingMagic.MP;

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
        ResultSceneControl.PreviousStageNumber = 10;
        SceneManager.LoadScene("Project/Result/Result");
    }

    IEnumerator WinRoutine()
    {
        yield return new WaitForSeconds(10);
        Score = 30000;
        ResultSceneControl.Score = Mathf.RoundToInt(Score);
        ResultSceneControl.HasWin = true;
        ResultSceneControl.Kill = 1;
        ResultSceneControl.PreviousStageNumber = 10;
        SceneManager.LoadScene("Project/Result/Result");
    }
}
