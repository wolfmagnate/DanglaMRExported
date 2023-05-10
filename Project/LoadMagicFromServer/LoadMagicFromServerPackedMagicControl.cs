using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMagicFromServerPackedMagicControl : MonoBehaviour
{
    GameObject Circle1;
    GameObject Circle2;
    GameObject Center;
    Image effect1;
    Image effect2;
    Image effect3;

    // Start is called before the first frame update
    void Start()
    {
        Circle1 = transform.Find("Circle1").gameObject;
        Circle2 = transform.Find("Circle2").gameObject;
        Center = transform.Find("Center").gameObject;
        effect1 = transform.Find("AdditionalEffect1").gameObject.GetComponent<Image>();
        effect2 = transform.Find("AdditionalEffect2").gameObject.GetComponent<Image>();
        effect3 = transform.Find("AdditionalEffect3").gameObject.GetComponent<Image>();
        Move();
        StartCoroutine(ScaleAnimation());
    }

    private void Move()
    {
        Circle1.transform.DORotate(new Vector3(0, 0, 360), 0.5f, RotateMode.FastBeyond360).SetLoops(-1);
        Circle2.transform.DORotate(new Vector3(0, 0, -360), 0.5f, RotateMode.FastBeyond360).SetLoops(-1);
    }

    IEnumerator ScaleAnimation()
    {
        while (true)
        {
            var scale = Random.Range(0.8f, 1.2f);
            transform.DOScale(new Vector3(scale, scale, 1), 0.3f);
            var scale2 = Random.Range(0.8f, 1.2f);
            Center.transform.DOScale(new Vector3(scale2, scale2, 1), 0.3f);
            yield return new WaitForSeconds(0.3f);
        }
    }

    public void EffectOn()
    {
        StartCoroutine(AnimateEffect());
    }

    IEnumerator AnimateEffect()
    {
        effect1.DOFade(1, 0.3f);
        yield return new WaitForSeconds(0.3f);
        effect2.DOFade(1, 0.3f);
        yield return new WaitForSeconds(0.3f);
        effect3.DOFade(1, 0.3f);
        yield return new WaitForSeconds(0.3f);
    }

    public void DeleteAll()
    {
        gameObject.SetActive(false);
    }
}
