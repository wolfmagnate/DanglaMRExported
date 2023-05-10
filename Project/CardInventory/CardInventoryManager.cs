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
        ans.transform.Find("Number").GetComponent<Text>().text = $"{cardCount}��";
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
        ans.transform.Find("Number").GetComponent<Text>().text = $"{cardCount}��";
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
            CardRace.experimental => "�v���g�^�C�v�K�i",
            CardRace.direction => "�f�B���N�V���i�e�i�K�i",
            CardRace.connection => "�R�l�N�e�~�X�K�i",
            CardRace.freedom => "�t���[���X�K�i",
            CardRace.position => "�R�[�f�B�l�A�\�K�i",
            CardRace.number => "�A�X�y�N�g���C�g�X�K�i",
            CardRace.order => "�I�[�_���X�K�i",
            CardRace.cheat => "�O���[�f�~�S�b�h�K�i",
            _ => "����Ȃ̂Ȃ���",
        };
    }

    string CardAttributeToText(MagicAttribute attribute)
    {
        return attribute switch
        {
            MagicAttribute.Wind => "������",
            MagicAttribute.Lightning => "������",
            MagicAttribute.Tree => "�ؑ���",
            MagicAttribute.Water => "������",
            MagicAttribute.Fire => "������",
            MagicAttribute.Ice => "�X����",
            MagicAttribute.Mountain => "�R����",
            MagicAttribute.Metal => "�|����",
            MagicAttribute.Light => "������",
            MagicAttribute.Darkness => "�ő���",
            MagicAttribute.Nothing => "������",
            _ => "����Ȃ̂Ȃ���",
        };
    }
}
