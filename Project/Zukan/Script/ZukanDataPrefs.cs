using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ZukanDataPrefs
{
    public static string coreID = "dljbrnkjbj03n4tnbt4sgxekts";
    public static string cellID = "awxeaq3i4xtucgj@bldtyotd";
    public static string virusID = "nltjgmkkltmhr90i4jygno3w8utng4";

    public static void Save()
    {
        var magictypes = Resources.LoadAll<ZukanMagicType>("Project/Zukan/MagicTypeCards");
        var powerups = Resources.LoadAll<ZukanPowerUp>("Project/Zukan/PowerUpCards");
        var viruses = Resources.LoadAll<ZukanEnemy>("Project/Zukan/Enemy");

        for (int i = 0; i < magictypes.Length; i++)
        {
            string cardName = magictypes[i].magicType.CardName;
            if (FoundCore[cardName])
            {
                PlayerPrefs.SetInt($"{coreID}_{cardName}", 1);
            }
            else
            {
                PlayerPrefs.SetInt($"{coreID}_{cardName}", 0);
            }
        }
        for (int i = 0; i < powerups.Length; i++)
        {
            string cardName = powerups[i].powerUp.CardName;
            if (FoundCell[cardName])
            {
                PlayerPrefs.SetInt($"{cellID}_{cardName}", 1);
            }
            else
            {
                PlayerPrefs.SetInt($"{cellID}_{cardName}", 0);
            }
        }
        for (int i = 0; i < viruses.Length; i++)
        {
            string enemyName = viruses[i].Name;
            if (FoundVirus[enemyName])
            {
                PlayerPrefs.SetInt($"{virusID}_{enemyName}", 1);
            }
            else
            {
                PlayerPrefs.SetInt($"{virusID}_{enemyName}", 0);
            }
        }
    }

    public static void Load()
    {
        var magictypes = Resources.LoadAll<ZukanMagicType>("Project/Zukan/MagicTypeCards");
        var powerups = Resources.LoadAll<ZukanPowerUp>("Project/Zukan/PowerUpCards");
        var viruses = Resources.LoadAll<ZukanEnemy>("Project/Zukan/Enemy");

        FoundVirus = new Dictionary<string, bool>();
        FoundCore = new Dictionary<string, bool>();
        FoundCell = new Dictionary<string, bool>();

        for(int i = 0;i < magictypes.Length; i++)
        {
            string cardName = magictypes[i].magicType.CardName;
            if (PlayerPrefs.HasKey($"{coreID}_{cardName}"))
            {
                FoundCore[cardName] = PlayerPrefs.GetInt($"{coreID}_{cardName}") == 1;
            }
            else
            {
                PlayerPrefs.SetInt($"{coreID}_{cardName}", 0);
                FoundCore[cardName] = false;
            }
        }
        for(int i = 0;i < powerups.Length; i++)
        {
            string cardName = powerups[i].powerUp.CardName;
            if (PlayerPrefs.HasKey($"{cellID}_{cardName}"))
            {
                FoundCell[cardName] = PlayerPrefs.GetInt($"{cellID}_{cardName}") == 1;
            }
            else
            {
                PlayerPrefs.SetInt($"{cellID}_{cardName}", 0);
                FoundCell[cardName] = false;
            }
        }
        for(int i = 0;i < viruses.Length; i++)
        {
            string enemyName = viruses[i].Name;
            if (PlayerPrefs.HasKey($"{virusID}_{enemyName}"))
            {
                FoundVirus[enemyName] = PlayerPrefs.GetInt($"{virusID}_{enemyName}") == 1;
            }
            else
            {
                PlayerPrefs.SetInt($"{virusID}_{enemyName}", 0);
                FoundVirus[enemyName] = false;
            }
        }
    }

    public static Dictionary<string, bool> FoundVirus;
    public static Dictionary<string, bool> FoundCell;
    public static Dictionary<string, bool> FoundCore;
}
