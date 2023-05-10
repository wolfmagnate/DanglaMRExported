using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Shop
{

    public static void BuyMagicTypeCard(IDegitalCardPlayer player, MagicType magicType)
    {
        if (player.GetMoneyManager().CanPay(magicType.BuyPrice))
        {
            player.GetMoneyManager().Pay(magicType.BuyPrice);
            player.GetCardStore().AddCard(new MagicTypeCard(magicType));
        }
    }
    public static void BuyPowerUpCard(IDegitalCardPlayer player, PowerUp powerUp)
    {
        if (player.GetMoneyManager().CanPay(powerUp.BuyPrice))
        {
            player.GetMoneyManager().Pay(powerUp.BuyPrice);
            player.GetCardStore().AddCard(new PowerUpCard(powerUp));
        }
    }
    
    public static void SellCard(IDegitalCardPlayer player, MagicCard magicCard)
    {
        if(player.GetCardStore().cardsOfPlayer.ContainsKey(magicCard.CardName) && player.GetCardStore().cardsOfPlayer[magicCard.CardName].Count > 0)
        {
            player.GetCardStore().RemoveCard(magicCard);
            player.GetMoneyManager().Gain(magicCard.SellPrice);
        }
    }

    private static MagicType[] cashMagicCards;
    private static PowerUp[] cashPowerUpCards;
            
    // ショップUI作成用メソッドたち
    public static MagicType[] LoadAllMagicType()
    {       
        if(cashMagicCards == null)
        {
            cashMagicCards = Resources.LoadAll<MagicType>("Project/MagicTypeCards");
        }
        return cashMagicCards;
    }       
            
    public static PowerUp[] LoadAllPowerUp()
    {
        if (cashPowerUpCards == null)
        {
            cashPowerUpCards = Resources.LoadAll<PowerUp>("Project/PowerUpCards");
        }
        return cashPowerUpCards;
    }       
}
