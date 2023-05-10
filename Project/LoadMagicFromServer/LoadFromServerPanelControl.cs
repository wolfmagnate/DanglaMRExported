using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class LoadFromServerPanelControl : MonoBehaviour
{

    InputField inputText;
    protected int key;
    bool Usable = true;
    SendMagicLoadingEffectControl LoadingEffectControl;

    public void Start()
    {
        var OK = transform.Find("OK").gameObject;
        var Cancel = transform.Find("Cancel").gameObject;
        OK.GetComponent<Button>().onClick.AddListener(OnOK);
        Cancel.GetComponent<Button>().onClick.AddListener(OnCancel);

        inputText = transform.Find("InputField").gameObject.GetComponent<InputField>();
        LoadingEffectControl = GameObject.Find("Canvas/LoadingEffect").GetComponent<SendMagicLoadingEffectControl>();

    }

    public void SetMagicKey(int a)
    {
        key = a;
    }

    public void OnOK()
    {
        if (!Usable) { return; }
        if (! Regex.IsMatch(inputText.text, "[0-9a-z]{24}")) { return; }
        MenuSESoundManager.Instance.PlayOK();
        LoadingEffectControl.StartEffect();
        CallAPI.GetMagicByID(inputText.text,
            (string errorText) =>
            {
                
                if (errorText.Contains("404"))
                {
                    // 見つからなかった場合
                    transform.Find("Text").gameObject.GetComponent<Text>().text = "コードに対応する薬品が\n登録されていません";
                }
                else
                {
                    // 通信エラー
                    transform.Find("Text").gameObject.GetComponent<Text>().text = "通信エラー\n環境を整えて再試行してください";
                }

                Debug.Log(errorText);
                LoadingEffectControl.EndEffect();
                Usable = true;
            },
            (string magicJSON) =>
            {
                var gotMagic = JsonUtility.FromJson<Magic>(magicJSON);
                GameObject.Find("MovieCanvas").GetComponent<LoadMagicFromServerMovieControl>().StartMovie(gotMagic.MagicName);
                SaveMagic.SaveFromServer(gotMagic, $"{key}");
                transform.Find("InputField").gameObject.GetComponent<InputField>().text = "";
                transform.Find("Text").gameObject.GetComponent<Text>().text = "薬品コードを入力してください";
                GetComponent<RectTransform>().DOScale(0, 0.3f).SetEase(Ease.OutCirc);
                key = -1;
                LoadingEffectControl.EndEffect();
                Usable = true;
                LoadMagicFromServerSceneControl.Refresh();
            }
            );
    }

    public void OnCancel()
    {
        if (!Usable) { return; }
        MenuSESoundManager.Instance.PlayCancel();
        transform.Find("InputField").gameObject.GetComponent<InputField>().text = "";
        inputText.text = "";
        transform.Find("Text").gameObject.GetComponent<Text>().text = "薬品コードを入力してください";
        GetComponent<RectTransform>().DOScale(0, 0.3f).SetEase(Ease.OutCirc);
        key = -1;
    }
}
