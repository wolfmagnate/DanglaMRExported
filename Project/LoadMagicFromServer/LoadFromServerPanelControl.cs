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
                    // ������Ȃ������ꍇ
                    transform.Find("Text").gameObject.GetComponent<Text>().text = "�R�[�h�ɑΉ������i��\n�o�^����Ă��܂���";
                }
                else
                {
                    // �ʐM�G���[
                    transform.Find("Text").gameObject.GetComponent<Text>().text = "�ʐM�G���[\n���𐮂��čĎ��s���Ă�������";
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
                transform.Find("Text").gameObject.GetComponent<Text>().text = "��i�R�[�h����͂��Ă�������";
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
        transform.Find("Text").gameObject.GetComponent<Text>().text = "��i�R�[�h����͂��Ă�������";
        GetComponent<RectTransform>().DOScale(0, 0.3f).SetEase(Ease.OutCirc);
        key = -1;
    }
}
