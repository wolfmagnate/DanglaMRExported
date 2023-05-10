using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HelpInformationSceneButton : MonoBehaviour
{
    [TextArea]
    public string InformationText;

    public void ShowInformation()
    {
        MenuSESoundManager.Instance.PlayOK();
        var Panel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
        Panel.SetActive(true);
        Panel.transform.Find("Text").gameObject.GetComponent<Text>().text = InformationText;
        Panel.GetComponent<RectTransform>().localScale = Vector3.zero;
        Panel.GetComponent<RectTransform>().DOScale(1, 0.3f).SetEase(Ease.OutCirc);
    }
}
