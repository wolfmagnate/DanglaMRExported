using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 魔方陣のカードを選択する順番を決めることが目標。
/// 最終的にList<Vector2int>を作成してそこに、選択順にVector2Intを入れる
/// つまり、(1,4)→(3,1)→(0,1)→(2,2)→(4,3)の順にカードを選んだ場合には
/// new List<Vector2Int> {new Vector2Int(1,4), new Vector2Int(3,1), new...}みたいな感じのリストを作成する
/// 
/// さらに、SetMagicCards.magicCardsの魔方陣データを合わせて
/// MagicCreater.CreateMagic(MagicCard[,] 魔方陣データ,List<Vector2Int> 上記の内容のリスト)
/// を呼び出すことで、魔法の情報がすべて入ったMagicインスタンスを得られる
/// 
/// </summary>
public class CreateMagicFieldManager : MonoBehaviour
{
    public Sprite DefaultIcon;
    public Sprite NumberBackground;
    public Sprite PowerUpNumberBackground;
    public Color NumberSpriteColor;
    public Color PowerUpNumberSpriteColor;
    public Sprite PowerUpArrow;
    public Sprite UsedPowerUpArrow;

    MagicFieldChainModel model;
    void Start()
    {
        model = new MagicFieldChainModel(SetMagicCards.magicCards);
        for(int x = 0;x < 5; x++)
        {
            for(int y = 0;y < 5; y++)
            {
                int X = x;
                int Y = y;
                var eachButton = transform.Find($"Panel/X{X}Y{Y}").gameObject.GetComponent<CreateMagicFieldEachButton>();
                eachButton.SetPosition(new Vector2Int(X, Y));
                eachButton.SetModel(model);
                eachButton.SetManager(this);
                eachButton.ChangeIcon();
            }
        }
    }

    public Sprite GetChainNumberSprite(int number)
    {
        switch (number)
        {
            case 1:
                return one;
            case 2:
                return two;
            case 3:
                return three;
            case 4:
                return four;
            case 5:
                return five;
            default:
                return null;
        }
    }
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;


    public void Back()
    {
        SceneManager.LoadScene("Project/CreateMagic/CreateMagic");
    }

}
