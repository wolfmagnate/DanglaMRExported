using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public static class GachaSystem
{
    public static CardPack[] LoadAllCardPack() => Resources.LoadAll<CardPack>("Project/CardPack");

    /// <summary>
    /// カードパックからランダムにMagicCardを取得して生成
    /// </summary>
    /// <param name="pack">カードパック</param>
    /// <returns>作成したMagicCard</returns>
    public static MagicCard Play(CardPack pack)
    {
        if (! DegitalCardPlayer.GetDegitalCardPlayer().GetMoneyManager().CanPay(pack.Price))
        {
            return null;
        }

        DegitalCardPlayer.GetDegitalCardPlayer().GetMoneyManager().Pay(pack.Price);

        float max = 0;
        max += pack.MagicTypePossibilities.Sum();
        max += pack.PowerUpPossibilities.Sum();

        float rand = Random.Range(0, max);

        float temp = 0;
        for (int i = 0; i < pack.MagicTypePossibilities.Count; i++)
        {
            temp += pack.MagicTypePossibilities[i];
            if(temp >= rand)
            {
                return new MagicTypeCard(pack.MagicTypeContents[i]);
            }
        }
        for (int i = 0; i < pack.PowerUpPossibilities.Count; i++)
        {
            temp += pack.PowerUpPossibilities[i];
            if(temp >= rand)
            {
                return new PowerUpCard(pack.PowerUpContents[i]);
            }
        }
        return new PowerUpCard(pack.PowerUpContents.Last());
    }
}
