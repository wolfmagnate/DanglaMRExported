using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceLoader : MonoBehaviour {
    private void Start() {
        if (DegitalCardPlayer.GetDegitalCardPlayer().GetMoneyManager() != null)
            transform.GetChild(1).GetComponent<Text>().text = DegitalCardPlayer.GetDegitalCardPlayer().GetMoneyManager().Money.ToString();
        else
            transform.GetChild(1).GetComponent<Text>().text = "0";
    }
}