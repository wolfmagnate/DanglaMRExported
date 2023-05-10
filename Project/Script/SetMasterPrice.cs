using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SetMasterPrice
{
    /**
    public static void Create()
    {
        var pack1 = AssetDatabase.LoadAssetAtPath<CardPack>("Assets/Resources/Project/CardPack/CardPack1.asset");
        var pack2 = AssetDatabase.LoadAssetAtPath<CardPack>("Assets/Resources/Project/CardPack/CardPack2.asset");
        var pack3 = AssetDatabase.LoadAssetAtPath<CardPack>("Assets/Resources/Project/CardPack/CardPack3.asset");
        pack1.PowerUpContents.Clear();
        pack1.PowerUpPossibilities.Clear();
        pack1.MagicTypeContents.Clear();
        pack1.MagicTypePossibilities.Clear();
        pack2.PowerUpContents.Clear();
        pack2.PowerUpPossibilities.Clear();
        pack2.MagicTypeContents.Clear();
        pack2.MagicTypePossibilities.Clear();
        pack3.PowerUpContents.Clear();
        pack3.PowerUpPossibilities.Clear();
        pack3.MagicTypeContents.Clear();
        pack3.MagicTypePossibilities.Clear();
        int i = 0;
        // magictypeÇëSïîì«Ç›çûÇﬁ
        foreach (var path in Directory.GetFiles("Assets/Resources/Project/MagicTypeCards"))
        {
            if (path.Contains(".meta")) { continue; }
            string newpath = path.Replace("Assets/Resources/Project/MagicTypeCards\\", "").Replace(".asset","");
            MagicType magicType = AssetDatabase.LoadAssetAtPath<MagicType>(path);
            Rarity rarity = GetRarityOfMagicCard(magicType, newpath);
            rarity.SetPrice(magicType);
            if(i > 0 && i < 11)
            {
                pack1.MagicTypeContents.Add(magicType);
                pack1.MagicTypePossibilities.Add(rarity.GetPossibility());
            }
            if(i > 10 && i < 21)
            {
                pack2.MagicTypeContents.Add(magicType);
                pack2.MagicTypePossibilities.Add(rarity.GetPossibility());

            }
            if(i > 20 && i < 31)
            {
                pack3.MagicTypeContents.Add(magicType);
                pack3.MagicTypePossibilities.Add(rarity.GetPossibility());
            }
            i++;
        }
        i = 0;
        // powerupÇëSïîì«Ç›çûÇﬁ
        foreach (var path in Directory.GetFiles("Assets/Resources/Project/PowerUpCards"))
        {
            if (path.Contains(".meta")) { continue; }
            string newpath = path.Replace("Assets/Resources/Project/PowerUpCards\\", "").Replace(".asset", "");
            PowerUp magicType = AssetDatabase.LoadAssetAtPath<PowerUp>(path);
            Rarity rarity = GetRarityOfPowerUp(magicType, newpath);
            rarity.SetPrice(magicType);
            if(i >= 0 && i <= 42)
            {
                pack1.PowerUpContents.Add(magicType);
                pack1.PowerUpPossibilities.Add(rarity.GetPossibility());
            }
            if(i >= 43 && i <= 85)
            {
                pack2.PowerUpContents.Add(magicType);
                pack2.PowerUpPossibilities.Add(rarity.GetPossibility());
            }
            if(i > 85)
            {
                pack3.PowerUpContents.Add(magicType);
                pack3.PowerUpPossibilities.Add(rarity.GetPossibility());
            }
            i++;
        }
    }

    private static Rarity GetRarityOfMagicCard(MagicType magicType, string fileName)
    {
        if((magicType.Race.Contains(CardRace.freedom) || magicType.Race.Contains(CardRace.experimental)) && fileName.Contains("Demo"))
        {
            return new C();
        }
        if((magicType.Race.Contains(CardRace.freedom) || magicType.Race.Contains(CardRace.experimental)) && (!fileName.Contains("Demo")))
        {
            return new UC();
        }
        if (magicType.Race.Contains(CardRace.cheat))
        {
            return new UR();
        }
        if(magicType.Race.Count > 1)
        {
            return new SR();
        }
        return new R();
    }

    private static Rarity GetRarityOfPowerUp(PowerUp powerUp, string fileName)
    {
        if ((powerUp.Race.Contains(CardRace.freedom) || powerUp.Race.Contains(CardRace.experimental)) && fileName.Contains("Demo"))
        {
            return new C();
        }
        if ((powerUp.Race.Contains(CardRace.freedom) || powerUp.Race.Contains(CardRace.experimental)) && (!fileName.Contains("Demo")))
        {
            return new UC();
        }
        if (powerUp.Race.Contains(CardRace.cheat))
        {
            return new UR();
        }
        if (powerUp.Race.Count > 1)
        {
            return new SR();
        }
        return new R();
    }
}

public abstract class Rarity
{
    public abstract void PrintRarity();

    public abstract void SetPrice(MagicType magicType);

    public abstract void SetPrice(PowerUp magicType);

    public abstract float GetPossibility();
}

public class UR : Rarity
{
    public override float GetPossibility()
    {
        return 2.5f;
    }

    public override void PrintRarity()
    {
        Debug.Log("UR");
    }

    public override void SetPrice(MagicType magicType)
    {
        magicType.BuyPrice = 5000;
        magicType.SellPrice = 1000;
    }

    public override void SetPrice(PowerUp magicType)
    {
        magicType.BuyPrice = 5000;
        magicType.SellPrice = 1000;
    }
}

public class SR : Rarity
{
    public override float GetPossibility()
    {
        return 7.5f;
    }

    public override void PrintRarity()
    {
        Debug.Log("SR");
    }

    public override void SetPrice(MagicType magicType)
    {
        magicType.SellPrice = 600;
        magicType.BuyPrice = 3000;
    }

    public override void SetPrice(PowerUp magicType)
    {
        magicType.SellPrice = 600;
        magicType.BuyPrice = 3000;
    }
}
public class R : Rarity
{
    public override float GetPossibility()
    {
        return 20;
    }

    public override void PrintRarity()
    {
        Debug.Log("R");
    }

    public override void SetPrice(MagicType magicType)
    {
        magicType.SellPrice = 200;
        magicType.BuyPrice = 1000;
    }

    public override void SetPrice(PowerUp magicType)
    {
        magicType.SellPrice = 200;
        magicType.BuyPrice = 1000;
    }
}

public class UC : Rarity
{
    public override float GetPossibility()
    {
        return 30;
    }

    public override void PrintRarity()
    {
        Debug.Log("UC");
    }

    public override void SetPrice(MagicType magicType)
    {
        magicType.BuyPrice = 500;
        magicType.SellPrice = 100;
    }

    public override void SetPrice(PowerUp magicType)
    {
        magicType.BuyPrice = 500;
        magicType.SellPrice = 100;
    }
}

public class C : Rarity
{
    public override float GetPossibility()
    {
        return 40;
    }

    public override void PrintRarity()
    {
        Debug.Log("C");
    }

    public override void SetPrice(MagicType magicType)
    {
        magicType.BuyPrice = 300;
        magicType.SellPrice = 60;
    }

    public override void SetPrice(PowerUp magicType)
    {
        magicType.BuyPrice = 300;
        magicType.SellPrice = 60;
    }
}
    */
}