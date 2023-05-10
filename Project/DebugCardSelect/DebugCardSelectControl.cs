using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebugCardSelectControl : MonoBehaviour
{
    public GameObject buttonBase;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("End").GetComponent<Button>().onClick.AddListener(EndInput);
        text = GameObject.Find("UIText").GetComponent<Text>();

        IDegitalCardPlayer player = DegitalCardPlayer.GetDegitalCardPlayer();
        if(player.GetCardStore().cardsOfPlayer.Count == 0)
        {
            player.GetMoneyManager().Gain(5_0000_0000);
            MagicType[] Mcards = Shop.LoadAllMagicType();
            5.Times(() => {
                foreach (var card in Mcards)
                {
                    Shop.BuyMagicTypeCard(player, card);
                }
            });
            PowerUp[] Pcards = Shop.LoadAllPowerUp();
            5.Times(() => {
                foreach (var card in Pcards)
                {
                    Shop.BuyPowerUpCard(player, card);
                }
            });

            CardStore.Save(player.GetCardStore());
        }

        Dictionary<string, List<MagicCard>> cardsOfPlayer = player.GetCardStore().cardsOfPlayer;
        int vertical = -1000;
        int horizontal = 2400;
        var parent = GameObject.Find("Content");
        foreach(var cardList in cardsOfPlayer)
        {
            // カードの座標を計算
            vertical += 250;
            if(vertical == 1000)
            {
                vertical = -750;
                horizontal -= 200;
            }

            var btn = Instantiate(buttonBase);
            btn.transform.parent = parent.transform;
            btn.GetComponent<Image>().sprite = cardList.Value[0].GetIcon();
            btn.GetComponent<RectTransform>().anchoredPosition = new Vector2(vertical, horizontal);
            var debugButton = btn.AddComponent<DebugCardButton>();
            debugButton.SetCardList(cardList.Value);
            btns.Add(btn);
        }

    }
    List<GameObject> btns = new List<GameObject>();

    List<MagicCard> SelectedCards = new List<MagicCard>();
    public void AddMagicCard(MagicCard magicCard)
    {
        SelectedCards.Add(magicCard);
    }

    public void EndInput()
    {
        // 術式カード複数はダメ
        if(SelectedCards.Count != 5 || SelectedCards.Count(x => x is MagicTypeCard) > 1)
        {
            // 初期化
            SelectedCards = new List<MagicCard>();
            foreach(var btn in btns)
            {
                btn.GetComponent<DebugCardButton>().ReStart();
            }
        }


        // データをシーン間移動のために保存
        SetMagicCards.magicCards = new MagicCard[5, 5];
        for (int i = 0; i < 5; i++)
        {
            SetMagicCards.magicCards[0, i] = SelectedCards[i];
        }
        // シーンから離脱
        SceneManager.LoadScene(1);
    }

    public void GetMoney()
    {
        var manager = MoneyManager.Load();
        manager.Gain(1000000);
        MoneyManager.Save(manager);
    }


    Text text;
    // Update is called once per frame
    void Update()
    {
        text.text = $"{SelectedCards.Count}枚選択済み";
    }
}
