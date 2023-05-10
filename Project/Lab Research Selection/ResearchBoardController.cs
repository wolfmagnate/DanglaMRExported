using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResearchBoardController : MonoBehaviour
{
    [SerializeField]
    private CardPack displayResearch;

    #region
    private void Start()
    {
        LoadResearchCost();
    }

    private void LoadResearchCost()
    {
        transform.Find("Research Cost").GetComponent<Text>().text = $"$ {displayResearch.Price}";

        var fundsShortage = transform.Find("Funds Shortage").gameObject;
        var funds = DegitalCardPlayer.GetDegitalCardPlayer().GetMoneyManager();
        fundsShortage.SetActive(!funds.CanPay(displayResearch.Price));
    }
    #endregion

    public void ShowDetail()
    {

    }

    // ÉKÉ`ÉÉÇà¯Ç≠ÅB
    public void ConductResearch()
    {
        SceneBridge.SendData("Lab Research Result", "ConductedResearch", GachaSystem.Play(displayResearch));
        SceneBridge.SendData("Lab Research Result", "ConductedResearch_Pack", displayResearch);
        MenuSESoundManager.Instance.PlayGacha();
        GameObject.Find("Movie UI").GetComponent<LabResearchMovie>().StartMovie(displayResearch.PackName);
    }
}