using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HelpInformationExitButton : MonoBehaviour
{
    public void Exit()
    {
        MenuSESoundManager.Instance.PlayCancel();
        var Panel = GameObject.Find("Panel");
        Panel.GetComponent<RectTransform>().DOScale(0, 0.3f).SetEase(Ease.OutCirc);
    }
}
