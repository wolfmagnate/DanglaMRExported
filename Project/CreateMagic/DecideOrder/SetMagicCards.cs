using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

/// <summary>
/// このスクリプトの最終目標は
/// magicCardsの二次元配列の適切な場所に、適切なMagicCard型のインスタンスを入れて他の場所にnullを入れることです。
/// 注意点はmagicCards[y座標,x座標]という指定になることと、
/// y座標のせいの向きが下向きであることです。
/// </summary>
public class SetMagicCards : MonoBehaviour
{
    DecideOrderModel model;

    void Start()
    {
        model = new DecideOrderModel(magicCards);
        for(int x = 0;x < 5; x++)
        {
            for(int y = 0;y < 5; y++)
            {
                var eachButton = transform.Find($"Panel/X{x}Y{y}").gameObject.GetComponent<SetMagicCardEachButton>();
                eachButton.SetManager(this);
                eachButton.SetModel(model);
                eachButton.SetPosition(new Vector2Int(x, y));
            }
        }
    }
    public void Back()
    {
        SceneManager.LoadScene("Project/SelectCards/SelectCards");
    }

    public void OK()
    {
        SceneManager.LoadScene("Project/CreateMagic/CreateMagicField");
    }

    public static MagicCard[,] magicCards { get; set; }
    public Sprite DefaultlIcon;
}
