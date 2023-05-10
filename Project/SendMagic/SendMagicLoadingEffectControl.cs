using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SendMagicLoadingEffectControl : MonoBehaviour
{
    RectTransform myRect;
    Image EffectImage;
    // Start is called before the first frame update
    void Start()
    {
        myRect = GetComponent<RectTransform>();
        EffectImage = transform.Find("EffectFront").gameObject.GetComponent<Image>();
        EffectImage.fillAmount = 0;
        EffectImage.fillClockwise = true;

        Sequence seq = DOTween.Sequence();
        // fillamount��0����1�Aclockwise�𔽓]�Afillamount��1����0�Aclockwise�𔽓]�c�𖳌����[�v����
        seq.Append(
            DOTween.To(
            () => EffectImage.fillAmount,
            (x) => { EffectImage.fillAmount = x; }, endValue: 1, duration: 1
            )
        ).AppendCallback(() =>
        {
            EffectImage.fillClockwise = false;
        }
        ).Append(
            DOTween.To(
            () => EffectImage.fillAmount,
            (x) => { EffectImage.fillAmount = x; }, endValue: 0, duration: 1
            )
        ).AppendCallback(() =>
        {
            EffectImage.fillClockwise = true;
        }).SetLoops(-1);
        EndEffect();
    }

    public void StartEffect()
    {
        myRect.localScale = Vector3.one;
    }

    public void EndEffect()
    {
        myRect.localScale = Vector3.zero;
    }
}
