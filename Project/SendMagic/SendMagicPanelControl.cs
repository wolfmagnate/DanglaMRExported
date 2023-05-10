using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendMagicPanelControl : MonoBehaviour
{
    private bool Usable = true;
    protected int key;
    SendMagicLoadingEffectControl LoadingEffectControl;
    public void Start()
    {
        var OK = transform.Find("OK").gameObject;
        var Cancel = transform.Find("Cancel").gameObject;
        OK.GetComponent<Button>().onClick.AddListener(OnOK);
        Cancel.GetComponent<Button>().onClick.AddListener(OnCancel);
        LoadingEffectControl = GameObject.Find("Canvas/LoadingEffect").GetComponent<SendMagicLoadingEffectControl>();
    }

    public void SetMagicKey(int a)
    {
        key = a;
    }

    bool ReturnMode = false;
    public void OnOK()
    {
        if (ReturnMode) { ReturnMode = false; OnCancel();return; }
        if (!Usable) { return; }
        MenuSESoundManager.Instance.PlayOK();
        Usable = false;
        // �ҋ@����ʂ��N��
        LoadingEffectControl.StartEffect();
        var magic = LoadMagic.Load($"{key}");
        CallAPI.SendMagic(
            magic,
            (string errorText) =>
            {
                transform.Find("Text").gameObject.GetComponent<Text>().text = "�ʐM�G���[\n���𐮂��čĎ��s���Ă�������";
                LoadingEffectControl.EndEffect();
                Usable = true;
                ReturnMode = true;
            },
            (string ID) => {
                GameObject.Find("MovieCanvas").GetComponent<SendMagicMovieControl>().StartMovie(magic.MagicName);
                transform.Find("Text").gameObject.GetComponent<Text>().text = $"�ʐM�ɐ����B��i�R�[�h��\n�N���b�v�{�[�h�ɃR�s�[���܂���";
                GUIUtility.systemCopyBuffer = ID;
                // �ҋ@����ʂ̉���
                LoadingEffectControl.EndEffect();
                Usable = true;
                ReturnMode = true;
            }
            );
    }

    public void OnCancel()
    {
        if (!Usable) { return; }
        MenuSESoundManager.Instance.PlayCancel();
        GetComponent<RectTransform>().DOScale(0, 0.3f).SetEase(Ease.OutCirc);
        transform.Find("Text").gameObject.GetComponent<Text>().text = "�T�[�o�[�ɓo�^���܂����H";
        key = -1;
    }
}
