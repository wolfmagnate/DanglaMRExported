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
        {1, "�����E�C���X��\n�S�����j���悤" },
        {2, "2�̖h�q���_����낤" },
        {3, "���ԓ���30�̂�\n�E�C���X�����j���悤" },
        {4, "�����̋��_������\n�G�̋��_��HP��0�ɂ��悤" },
        {5, "�E�C���X�o�X�^�[��\n�h���[�������j���悤" },
        {6, "�����E�C���X��\n�S�����j���悤" },
        {7, "2�̖h�q���_����낤" },
        {8, "���ԓ���30�̂�\n�E�C���X�����j���悤" },
        {9, "�����̋��_������\n�G�̋��_��HP��0�ɂ��悤" },
        {10, "�E�C���X�o�X�^�[��\n�h���[�������j���悤" },
        {11, "�����E�C���X��\n�S�����j���悤" },
        {12, "2�̖h�q���_����낤" },
        {13, "���ԓ���30�̂�\n�E�C���X�����j���悤" },
        {14, "�����̋��_������\n�G�̋��_��HP��0�ɂ��悤" },
        {15, "�E�C���X�o�X�^�[��\n�h���[�������j���悤" },
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
