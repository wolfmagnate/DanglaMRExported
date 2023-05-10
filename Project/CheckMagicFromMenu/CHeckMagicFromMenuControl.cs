using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CHeckMagicFromMenuControl : MonoBehaviour
{
    public static Magic DisplayMagic { get; set; }

    private void Start()
    {
        transform.Find("Attack").GetComponent<DisplayMagicProgressAnimation>().StartAnimation(DisplayMagic.Attack / 100f);
        transform.Find("CanHitTimes").GetComponent<DisplayMagicProgressAnimation>().StartAnimation(DisplayMagic.CanHitTimes / 100f);
        transform.Find("ChargeTime").GetComponent<DisplayMagicProgressAnimation>().StartAnimation(DisplayMagic.ChargeTime / 100f);
        transform.Find("Distance").GetComponent<DisplayMagicProgressAnimation>().StartAnimation(DisplayMagic.Distance / 10f);
        transform.Find("Range").GetComponent<DisplayMagicProgressAnimation>().StartAnimation(DisplayMagic.Range / 2f);
        transform.Find("MP").GetComponent<DisplayMagicProgressAnimation>().StartAnimation(DisplayMagic.MP / 100f);
        transform.Find("Speed").GetComponent<DisplayMagicProgressAnimation>().StartAnimation(DisplayMagic.Speed / 20f);
        transform.Find("Rush").GetComponent<DisplayMagicProgressAnimation>().StartAnimation(DisplayMagic.Rush / 50f);
        transform.Find("RushInterval").GetComponent<DisplayMagicProgressAnimation>().StartAnimation(DisplayMagic.RushInterval / 1f);
        (float Attack, int CanHitTimes, float ChargeTime, float Distance, float MP, float Range, int Rush, float RushInterval, float Speed) = DisplayMagic.GetPowerUpAmount();
        transform.Find("Attack").GetComponent<DisplayMagicProgressAnimation>().SetValue(DisplayMagic.Attack, Attack);
        transform.Find("CanHitTimes").GetComponent<DisplayMagicProgressAnimation>().SetValue(DisplayMagic.CanHitTimes, CanHitTimes);
        transform.Find("ChargeTime").GetComponent<DisplayMagicProgressAnimation>().SetValue(DisplayMagic.ChargeTime, ChargeTime);
        transform.Find("Distance").GetComponent<DisplayMagicProgressAnimation>().SetValue(DisplayMagic.Distance, Distance);
        transform.Find("Range").GetComponent<DisplayMagicProgressAnimation>().SetValue(DisplayMagic.Range, Range);
        transform.Find("MP").GetComponent<DisplayMagicProgressAnimation>().SetValue(DisplayMagic.MP, MP);
        transform.Find("Speed").GetComponent<DisplayMagicProgressAnimation>().SetValue(DisplayMagic.Speed, Speed);
        transform.Find("Rush").GetComponent<DisplayMagicProgressAnimation>().SetValue(DisplayMagic.Rush, Rush);
        transform.Find("RushInterval").GetComponent<DisplayMagicProgressAnimation>().SetValue(DisplayMagic.RushInterval, RushInterval);
        transform.Find("MagicName").GetComponent<Text>().text = $"���́F{DisplayMagic.MagicName}";
        transform.Find("MoveType").GetComponent<Text>().text = $"�ړ��^�C�v�F{DisplayMagic.MoveType}";
        transform.Find("Attribute").GetComponent<Text>().text = $"�����F{AttributeToText(DisplayMagic.Attribute)}";
    }

    private object AttributeToText(MagicAttribute attribute)
    {
        return attribute switch
        {
            MagicAttribute.Wind => "��",
            MagicAttribute.Lightning => "��",
            MagicAttribute.Tree => "��",
            MagicAttribute.Water => "��",
            MagicAttribute.Fire => "��",
            MagicAttribute.Ice => "�X",
            MagicAttribute.Mountain => "�R",
            MagicAttribute.Metal => "�|",
            MagicAttribute.Light => "��",
            MagicAttribute.Darkness => "��",
            MagicAttribute.Nothing => "��",
            _ => "����Ȃ̂Ȃ�",
        };
    }

    public void Back()
    {
        MenuSESoundManager.Instance.PlayCancel();
        SceneManager.LoadScene("Project/SelectCheckMagic/SelectCheckMagic");
    }

}
