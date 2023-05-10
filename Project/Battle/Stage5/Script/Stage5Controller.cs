using Hologla;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage5Controller : StageControl
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
        bossStatus ??= GetComponent<Stage5Generator>()?.enemyCash?.GetComponent<EnemyStatusController>();
        if(bossStatus != null)
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
        BossMaxHP = GetComponent<Stage5Generator>().enemy.GetComponent<EnemyStatusController>().HP;
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
        ResultSceneControl.Score = Mathf.RoundToInt(Score);
        ResultSceneControl.HasWin = false;
        ResultSceneControl.Kill = 0;
        ResultSceneControl.PreviousStageNumber = 5;
        SceneManager.LoadScene("Project/Result/Result");
    }

    IEnumerator WinRoutine()
    {
        yield return new WaitForSeconds(10);
        Score = 500;
        ResultSceneControl.Score = Mathf.RoundToInt(Score);
        ResultSceneControl.HasWin = true;
        ResultSceneControl.Kill = 1;
        ResultSceneControl.PreviousStageNumber = 5;
        SceneManager.LoadScene("Project/Result/Result");
    }
}
