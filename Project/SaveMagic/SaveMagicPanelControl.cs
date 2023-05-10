using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SaveMagicPanelControl : MonoBehaviour
{
    protected int key;
    public void Start()
    {
        var OK = transform.Find("OK").gameObject;
        var Cancel = transform.Find("Cancel").gameObject;
        OK.GetComponent<Button>().onClick.AddListener(OnOK);
        Cancel.GetComponent<Button>().onClick.AddListener(OnCancel);

    }

    public void SetMagicKey(int a)
    {
        key = a;
    }

    public void OnOK()
    {
        SaveMagic.Save(DisplayMagicInfo.DisplayMagic, $"{key}");
        GetComponent<RectTransform>().DOScale(0, 0.3f).SetEase(Ease.OutCirc);
        SaveMagicSceneControll.Refresh();
        key = -1;
    }

    public void OnCancel()
    {
        GetComponent<RectTransform>().DOScale(0, 0.3f).SetEase(Ease.OutCirc);
        key = -1;
    }
}
