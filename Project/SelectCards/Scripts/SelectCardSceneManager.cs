using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectCardSceneManager : MonoBehaviour
{
    CardStore store;
    int PowerUpCardNumber;
    int MagicTypeCardNumber;

    public GameObject ListItem;

    List<string> selectedNames;
    MagicCard[] SelectedCards;

    public Sprite DefaultIcon;

    SelectCardsSettingsManager settings;

    enum CurrentSelectCardMode
    {
        none, cell, core
    }

    CurrentSelectCardMode mode = CurrentSelectCardMode.none;

    // Start is called before the first frame update
    void Start()
    {
        store = DegitalCardPlayer.GetDegitalCardPlayer().GetCardStore();
        MagicTypeCardNumber = store.cardsOfPlayer.Values.Where(x => x.All(item => item is MagicTypeCard)).Sum(x => x.Count);
        PowerUpCardNumber = store.cardsOfPlayer.Values.Where(x => x.All(item => item is PowerUpCard)).Sum(x => x.Count);
        selectedNames = new List<string>();
        SelectedCards = new MagicCard[5];
        settings = GameObject.Find("OrderCanvas").GetComponent<SelectCardsSettingsManager>();
    }

    public void MakeCellCardList()
    {
        MenuSESoundManager.Instance.PlayClick();
        mode = CurrentSelectCardMode.cell;
        ResetList();
        List<string> madeNameList = new List<string>();
        var attributes = settings.GetAttributes();
        var cardRaces = settings.GetCardRaces();
        foreach (List<MagicCard> cardList in store.cardsOfPlayer.Values)
        {
            foreach(var card in cardList)
            {
                if(selectedNames.Contains(card.CardName) && madeNameList.Count(x => x == card.CardName) != selectedNames.Count(x => x == card.CardName))
                {
                    madeNameList.Add(card.CardName);
                    continue;
                }
                if (card is PowerUpCard)
                {
                    PowerUpCard cashedCard = card as PowerUpCard;
                    if (!(attributes.Contains(card.CardAttribute) && card.Race.Any(x => cardRaces.Contains(x)))) { continue; }
                    var icon = card.GetIcon();
                    var listItem = Instantiate(ListItem);
                    listItem.GetComponent<RectTransform>().SetParent(transform.Find("CardBoard/Scroll View/Viewport/Content"));
                    listItem.GetComponent<Image>().sprite = icon;
                    listItem.GetComponent<Button>().onClick.AddListener(() =>
                    {
                        MenuSESoundManager.Instance.PlayClick();
                        AddCellCardToList(cashedCard);
                        MakeCellCardList();
                    });
                }
            }
        }
    }

    public void MakeCoreCardList()
    {
        MenuSESoundManager.Instance.PlayClick();
        mode = CurrentSelectCardMode.core;
        ResetList();
        List<string> madeNameList = new List<string>();
        var attributes = settings.GetAttributes();
        var cardRaces = settings.GetCardRaces();
        var moveTypes = settings.GetMoveTypes();
        foreach (List<MagicCard> cardList in store.cardsOfPlayer.Values)
        {
            foreach(var card in cardList)
            {
                if (selectedNames.Contains(card.CardName) && madeNameList.Count(x => x == card.CardName) != selectedNames.Count(x => x == card.CardName))
                {
                    madeNameList.Add(card.CardName);
                    continue;
                }
                if(card is MagicTypeCard)
                {
                    MagicTypeCard cashedCard = card as MagicTypeCard;
                    if (!(attributes.Contains(card.CardAttribute) && card.Race.Any(x => cardRaces.Contains(x)) && moveTypes.Contains(cashedCard.MoveType))) { continue; }
                    var icon = card.GetIcon();
                    var listItem = Instantiate(ListItem);
                    listItem.GetComponent<RectTransform>().SetParent(transform.Find("CardBoard/Scroll View/Viewport/Content"));
                    listItem.GetComponent<Image>().sprite = icon;
                    listItem.GetComponent<Button>().onClick.AddListener(() =>
                    {
                        if (SelectedCards.Count(x => x is MagicTypeCard) == 1) { return; }
                        MenuSESoundManager.Instance.PlayClick();
                        AddCoreCardToList(cashedCard);
                        MakeCoreCardList();
                    });
                }
            }
        }
    }

    void AddCellCardToList(PowerUpCard powerUpCard)
    {
        for (int i = 0; i < 5; i++)
        {
            if (SelectedCards[i] == null)
            {
                SelectedCards[i] = powerUpCard;
                break;
            }
        }
        MakeCardList();
    }

    void AddCoreCardToList(MagicTypeCard magicTypeCard)
    {
        if (SelectedCards.Count(x => x is MagicTypeCard) == 1) { return; }

        for(int i = 0;i < 5; i++)
        {
            if(SelectedCards[i] == null)
            {
                SelectedCards[i] = magicTypeCard;
                break;
            }
        }
        MakeCardList();
    }

    void MakeCardList()
    {
        selectedNames.Clear();
        for(int i = 0;i < 5; i++)
        {
            GameObject cardItem = transform.Find($"SelectedCard/Card{i + 1}").gameObject;
            if (SelectedCards[i] != null)
            {
                var icon = SelectedCards[i].GetIcon();
                cardItem.transform.Find("ThumbnailMask/Thumbnail").gameObject.GetComponent<Image>().sprite = icon;
                cardItem.transform.Find("Cancel").gameObject.SetActive(true);
                selectedNames.Add(SelectedCards[i].CardName);
            }
            else
            {
                Sprite icon = DefaultIcon;
                cardItem.transform.Find("ThumbnailMask/Thumbnail").gameObject.GetComponent<Image>().sprite = icon;
            }
        }
        if(SelectedCards.All(x => x != null))
        {
            DisplayOKButton();
        }
    }

    void ResetList()
    {
        var parent = transform.Find("CardBoard/Scroll View/Viewport/Content");
        for(int i = 0;i < parent.childCount; i++)
        {
            Destroy(parent.GetChild(i).gameObject);
        }
    }

    public void CancelSelect(int index)
    {
        MenuSESoundManager.Instance.PlayCancel();
        SelectedCards[index] = null;
        HideOKButton();
        MakeCardList();
        ResetList();
        transform.Find($"SelectedCard/Card{index + 1}/Cancel").gameObject.SetActive(false);
        if(mode == CurrentSelectCardMode.core)
        {
            MakeCoreCardList();
        }
        if (mode == CurrentSelectCardMode.cell)
        {
            MakeCellCardList();
        }
    }

    void DisplayOKButton()
    {
        transform.Find("OK").gameObject.SetActive(true);
    }

    void HideOKButton()
    {
        transform.Find("OK").gameObject.SetActive(false);
    }

    public void OK()
    {
        SetMagicCards.magicCards = new MagicCard[5, 5];
        for (int i = 0; i < 5; i++)
        {
            SetMagicCards.magicCards[0, i] = SelectedCards[i];
        }
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/CreateMagic/CreateMagic");
    }

    public void ToSettings()
    {
        settings.Open();
        MenuSESoundManager.Instance.PlayOK();
        ResetList();
    }
}
