using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LabResearchResultUIManager : MonoBehaviour
{
    private MagicCard conductedResearch;

    [SerializeField]
    private GameObject researchResult;
    [SerializeField]
    private GameObject dogTag;
    [SerializeField]
    private GameObject labResearchResult;

    #region
    private void Start()
    {
        MenuSESoundManager.Instance.PlayNewCard();
        conductedResearch = SceneBridge.ReceiveData("ConductedResearch") as MagicCard;
        ZukanDataPrefs.Load();
        if(conductedResearch is MagicTypeCard magicType)
        {
            ZukanDataPrefs.FoundCore[magicType.CardName] = true;
        }
        if (conductedResearch is PowerUpCard powerType)
        {
            ZukanDataPrefs.FoundCell[powerType.CardName] = true;
        }
        ZukanDataPrefs.Save();
        DegitalCardPlayer.GetDegitalCardPlayer().GetCardStore().AddCard(conductedResearch);
        CardStore.Save(DegitalCardPlayer.GetDegitalCardPlayer().GetCardStore());
        LoadResearchResult();
        LoadDogTag();
        
        var pack = SceneBridge.ReceiveData("ConductedResearch_Pack") as CardPack;
        
        var magicCard = SceneBridge.ReceiveData("ConductedResearch") as MagicCard;
    }

    // �J�[�h�f�[�^��ǂݍ��ށB
    private void LoadResearchResult()
    {
        // �������t���[���ɔ��f������ꍇ�A���̏������ǉ�����\��B
        researchResult.transform.Find("Photograph Mask").Find("Photograph").GetComponent<Image>().sprite = conductedResearch.GetIcon();
    }

    // �J�[�h��ID�A���́A��ǂݍ��ށB
    private void LoadDogTag()
    {
        dogTag.transform.Find("Name").GetComponent<Text>().text = conductedResearch.CardName;
    }
    #endregion

    public void ToResearchSelection()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Lab Research Selection/Lab Research Selection");
    }

    public void ToDatabase()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Zukan/Zukan");
    }

    public void ToMenu()
    {
        MenuSESoundManager.Instance.PlayCancel();
        SceneManager.LoadScene("Project/Menu/Menu");
    }

    public void ToCardShop()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Card Shop/CardShopHub");
    }

    public void ToLabResearchResult()
    {
        SceneBridge.SendData("Lab Research Result", "ConductedResearch", GachaSystem.Play(SceneBridge.ReceiveData("ConductedResearch_Pack") as CardPack));
        SceneBridge.SendData("Lab Research Result", "ConductedResearch_Pack", SceneBridge.ReceiveData("ConductedResearch_Pack"));
        SceneManager.LoadScene("Project/Lab Research Result/Lab Research Result");
    }
}
