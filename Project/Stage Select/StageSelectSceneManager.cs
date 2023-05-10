using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectSceneManager : MonoBehaviour
{
    private int SelectedStage = -1;

    private static readonly Dictionary<int, string> StageAdvices = new Dictionary<int, string>()
    {
        {1, "現れるウイルスを\n全員撃破しよう" },
        {2, "2つの防衛拠点を守ろう" },
        {3, "時間内に30体の\nウイルスを撃破しよう" },
        {4, "自分の拠点を守りつつ\n敵の拠点のHPを0にしよう" },
        {5, "ウイルスバスターの\nドローンを撃破しよう" },
        {6, "現れるウイルスを\n全員撃破しよう" },
        {7, "2つの防衛拠点を守ろう" },
        {8, "時間内に30体の\nウイルスを撃破しよう" },
        {9, "自分の拠点を守りつつ\n敵の拠点のHPを0にしよう" },
        {10, "ウイルスバスターの\nドローンを撃破しよう" },
        {11, "現れるウイルスを\n全員撃破しよう" },
        {12, "2つの防衛拠点を守ろう" },
        {13, "時間内に30体の\nウイルスを撃破しよう" },
        {14, "自分の拠点を守りつつ\n敵の拠点のHPを0にしよう" },
        {15, "ウイルスバスターの\nドローンを撃破しよう" },
    };

    void Start()
    {
        int allowedLevel = FlagManager.StageFlag();
        for(int i = 0;i < allowedLevel; i++)
        {
            GameObject buttonParent = GameObject.Find($"To Stage {i+1}");
            var number = buttonParent.transform.Find("Body/Number").gameObject;
            number.SetActive(true);
            int a = i;
            number.GetComponent<Button>().onClick.AddListener(()=> { MenuSESoundManager.Instance.PlayOK(); SelectedStage = a + 1; GameObject.Find("To Battle").SetActive(true); });
            buttonParent.transform.Find("Body/Accessor").gameObject.SetActive(false);
            buttonParent.transform.Find("Body/Base").gameObject.GetComponent<Button>().enabled = false;
        }
    }

    public void GoToBattleScene()
    {
        SceneManager.sceneLoaded += OnNext;
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Battle/Loading/BattleLoading");
    }

    public void OnNext(Scene next, LoadSceneMode mode)
    {
        Debug.Log($"Project/Battle/Stage{SelectedStage}/Stage{SelectedStage}");
        GameObject.Find("Canvas").GetComponent<BattleLoadingSceneControl>().SetInformation($"Project/Battle/Stage{SelectedStage}/Stage{SelectedStage}", StageAdvices[SelectedStage]);
        SceneManager.sceneLoaded -= OnNext;
    }
}
