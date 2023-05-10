using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardShopBuyManager : MonoBehaviour
{
    MagicType[] magicTypes;
    PowerUp[] powerUps;

    public GameObject CardItem;

    Text currentMoney;
    Text sum;

    CardShopBuySettingManager settingManager;

    void Start()
    {
        magicTypes = Resources.LoadAll<MagicType>("Project/MagicTypeCards");
        powerUps = Resources.LoadAll<PowerUp>("Project/PowerUpCards");
        currentMoney = transform.Find("Panel/Money").gameObject.GetComponent<Text>();
        sum = transform.Find("Panel/Price").gameObject.GetComponent<Text>();
        sum.text = "0";
        currentMoney.text = $"{DegitalCardPlayer.GetDegitalCardPlayer().GetMoneyManager().Money}";
        settingManager = GameObject.Find("OrderCanvas").gameObject.GetComponent<CardShopBuySettingManager>();
        ZukanDataPrefs.Load();
    }


    public void MakeCellCardList()
    {
        ResetList();
        var parent = transform.Find("Scroll View/Viewport/Content");
        int itemCount = powerUps.Length;
        var attributes = settingManager.GetAttributes();
        var races = settingManager.GetCardRaces();
        var searchMode = settingManager.GetSearchMode();
        for (int i = 0;i < itemCount; i++)
        {
            if (!attributes.Contains(powerUps[i].CardAttribute)) { continue; }
            if (!powerUps[i].Race.Any(x => races.Contains(x))) { continue; }
            if (searchMode == SearchMode.Found)
            {
                if (!ZukanDataPrefs.FoundCell[powerUps[i].CardName]) { continue; }
            }
            if (searchMode == SearchMode.NotFound)
            {
                if (ZukanDataPrefs.FoundCell[powerUps[i].CardName]) { continue; }
            }
            var cardItem = Instantiate(CardItem);
            var buyItem = cardItem.GetComponent<CardShopBuyItem>();
            buyItem.SetItemData(new PowerUpCard(powerUps[i]));
            buyItem.SetSelectedEvent((int price) =>
            {
                sum.text = $"{int.Parse(sum.text) + price}";
            });
            buyItem.SetUnselectedEvent((int price) =>
            {
                sum.text = $"{int.Parse(sum.text) - price}";
            });
            cardItem.transform.parent = parent;
        }
    }

    public void MakeCoreCardList()
    {
        ResetList();
        var parent = transform.Find("Scroll View/Viewport/Content");
        int itemCount = magicTypes.Length;
        var attributes = settingManager.GetAttributes();
        var races = settingManager.GetCardRaces();
        var searchMode = settingManager.GetSearchMode();
        for (int i = 0; i < itemCount; i++)
        {
            if (!attributes.Contains(magicTypes[i].CardAttribute)) { continue; }
            if (!magicTypes[i].Race.Any(x => races.Contains(x))) { continue; }
            if(searchMode == SearchMode.Found)
            {
                var cashedPrefs = ZukanDataPrefs.FoundCore;
                var cashedName = magicTypes[i].CardName;
                if (!cashedPrefs[cashedName]) { continue; }
            }
            if (searchMode == SearchMode.NotFound)
            {
                if (ZukanDataPrefs.FoundCore[magicTypes[i].CardName]) { continue; }
            }
            var cardItem = Instantiate(CardItem);
            var buyItem = cardItem.GetComponent<CardShopBuyItem>();
            buyItem.SetItemData(new MagicTypeCard(magicTypes[i]));
            buyItem.SetSelectedEvent((int price) =>
            {
                sum.text = $"{int.Parse(sum.text) + price}";
            });
            buyItem.SetUnselectedEvent((int price) =>
            {
                sum.text = $"{int.Parse(sum.text) - price}";
            });
            cardItem.transform.parent = parent;
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
            var buyitem = parent.GetChild(i).gameObject.GetComponent<CardShopBuyItem>();
            if (buyitem.IsSelected)
            {
                sum += buyitem.GetPrice;
                boughtCards.Add(buyitem.GetCard);
            }
        }
        if (!money.CanPay(sum)) { return; }
        foreach (var boughtcard in boughtCards)
        {
            store.AddCard(boughtcard);
            if(boughtcard is MagicTypeCard magicTypeCard)
            {
                ZukanDataPrefs.FoundCore[magicTypeCard.CardName] = true;
            }
            if(boughtcard is PowerUpCard powerUpCard)
            {
                ZukanDataPrefs.FoundCell[powerUpCard.CardName] = true;
            }
        }
        ZukanDataPrefs.Save();
        money.Pay(sum);

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
        for(int i = 0;i < itemCount; i++)
        {
            GameObject.Destroy(parent.GetChild(i).gameObject);
        }
    }

    public void Settings()
    {
        settingManager.Open();
    }
}
