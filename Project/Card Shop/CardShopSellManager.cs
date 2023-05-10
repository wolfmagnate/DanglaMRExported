using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardShopSellManager : MonoBehaviour
{
    public GameObject CardItem;

    Text currentMoney;
    Text sum;

    CardShopSellSettingManager settingManager;

    void Start()
    {
        currentMoney = transform.Find("Panel/Money").gameObject.GetComponent<Text>();
        sum = transform.Find("Panel/Price").gameObject.GetComponent<Text>();
        sum.text = "0";
        currentMoney.text = $"{DegitalCardPlayer.GetDegitalCardPlayer().GetMoneyManager().Money}";
        settingManager = GameObject.Find("OrderCanvas").gameObject.GetComponent<CardShopSellSettingManager>();
    }


    public void MakeCellCardList()
    {
        MenuSESoundManager.Instance.PlayClick();
        ResetList();
        var parent = transform.Find("Scroll View/Viewport/Content");
        var attributes = settingManager.GetAttributes();
        var races = settingManager.GetCardRaces();

        IDegitalCardPlayer player = DegitalCardPlayer.GetDegitalCardPlayer();
        var store = player.GetCardStore();
        foreach(var cardSet in store.cardsOfPlayer)
        {
            foreach(var card in cardSet.Value)
            {
                if (!attributes.Contains(card.CardAttribute)) { continue; }
                if (!card.Race.Any(x => races.Contains(x))) { continue; }
                if (!(card is PowerUpCard)) { continue; }
                var cardItem = Instantiate(CardItem);
                var sellItem = cardItem.GetComponent<CardShopSellItem>();
                if(card is PowerUpCard powerUpCard)
                {
                    sellItem.SetItemData(powerUpCard);
                }
                sellItem.SetSelectedEvent((int price) =>
                {
                    sum.text = $"{int.Parse(sum.text) + price}";
                });
                sellItem.SetUnselectedEvent((int price) =>
                {
                    sum.text = $"{int.Parse(sum.text) - price}";
                });
                cardItem.transform.parent = parent;
            }
        }
    }

    public void MakeCoreCardList()
    {
        MenuSESoundManager.Instance.PlayClick();
        ResetList();
        var parent = transform.Find("Scroll View/Viewport/Content");
        var attributes = settingManager.GetAttributes();
        var races = settingManager.GetCardRaces();

        IDegitalCardPlayer player = DegitalCardPlayer.GetDegitalCardPlayer();
        var store = player.GetCardStore();
        foreach (var cardSet in store.cardsOfPlayer)
        {
            foreach (var card in cardSet.Value)
            {
                if (!attributes.Contains(card.CardAttribute)) { continue; }
                if (!card.Race.Any(x => races.Contains(x))) { continue; }
                if (!(card is MagicTypeCard))
                {
                    continue;
                }
                var cardItem = Instantiate(CardItem);
                var sellItem = cardItem.GetComponent<CardShopSellItem>();
                if (card is MagicTypeCard powerUpCard)
                {
                    sellItem.SetItemData(powerUpCard);
                }
                sellItem.SetSelectedEvent((int price) =>
                {
                    sum.text = $"{int.Parse(sum.text) + price}";
                });
                sellItem.SetUnselectedEvent((int price) =>
                {
                    sum.text = $"{int.Parse(sum.text) - price}";
                });
                cardItem.transform.parent = parent;
            }
        }
    }

    public void Confirm()
    {
        IDegitalCardPlayer player = DegitalCardPlayer.GetDegitalCardPlayer();
        var store = player.GetCardStore();
        var money = player.GetMoneyManager();

        var parent = transform.Find("Scroll View/Viewport/Content");
        int itemCount = parent.childCount;
        int sum = 0;
        List<MagicCard> boughtCards = new List<MagicCard>();
        for (int i = 0; i < itemCount; i++)
        {
            var sellitem = parent.GetChild(i).gameObject.GetComponent<CardShopSellItem>();
            if (sellitem.IsSelected)
            {
                sum += sellitem.GetPrice;
                boughtCards.Add(sellitem.GetCard);
            }
        }
        foreach (var boughtcard in boughtCards)
        {
            store.RemoveCard(boughtcard);
        }
        money.Gain(sum);

        MenuSESoundManager.Instance.PlayMoney();
        CardStore.Save(player.GetCardStore());
        MoneyManager.Save(player.GetMoneyManager());
        currentMoney.text = $"{DegitalCardPlayer.GetDegitalCardPlayer().GetMoneyManager().Money}";
        this.sum.text = "0";
        ResetList();
    }

    void ResetList()
    {
        var parent = transform.Find("Scroll View/Viewport/Content");
        sum.text = "0";
        int itemCount = parent.childCount;
        for (int i = 0; i < itemCount; i++)
        {
            GameObject.Destroy(parent.GetChild(i).gameObject);
        }
    }

    public void Settings()
    {
        MenuSESoundManager.Instance.PlayOK();
        settingManager.Open();
        ResetList();
    }
}
