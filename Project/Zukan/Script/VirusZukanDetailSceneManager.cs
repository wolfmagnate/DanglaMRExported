using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusZukanDetailSceneManager : MonoBehaviour
{

    public void VirusZukanDetailScene(ZukanEnemy DisplayZukanEnemy, int EnemyNumber)
    {
        GetComponent<Canvas>().sortingOrder = 1;

        // Iconを設定、番号を設定、説明文を設定、属性を設定
        var resistance = DisplayZukanEnemy.Enemy.GetComponent<EnemyStatusController>().resistance;
        Sprite icon = DisplayZukanEnemy.Icon;
        string description = DisplayZukanEnemy.Description;

        transform.Find("Panel/Scroll View/Viewport/Content/Description").GetComponent<Text>().text = description;
        transform.Find("Panel/Frame/Image").GetComponent<Image>().sprite = icon;
        transform.Find("Panel/VirusName/Text").GetComponent<Text>().text = $"ウイルスNo.{EnemyNumber}\n{DisplayZukanEnemy.Name}";

        string resistanceText = "";
        if(resistance.Darkness < 1)
        {
            resistanceText += "得意属性：闇\n";
        }
        if (resistance.Darkness > 1)
        {
            resistanceText += "苦手属性：闇\n";
        }
        if (resistance.Fire < 1)
        {
            resistanceText += "得意属性：炎\n";
        }
        if (resistance.Fire > 1)
        {
            resistanceText += "苦手属性：炎\n";
        }
        if (resistance.Ice < 1)
        {
            resistanceText += "得意属性：氷\n";
        }
        if (resistance.Ice > 1)
        {
            resistanceText += "苦手属性：氷\n";
        }
        if (resistance.Light < 1)
        {
            resistanceText += "得意属性：光\n";
        }
        if (resistance.Light > 1)
        {
            resistanceText += "苦手属性：光\n";
        }
        if (resistance.Lightning < 1)
        {
            resistanceText += "得意属性：雷\n";
        }
        if (resistance.Lightning > 1)
        {
            resistanceText += "苦手属性：雷\n";
        }
        if (resistance.Metal < 1)
        {
            resistanceText += "得意属性：鋼\n";
        }
        if (resistance.Metal > 1)
        {
            resistanceText += "苦手属性：鋼\n";
        }
        if (resistance.Mountain < 1)
        {
            resistanceText += "得意属性：山\n";
        }
        if (resistance.Mountain > 1)
        {
            resistanceText += "苦手属性：山\n";
        }
        if (resistance.Tree < 1)
        {
            resistanceText += "得意属性：木\n";
        }
        if (resistance.Tree > 1)
        {
            resistanceText += "苦手属性：木\n";
        }
        if (resistance.Water < 1)
        {
            resistanceText += "得意属性：水\n";
        }
        if (resistance.Water > 1)
        {
            resistanceText += "苦手属性：水\n";
        }
        if (resistance.Wind < 1)
        {
            resistanceText += "得意属性：風\n";
        }
        if (resistance.Wind > 1)
        {
            resistanceText += "苦手属性：風\n";
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
