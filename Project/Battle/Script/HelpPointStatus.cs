using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpPointStatus : PlayerStatus
{
    private new float MaxHP;
    private GameObject HPCanvas;
    private Image HPBar;
    private GameObject Player;

    private void Start()
    {
        MaxHP = HP;
        HPBar = transform.Find("HPCanvas/HPBar").gameObject.GetComponent<Image>();
        HPCanvas = transform.Find("HPCanvas").gameObject;
        HPCanvas.GetComponent<Canvas>().worldCamera = Camera.main;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        HPBar.fillAmount = HP / MaxHP;
        HPCanvas.transform.LookAt(Player.transform.position);
    }
}
