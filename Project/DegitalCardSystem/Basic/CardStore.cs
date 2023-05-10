using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardStore
{
    private readonly static string SaveCardID = "sbvfxdgse5y6yt5pqag57h1rrgjsrgfonyu7";
    private readonly static string SaveNameID = "sbvfxdgse5y6yt5pnfbjgnmcftjgrei0yyn4";

    private static string ToJSON(CardStore cardStore) => JsonUtility.ToJson(cardStore);

    /// <summary>
    /// プレイヤーの所持カードリストの保存をする
    /// </summary>
    /// <param name="cardStore">保存したい所持カードリスト</param>
    public static void Save(CardStore cardStore)
    {
        CardStoreCardWrapper cardList = new CardStoreCardWrapper();
        cardList.cardsList = new List<CardStoreCardWrapperWrapper>();
        CardStoreNameWrapper nameList = new CardStoreNameWrapper();
        nameList.names = new List<string>();
        foreach (var pair in cardStore.cardsOfPlayer)
        {
            cardList.cardsList.Add(new CardStoreCardWrapperWrapper(pair.Value));
            nameList.names.Add(pair.Key);
        }
        string JsonedCardList = JsonUtility.ToJson(cardList);
        PlayerPrefs.SetString(SaveCardID, JsonedCardList);
        string JsonedNameList = JsonUtility.ToJson(nameList);
        PlayerPrefs.SetString(SaveNameID, JsonedNameList);
    }

    /// <summary>
    /// PlayerPrefsから所持カードリストを読み込む
    /// </summary>
    /// <returns>前回保存した所持カードリスト</returns>
    public static CardStore Load()
    {
        if (cashed == null)
        {
            if (PlayerPrefs.HasKey(CardStore.SaveCardID))
            {
                cashed = new CardStore();
                var cardList = JsonUtility.FromJson<CardStoreCardWrapper>( PlayerPrefs.GetString(SaveCardID));
                var nameList = JsonUtility.FromJson<CardStoreNameWrapper>(PlayerPrefs.GetString(SaveNameID));
                for(int i = 0;i < cardList.cardsList.Count; i++)
                {
                    var cardName = cardList.cardsList[i].cardName;
                    var list = GenerateListFromCardName(cardName, cardList.cardsList[i].cardNumber);
                    cashed.cardsOfPlayer[nameList.names[i]] = list;
                }
            }
            else
            {
                cashed = new CardStore();
                var coreCard = Resources.Load<MagicType>("Project/MagicTypeCards/DemoFireStraight1");
                cashed.AddCard(new MagicTypeCard(coreCard));
                var cellCard1 = Resources.Load<PowerUp>("Project/PowerUpCards/DemoPUFreedomAttackBoost1");
                cashed.AddCard(new PowerUpCard(cellCard1));
                var cellCard2 = Resources.Load<PowerUp>("Project/PowerUpCards/DemoPUNumberRushIntervalReduction1");
                cashed.AddCard(new PowerUpCard(cellCard2));
                var cellCard3 = Resources.Load<PowerUp>("Project/PowerUpCards/DemoPUPositionMPReduction1");
                cashed.AddCard(new PowerUpCard(cellCard3));
                var cellCard4 = Resources.Load<PowerUp>("Project/PowerUpCards/NumberConnectionMRanDis1");
                cashed.AddCard(new PowerUpCard(cellCard4));
                ZukanDataPrefs.Load();
                ZukanDataPrefs.FoundCore[coreCard.CardName] = true;
                ZukanDataPrefs.FoundCell[cellCard1.CardName] = true;
                ZukanDataPrefs.FoundCell[cellCard2.CardName] = true;
                ZukanDataPrefs.FoundCell[cellCard3.CardName] = true;
                ZukanDataPrefs.FoundCell[cellCard4.CardName] = true;
                ZukanDataPrefs.Save();
            }
        }
        return cashed;
    }

    static List<MagicCard> GenerateListFromCardName(string cardName, int number)
    {
        List<MagicCard> ans = new List<MagicCard>();
        var magicTypes = Resources.LoadAll<MagicType>("Project/MagicTypeCards");
        var powerUps = Resources.LoadAll<PowerUp>("Project/PowerUpCards");
        foreach(var magicType in magicTypes)
        {
            if( magicType.CardName == cardName)
            {
                for(int i = 0;i < number; i++)
                {
                    ans.Add(new MagicTypeCard(magicType));
                }
                return ans;
            }
        }
        foreach(var powerUp in powerUps)
        {
            if(powerUp.CardName == cardName)
            {
                for(int i = 0;i < number; i++)
                {
                    ans.Add(new PowerUpCard(powerUp));
                }
                return ans;
            }
        }
        return ans;
    }

    static CardStore cashed = null;

    public static bool HasSaveData() => PlayerPrefs.HasKey(SaveCardID);

    public Dictionary<string, List<MagicCard>> cardsOfPlayer = new Dictionary<string, List<MagicCard>>();


    public void AddCard(MagicCard card)
    {
        if (cardsOfPlayer.ContainsKey(card.CardName))
        {
            cardsOfPlayer[card.CardName].Add(card);
        }
        else
        {
            cardsOfPlayer.Add(card.CardName, new List<MagicCard>() { card });
        }
    }

    /// <summary>
    /// カードを1枚減らす。0枚になった場合存在を抹消する。
    /// もし存在しないカードを減らそうとした場合には何もしない。
    /// </summary>
    /// <param name="card">減らしたいカード</param>
    public void RemoveCard(MagicCard card)
    {
        RemoveCard(card.CardName);
    }


    /// <summary>
    /// カードを1枚減らす。0枚になった場合存在を抹消する。
    /// もし存在しないカードを減らそうとした場合には何もしない。
    /// </summary>
    /// <param name="card">減らしたいカードのAssetファイル名(.assetを除く)</param>
    public void RemoveCard(string cardName)
    {
        if (!cardsOfPlayer.ContainsKey(cardName))
        {
            return;
        }
        // 戦闘から削除するとコピーコストがかかる
        cardsOfPlayer[cardName].RemoveAt(cardsOfPlayer[cardName].Count - 1);
        if (cardsOfPlayer[cardName].Count == 0)
        {
            cardsOfPlayer.Remove(cardName);
        }
    }

    public int this[string cardName]
    {
        get
        {
            if (!cardsOfPlayer.ContainsKey(cardName)) { return 0; }
            return cardsOfPlayer[cardName].Count;
        }
    }

    /// <summary>
    /// 特定のカードの所持枚数を返す
    /// </summary>
    /// <param name="card"></param>
    /// <returns></returns>
    public int this[MagicCard card] => this[card.CardName];


    /// <summary>
    /// 特定のカードを特定の枚数だけ取得する。
    /// もしもそのカードが指定した枚数分無ければnull
    /// </summary>
    /// <param name="cardName">取得したいカードの名前</param>
    /// <param name="number">取得したい枚数</param>
    /// <returns>指定したカードの配列</returns>
    public MagicCard[] this[string cardName, int number]
    {
        get
        {
            if (!cardsOfPlayer.ContainsKey(cardName)) { return null; }
            if (cardsOfPlayer[cardName].Count < number) { return null; }
            return cardsOfPlayer[cardName].GetRange(0, number).ToArray();
        }
    }

    /// <summary>
    /// 特定のカードを特定の枚数だけ取得する。
    /// もしもそのカードが指定した枚数分無ければnull
    /// </summary>
    /// <param name="card">取得したいカード</param>
    /// <param name="number">取得したい枚数</param>
    /// <returns>指定したカードの配列</returns>
    public MagicCard[] this[MagicCard card, int number] => this[card.CardName, number];

}


[System.Serializable]
public class CardStoreCardWrapper
{
    public List<CardStoreCardWrapperWrapper> cardsList;
}

[System.Serializable]
public class CardStoreNameWrapper
{
    public List<string> names;
}

[System.Serializable]
public class CardStoreCardWrapperWrapper
{
    public string cardName;
    public int cardNumber;

    public CardStoreCardWrapperWrapper(List<MagicCard> value)
    {
        cardName = value[0].CardName;
        cardNumber = value.Count;
    }
}