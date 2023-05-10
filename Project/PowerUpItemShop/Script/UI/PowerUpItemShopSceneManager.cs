using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PowerUpItemShopSceneManager : MonoBehaviour
{
    public GameObject ShopItem;
    public GameObject Dummy;
    PowerUpItemMasterData[] shopItemData;
    GameObject content;
    Text money;
    MoneyManager moneyManager;
    // Start is called before the first frame update
    void Start()
    {
        shopItemData = Resources.LoadAll<PowerUpItemMasterData>("Project/PowerUpItemShop/ShopItem");
        content = GameObject.Find("Canvas/Scroll View/Viewport/Content");
        var dummy = Instantiate(Dummy);
        dummy.transform.parent = content.transform;
        List<GameObject> panels = new List<GameObject>();
        foreach(var itemdata in shopItemData)
        {
            GameObject itemPanel = Instantiate(ShopItem);
            panels.Add(itemPanel);

            var panelOrder = itemPanel.AddComponent<PowerUpShopItemPanel>();

            string IsBought;
            if (PowerUpItemShop.HasBought(itemdata))
            {
                itemPanel.transform.Find("Button").GetComponent<Button>().enabled = false;
                panelOrder.Sold = true;
                IsBought = "Sold out";
            }
            else
            {
                IsBought = "Buy";
                panelOrder.Sold = false;
                Text childText = itemPanel.transform.Find("Button/Text").gameObject.GetComponent<Text>();
                Button childButton = itemPanel.transform.Find("Button").gameObject.GetComponent<Button>();
                childButton.onClick.AddListener(() =>
                {
                    if (!moneyManager.CanPay(itemdata.Price)
                    || PowerUpItemShop.HasBought(itemdata)) { return; }
                    MenuSESoundManager.Instance.PlayMoney();
                    PowerUpItemShop.Buy(itemdata, moneyManager);
                    RefreshMoney();
                    childText.text = "Sold out";
                    childButton.enabled = false;
                });
            }
            itemPanel.transform.Find("Button/Text").gameObject.GetComponent<Text>().text = IsBought;
            
            int price = itemdata.Price;
            panelOrder.Price = price;
            itemPanel.transform.Find("Price").gameObject.GetComponent<Text>().text = $"${price}";

            string ItemName = itemdata.Name;
            itemPanel.transform.Find("Title").gameObject.GetComponent<Text>().text = ItemName;

            var effect = itemdata.Effect;
            string EffectText = "";
            if(effect.Target == PowerUpItemTarget.Attack)
            {
                EffectText = $"Attack +{Mathf.RoundToInt(effect.PowerUpValue * 100)}%";
            }
            if(effect.Target == PowerUpItemTarget.HP)
            {
                EffectText = $"HP +{effect.PowerUpValue}";
            }
            if (effect.Target == PowerUpItemTarget.MP)
            {
                EffectText = $"MP +{effect.PowerUpValue}";
            }
            itemPanel.transform.Find("Effect").gameObject.GetComponent<Text>().text = EffectText;
        }
        foreach(var panel in panels.OrderBy(x => x.GetComponent<PowerUpShopItemPanel>().Index))
        {
            panel.transform.parent = content.transform;
        }
        dummy = Instantiate(Dummy);
        dummy.transform.parent = content.transform;

        money = GameObject.Find("Canvas/StatusBoard/Number").GetComponent<Text>();
        moneyManager = MoneyManager.Load();
        RefreshMoney();
    }

    public void RefreshMoney()
    {
        money.text = $"{moneyManager.Money}";
    }
}
