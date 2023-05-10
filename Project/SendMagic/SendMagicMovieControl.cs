using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendMagicMovieControl : MonoBehaviour
{

    GameObject UpArrow;
    GameObject DownArrow;
    GameObject LeftArrow;
    GameObject RightArrow;
    GameObject Panel;
    GameObject UpperBar;
    GameObject LowerBar;
    GameObject Card;
    GameObject PackedMagic;
    GameObject Foreground;
    LoadMagicFromServerPackedMagicControl packed;

    void Start()
    {
        UpArrow = transform.Find("Panel/UpArrow").gameObject;
        DownArrow = transform.Find("Panel/DownArrow").gameObject;
        LeftArrow = transform.Find("Panel/LeftArrow").gameObject;
        RightArrow = transform.Find("Panel/RightArrow").gameObject;
        Panel = transform.Find("Panel").gameObject;
        UpperBar = transform.Find("UpperBar").gameObject;
        LowerBar = transform.Find("LowerBar").gameObject;
        Card = transform.Find("Card").gameObject;
        PackedMagic = transform.Find("PackedMagic").gameObject;
        Foreground = transform.Find("Foreground").gameObject;
        packed = transform.Find("PackedMagic").GetComponent<LoadMagicFromServerPackedMagicControl>();

    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(0.3f);
        ResetAll();
        UpperBar.GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), 0.3f);
        LowerBar.GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), 0.3f);
        yield return new WaitForSeconds(0.3f);
        UpperBar.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, 400, 0), 0.3f);
        LowerBar.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, -400, 0), 0.3f);
        Panel.GetComponent<RectTransform>().DOSizeDelta(new Vector2(1200, 800), 0.3f);
        yield return new WaitForSeconds(0.6f);
        LeftArrow.GetComponent<RectTransform>().DOLocalMove(new Vector3(-300, 0, 0), 0.3f);
        yield return new WaitForSeconds(0.2f);
        RightArrow.GetComponent<RectTransform>().DOLocalMove(new Vector3(300, 0, 0), 0.3f);
        yield return new WaitForSeconds(0.2f);
        UpArrow.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, 300, 0), 0.3f);
        yield return new WaitForSeconds(0.2f);
        DownArrow.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, -300, 0), 0.3f);
        yield return new WaitForSeconds(0.8f);


        Foreground.GetComponent<Image>().DOColor(Color.white, 0.3f);
        yield return new WaitForSeconds(0.3f);
        Card.SetActive(false);
        PackedMagic.SetActive(true);
        Foreground.GetComponent<Image>().DOColor(new Color(0, 0, 0, 0), 1f);
        yield return new WaitForSeconds(0.5f);
        LeftArrow.GetComponent<RectTransform>().DOLocalMove(new Vector3(-1100, 0, 0), 0.3f);
        RightArrow.GetComponent<RectTransform>().DOLocalMove(new Vector3(1100, 0, 0), 0.3f);
        UpArrow.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, 1100, 0), 0.3f);
        DownArrow.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, -1100, 0), 0.3f);
        yield return new WaitForSeconds(0.3f);

        PackedMagic.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, 800, 0), 0.5f);
        UpperBar.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, 0, 0), 0.3f);
        LowerBar.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, 0, 0), 0.3f);
        Panel.GetComponent<RectTransform>().DOSizeDelta(new Vector2(1200, 0), 0.3f);
        yield return new WaitForSeconds(0.3f);
        UpperBar.GetComponent<RectTransform>().DOScale(new Vector3(0, 1, 1), 0.3f);
        LowerBar.GetComponent<RectTransform>().DOScale(new Vector3(0, 1, 1), 0.3f);

        yield return new WaitForSeconds(2f);
        GetComponent<Canvas>().sortingOrder = -1;

    }

    void ResetAll()
    {
        Card.SetActive(true);
        PackedMagic.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        PackedMagic.SetActive(false);
    }

    public void StartMovie(string magicName)
    {
        Sprite cardSprite = MagicNameToSprite(magicName);
        transform.Find("Card/ThumbnailMask/Thumbnail").gameObject.GetComponent<Image>().sprite = cardSprite;
        GetComponent<Canvas>().sortingOrder = 1;
        StartCoroutine(Move());
    }

    Sprite MagicNameToSprite(string magicName)
    {
        var allMagicTypeCards = Resources.LoadAll<MagicType>("Project/MagicTypeCards");
        foreach(var card in allMagicTypeCards)
        {
            if(magicName == card.CardName)
            {
                return card.Icon;
            }
        }
        return null;
    }
}
