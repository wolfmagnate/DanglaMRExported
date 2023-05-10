using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class LogoControl : MonoBehaviour
{
    GameObject background;
    GameObject line;
    GameObject circle;

    GameObject disaster;
    GameObject authent;
    GameObject disasterWhite;
    GameObject authentWhite;

    GameObject startText;

    bool isFirstUodate = true;

    // Start is called before the first frame update
    void Update()
    {
        if(!isFirstUodate) { return; }
        isFirstUodate=false;
        SettingSceneControl.Load();
        MenuSESoundManager.Instance.StopSE();
        MenuSESoundManager.Instance.StartSE();
        MenuBGMSoundManager.Instance.StopBGM();
        MenuBGMSoundManager.Instance.StartBGM();
        StartCoroutine(Move());
    }

    public void ToMenu()
    {
        MenuSESoundManager.Instance.PlayGameStart();
        SceneManager.LoadScene("Project/Menu/Menu");
    }

    IEnumerator Move()
    {
        background = transform.Find("Background").gameObject;
        line = transform.Find("Line").gameObject;
        disaster = transform.Find("Disaster").gameObject;
        authent = transform.Find("Authent").gameObject;
        disasterWhite = transform.Find("DisasterWhite").gameObject;
        authentWhite = transform.Find("AuthentWhite").gameObject;
        circle = transform.Find("Circle").gameObject;
        startText = transform.parent.Find("StartText").gameObject;
        background.GetComponent<RectTransform>().localScale = new Vector3(0, 1, 0);
        line.GetComponent<RectTransform>().localScale = new Vector3(0, 1, 0);
        disasterWhite.GetComponent<RectTransform>().localPosition = new Vector3(1000, 0, 0);
        authentWhite.GetComponent<RectTransform>().localPosition = new Vector3(-1500, 0, 0);
        disaster.GetComponent<RectTransform>().localScale = new Vector3(2, 0, 0);
        authent.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1);
        background.GetComponent<RectTransform>().DOScale(Vector3.one, 1);
        line.GetComponent<RectTransform>().DOScale(Vector3.one, 1);
        disasterWhite.GetComponent<RectTransform>().DOLocalMove(new Vector3(-111, 0, 0), 1);
        authentWhite.GetComponent<RectTransform>().DOLocalMove(new Vector3(-111, 0, 0), 1);
        yield return new WaitForSeconds(1.5f);
        circle.GetComponent<RectTransform>().DOScale(Vector3.one, 0.3f);
        transform.DOScale(1.5f * Vector3.one, 0.5f);
        yield return new WaitForSeconds(0.2f);
        disaster.GetComponent<TextMeshProUGUI>().text = @"   ñÚ<color=red><size=120>ç–</size></color> <size=100>ÇÃ</size>
    ";
        disasterWhite.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        authentWhite.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        disaster.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 0);
        authent.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 0);

        yield return new WaitForSeconds(1f);
        var seq = DOTween.Sequence();
        seq.Append(startText.GetComponent<Text>().DOFade(1, 1));
        seq.Append(startText.GetComponent<Text>().DOFade(0, 1));
        seq.SetLoops(-1);
        seq.Play();
    }
}
