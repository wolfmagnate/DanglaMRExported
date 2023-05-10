using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FundsBoardController : MonoBehaviour
{
    #region
    private void Start()
    {
        LoadBalance();
    }

    private void LoadBalance()
    {
        var funds = DegitalCardPlayer.GetDegitalCardPlayer().GetMoneyManager();
        transform.Find("Balance").GetComponent<Text>().text = $"$ {funds.Money.ToString()}";
    }
    #endregion
}