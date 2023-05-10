using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DisplayMagicProgressAnimation : MonoBehaviour
{

    public void StartAnimation(float ratio)
    {
        myRect = GetComponent<RectTransform>();
        myRect.localScale = Vector3.zero;
        Progress = transform.Find("Meter").gameObject.GetComponent<Image>();
        Ratio = Mathf.Min(ratio,1);
        StartCoroutine(AnimationCoroutine());
    }

    public void SetValue(float value, float diff)
    {
        transform.Find("Text").GetComponent<Text>().text += $"\n{value}";
        transform.Find("Before").GetComponent<Text>().text = $"[{value - diff}]";
    }

    float Ratio;
    RectTransform myRect;
    Image Progress;
    IEnumerator AnimationCoroutine()
    {
        myRect.DOScale(Vector3.one, 0.5f);
        yield return new WaitForSeconds(0.5f);
        DOTween.To(() => Progress.fillAmount, (value) => Progress.fillAmount = (float)value, Ratio, 0.5f);
    }
}
