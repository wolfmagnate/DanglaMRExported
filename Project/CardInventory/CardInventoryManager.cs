using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardInventoryManager : MonoBehaviour
{
    public GameObject InventoryListItem;
    GameObject InventoryContent;
    InventoryOrderCanvas orderCanvas;

    void Start()
    {
        InventoryContent = transform.Find("InventoryList/Viewport/Content").gameObject;
        orderCanvas = GameObject.Find("OrderCanvas").GetComponent<InventoryOrderCanvas>();
    }

    public void MakeCoreList()
    {
        MenuSESoundManager.Instance.PlayClick();
        ResetList();
        AddCoreList();
    }

    public void MakeCellList()
    {
        MenuSESoundManager.Instance.PlayClick();
        ResetList();
        AddCellList();
    }

    void ResetList()
    {
        for (int i = 0; i < InventoryContent.transform.childCount; i++)
        {
            Destroy(InventoryContent.transform.GetChild(i).gameObject);
        }
    }

    void AddCoreList()
    {
        var cardStore = DegitalCardPlayer.GetDegitalCardPlayer().GetCardStore();
        var displayAttributes = orderCanvas.GetDisplayAttributes();
        var displayRaces = orderCanvas.GetCardRaces();
        foreach (var pair in cardStore.cardsOfPlayer)
        {
            if (!(displayAttributes.Contains(pair.Value[0].CardAttribute) && pair.Value[0].Race.Any(race => displayRaces.Contains(race)))) { continue; }
            if(pair.Value[0] is MagicTypeCard magicTypeCard)
            {
                var listItem = CreateCoreCardItem(magicTypeCard, pair.Value.Count);
                listItem.transform.parent = InventoryContent.transform;
            }
        }
    }

    GameObject CreateCoreCardItem(MagicTypeCard magicType, int cardCount)
    {
        var ans = Instantiate(InventoryListItem);
        ans.transform.Find("Icon/Image").GetComponent<Image>().sprite = magicType.GetIcon();
        ans.transform.Find("Name").GetComponent<Text>().text = magicType.CardName;
        ans.transform.Find("Number").GetComponent<Text>().text = $"{cardCount}枚";
        ans.transform.Find("Standard").GetComponent<Text>().text = string.Join("/", magicType.Race.Select(race => CardRaceToText(race)));
        ans.transform.Find("Attribute").GetComponent<Text>().text = CardAttributeToText(magicType.CardAttribute);
        return ans;
    }

    void AddCellList()
    {
        var cardStore = DegitalCardPlayer.GetDegitalCardPlayer().GetCardStore();
        var displayAttributes = orderCanvas.GetDisplayAttributes();
        var displayRaces = orderCanvas.GetCardRaces();
        foreach (var pair in cardStore.cardsOfPlayer)
        {
            if (!(displayAttributes.Contains(pair.Value[0].CardAttribute) && pair.Value[0].Race.Any(race => displayRaces.Contains(race)))) { continue; }
            if(pair.Value[0] is PowerUpCard powerUpCard)
            {
                var listItem = CreateCellCardItem(powerUpCard, pair.Value.Count);
                listItem.transform.parent = InventoryContent.transform;
            }
        }
    }

    GameObject CreateCellCardItem(PowerUpCard powerUp, int cardCount)
    {
        var ans = Instantiate(InventoryListItem);
        ans.transform.Find("Icon/Image").GetComponent<Image>().sprite = powerUp.GetIcon();
        ans.transform.Find("Name").GetComponent<Text>().text = powerUp.CardName;
        ans.transform.Find("Number").GetComponent<Text>().text = $"{cardCount}枚";
        ans.transform.Find("Standard").GetComponent<Text>().text = string.Join("/", powerUp.Race.Select(race => CardRaceToText(race)));
        ans.transform.Find("Attribute").GetComponent<Text>().text = CardAttributeToText(powerUp.CardAttribute);
        return ans;
    }

    public void OpenSettings()
    {
        MenuSESoundManager.Instance.PlayOK();
        ResetList();
        orderCanvas.Open();
    }

    string CardRaceToText(CardRace race)
    {
        return race switch
        {
            CardRace.experimental => "プロトタイプ規格",
            CardRace.direction => "ディレクショナテナ規格",
            CardRace.connection => "コネクテミス規格",
            CardRace.freedom => "フリーリス規格",
            CardRace.position => "コーディネア―規格",
            CardRace.number => "アスペクトライトス規格",
            CardRace.order => "オーダレス規格",
            CardRace.cheat => "グリーデミゴッド規格",
            _ => "そんなのないよ",
        };
    }

    string CardAttributeToText(MagicAttribute attribute)
    {
        return attribute switch
        {
            MagicAttribute.Wind => "風属性",
            MagicAttribute.Lightning => "雷属性",
            MagicAttribute.Tree => "木属性",
            MagicAttribute.Water => "水属性",
            MagicAttribute.Fire => "炎属性",
            MagicAttribute.Ice => "氷属性",
            MagicAttribute.Mountain => "山属性",
            MagicAttribute.Metal => "鋼属性",
            MagicAttribute.Light => "光属性",
            MagicAttribute.Darkness => "闇属性",
            MagicAttribute.Nothing => "無属性",
            _ => "そんなのないよ",
        };
    }
}
