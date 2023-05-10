using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultSceneControl : MonoBehaviour
{
    public static bool HasWin = false;
    public static int Kill = 6;
    public static int Score = 256000;
    public static int PreviousStageNumber;

    // Start is called before the first frame update
    void Start()
    {
        MenuBGMSoundManager.Instance.StartBGM();
        MenuSESoundManager.Instance.StartSE();

        Image KillImage(int i) => GameObject.Find($"Kill/Numbers/Image{i}").GetComponent<Image>();
        KillImages = new[] { KillImage(0), KillImage(1) };
        Image ScoreImage(int i) => GameObject.Find($"Score/Numbers/Image{i}").GetComponent<Image>();
        ScoreImages = new[] { ScoreImage(0), ScoreImage(1), ScoreImage(2), ScoreImage(3), ScoreImage(4), ScoreImage(5), ScoreImage(6) };
        StartCoroutine(NumberAnimation());
        if (HasWin)
        {
            MenuSESoundManager.Instance.PlayWin();
            GameObject.Find("WinOrLose").GetComponent<Image>().sprite = Win;
            if(FlagManager.ScenarioFlag() == FlagManager.StageFlag() - 1 && FlagManager.StageFlag() == PreviousStageNumber)
            {
                FlagManager.ChangeScenarioFlag(Mathf.Min(FlagManager.ScenarioFlag() + 1, 15));
            }
        }
        else
        {
            MenuSESoundManager.Instance.PlayLose();
            GameObject.Find("WinOrLose").GetComponent<Image>().sprite = Lose;
        }
    }

    Image[] KillImages;
    Image[] ScoreImages;

    public Sprite Win;
    public Sprite Lose;
    public Sprite[] Numbers;
    public IEnumerator NumberAnimation()
    {
        foreach (var x in ScoreImages)
        {
            x.color = new Color(0, 0, 0, 0);
        }
        // Kill数のアニメーション
        // 数字ガチャガチャ
        for (int i = 0;i < 50; i++)
        {
            foreach(var x in KillImages)
            {
                x.sprite = RandomUtil.GetRandomElement(Numbers);
            }
            yield return new WaitForSeconds(0.03f);
        }
        // 本来の数字の表示
        Kill %= 100;
        string padkill = string.Format("{0:00}", Kill);
        KillImages[0].sprite = Numbers[int.Parse(padkill[0].ToString())];
        KillImages[1].sprite = Numbers[int.Parse(padkill[1].ToString())];
        yield return new WaitForSeconds(0.5f);
        foreach (var x in ScoreImages)
        {
            x.color = new Color(1,1,1,1);
        }
        // Scoreのアニメーション
        // 数字ガチャガチャ
        for (int i = 0; i < 50; i++)
        {
            foreach (var x in ScoreImages)
            {
                x.sprite = RandomUtil.GetRandomElement(Numbers);
            }
            yield return new WaitForSeconds(0.03f);
        }
        // 本来の数字の表示
        Score %= 10_000_000;
        padkill = string.Format("{0:0000000}", Score);
        for(int i = 0;i < 7; i++)
        {
            ScoreImages[i].sprite = Numbers[int.Parse(padkill[i].ToString())];
        }

        MoneyManager manager = MoneyManager.Load();
        manager.Gain(Score);
        MoneyManager.Save(manager);
        yield return new WaitForSeconds(1f);
    }

    public void Retry()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene($"Project/Battle/Stage{PreviousStageNumber}/Stage{PreviousStageNumber}");
    }

    public void Menu()
    {
        MenuSESoundManager.Instance.PlayCancel();
        SceneManager.LoadScene("Project/Menu/Menu");
    }
}
