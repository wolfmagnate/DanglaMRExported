using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LabResearchMovie : MonoBehaviour
{
    Text rarityText;
    GameObject cardPack;
    GameObject circle1;
    GameObject circle2;
    GameObject circle3;
    GameObject circle4;
    Image foreground;
    void Start()
    {
        rarityText = transform.Find("CardPack/Effect/Rarity").gameObject.GetComponent<Text>();
        cardPack = transform.Find("CardPack").gameObject;
        circle1 = transform.Find("CardPack/Effect/Circles/Circle1").gameObject;
        circle2 = transform.Find("CardPack/Effect/Circles/Circle2").gameObject;
        circle3 = transform.Find("CardPack/Effect/Circles/Circle3").gameObject;
        circle4 = transform.Find("CardPack/Effect/Circles/Circle4").gameObject;
        foreground = transform.Find("Foreground").gameObject.GetComponent<Image>();
        GetComponent<Canvas>().sortingOrder = -1;
    }

    public void StartMovie(string rarity)
    {
        GetComponent<Canvas>().sortingOrder = 1;
        rarityText.text = rarity;
        StartCoroutine(MovieCoroutine());
    }
    IEnumerator MovieCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        cardPack.GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), 1f);
        circle1.GetComponent<RectTransform>().DORotate(new Vector3(0, 0, 4 * 360), 2).SetRelative(true);
        circle2.GetComponent<RectTransform>().DORotate(new Vector3(0, 0, 4 * -360), 2).SetRelative(true);
        circle3.GetComponent<RectTransform>().DORotate(new Vector3(0, 0, 4 * 180), 2).SetRelative(true);
        circle4.GetComponent<RectTransform>().DORotate(new Vector3(0, 0, 4 * -180), 2).SetRelative(true);
        yield return new WaitForSeconds(1.8f);
        foreground.DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Lab Research Result");

    }
}
