using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusZukanDetailSceneManager : MonoBehaviour
{

    public void VirusZukanDetailScene(ZukanEnemy DisplayZukanEnemy, int EnemyNumber)
    {
        GetComponent<Canvas>().sortingOrder = 1;

        // Icon��ݒ�A�ԍ���ݒ�A��������ݒ�A������ݒ�
        var resistance = DisplayZukanEnemy.Enemy.GetComponent<EnemyStatusController>().resistance;
        Sprite icon = DisplayZukanEnemy.Icon;
        string description = DisplayZukanEnemy.Description;

        transform.Find("Panel/Scroll View/Viewport/Content/Description").GetComponent<Text>().text = description;
        transform.Find("Panel/Frame/Image").GetComponent<Image>().sprite = icon;
        transform.Find("Panel/VirusName/Text").GetComponent<Text>().text = $"�E�C���XNo.{EnemyNumber}\n{DisplayZukanEnemy.Name}";

        string resistanceText = "";
        if(resistance.Darkness < 1)
        {
            resistanceText += "���ӑ����F��\n";
        }
        if (resistance.Darkness > 1)
        {
            resistanceText += "��葮���F��\n";
        }
        if (resistance.Fire < 1)
        {
            resistanceText += "���ӑ����F��\n";
        }
        if (resistance.Fire > 1)
        {
            resistanceText += "��葮���F��\n";
        }
        if (resistance.Ice < 1)
        {
            resistanceText += "���ӑ����F�X\n";
        }
        if (resistance.Ice > 1)
        {
            resistanceText += "��葮���F�X\n";
        }
        if (resistance.Light < 1)
        {
            resistanceText += "���ӑ����F��\n";
        }
        if (resistance.Light > 1)
        {
            resistanceText += "��葮���F��\n";
        }
        if (resistance.Lightning < 1)
        {
            resistanceText += "���ӑ����F��\n";
        }
        if (resistance.Lightning > 1)
        {
            resistanceText += "��葮���F��\n";
        }
        if (resistance.Metal < 1)
        {
            resistanceText += "���ӑ����F�|\n";
        }
        if (resistance.Metal > 1)
        {
            resistanceText += "��葮���F�|\n";
        }
        if (resistance.Mountain < 1)
        {
            resistanceText += "���ӑ����F�R\n";
        }
        if (resistance.Mountain > 1)
        {
            resistanceText += "��葮���F�R\n";
        }
        if (resistance.Tree < 1)
        {
            resistanceText += "���ӑ����F��\n";
        }
        if (resistance.Tree > 1)
        {
            resistanceText += "��葮���F��\n";
        }
        if (resistance.Water < 1)
        {
            resistanceText += "���ӑ����F��\n";
        }
        if (resistance.Water > 1)
        {
            resistanceText += "��葮���F��\n";
        }
        if (resistance.Wind < 1)
        {
            resistanceText += "���ӑ����F��\n";
        }
        if (resistance.Wind > 1)
        {
            resistanceText += "��葮���F��\n";
        }
        transform.Find("Panel/Scroll View/Viewport/Content/Description").GetComponent<Text>().text += $"\n\n{resistanceText}";
    }

    public void Close()
    {
        MenuSESoundManager.Instance.PlayCancel();
        GetComponent<Canvas>().sortingOrder = -1;
    }

    private void Start()
    {
        GetComponent<Canvas>().sortingOrder = -1;
    }

}
