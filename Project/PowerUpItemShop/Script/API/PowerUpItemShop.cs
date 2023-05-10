using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class PowerUpItemShop
{
    static string[] HasBoughtNameList;
    static PowerUpItemEffectMasterData[] BoughtEffects;
    static MagicBuffer attackBuffer;
    static HPBuffer hpBuffer;
    static MPBuffer mpBuffer;

    static readonly string HasBoughNameListID = "__power__up__item__shop__string__";
    static readonly string BoughtEffectsID = "__power__up__item__shop__effects__";
    static readonly string hpBufferID = "__hp__buffer__";
    static readonly string mpBufferID = "__mp__buffer__";
    static readonly string attackBufferID = "__magic__buffer__attack__";

    static PowerUpItemShop()
    {
        if (PlayerPrefs.HasKey(HasBoughNameListID))
        {
            HasBoughtNameList = JsonUtility.FromJson<JSONArrayCarrier<string>>(PlayerPrefs.GetString(HasBoughNameListID)).Tarray;
            var x = HasBoughtNameList;
        }
        else
        {
            HasBoughtNameList = new string[25];
            for(int i = 0;i < HasBoughtNameList.Length; i++)
            {
                HasBoughtNameList[i] = null;
            }
            JSONArrayCarrier<string> carrier = new JSONArrayCarrier<string>();
            carrier.Tarray = HasBoughtNameList;
            PlayerPrefs.SetString(HasBoughNameListID, JsonUtility.ToJson(carrier));
        }
        if (PlayerPrefs.HasKey(BoughtEffectsID))
        {
            BoughtEffects = JsonUtility.FromJson<JSONArrayCarrier<PowerUpItemEffectMasterData>>(PlayerPrefs.GetString(BoughtEffectsID)).Tarray;
            var x = BoughtEffects;
        }
        else
        {
            BoughtEffects = new PowerUpItemEffectMasterData[25];
            JSONArrayCarrier<PowerUpItemEffectMasterData> carrier = new JSONArrayCarrier<PowerUpItemEffectMasterData>();
            carrier.Tarray = BoughtEffects;
            PlayerPrefs.SetString(BoughtEffectsID, JsonUtility.ToJson(carrier));
        }
        RefleshBuffers();
    }

    public static void RefleshBuffers()
    {
        // Œ»ó‚Ü‚Å‚Ìw“üƒŠƒXƒg‚ð‚à‚Æ‚É‹­‰»î•ñ‚ðÄ\’z‚·‚é
        float attack = 1;
        float HP = 0;
        float MP = 0;
        foreach (var effect in BoughtEffects)
        {
            if(effect == null) { continue; }
            switch (effect.Target)
            {
                case PowerUpItemTarget.Attack:
                    attack += effect.PowerUpValue;
                    break;
                case PowerUpItemTarget.HP:
                    HP += effect.PowerUpValue;
                    break;
                case PowerUpItemTarget.MP:
                    MP += effect.PowerUpValue;
                    break;
            }
        }
        attackBuffer = new MagicBuffer(attack);
        hpBuffer = new HPBuffer(HP);
        mpBuffer = new MPBuffer(MP);
        var x = attackBuffer;
        var y = hpBuffer;
        var z = mpBuffer;
        PlayerPrefs.SetString(attackBufferID, JsonUtility.ToJson(attackBuffer));
        PlayerPrefs.SetString(hpBufferID, JsonUtility.ToJson(hpBuffer));
        PlayerPrefs.SetString(mpBufferID, JsonUtility.ToJson(mpBuffer));
    }

    public static MagicBuffer GetAttackBuffer() => attackBuffer;
    public static HPBuffer GetHPBuffer() => hpBuffer;
    public static MPBuffer GetMPBuffer() => mpBuffer;

    public static void Buy(PowerUpItemMasterData item, MoneyManager money)
    {
        if (!money.CanPay(item.Price)) { return; }
        for(int i = 0;i < BoughtEffects.Length; i++)
        {
            if (BoughtEffects[i] != null) { continue; }
            BoughtEffects[i] = item.Effect;
            break;
        }
        for(int i = 0;i < HasBoughtNameList.Length; i++)
        {
            if(HasBoughtNameList[i] != null && HasBoughtNameList[i] != "") { continue; }
            HasBoughtNameList[i] = item.Name;
            break;
        }
        var x = HasBoughtNameList;
        JSONArrayCarrier<PowerUpItemEffectMasterData> carrier = new JSONArrayCarrier<PowerUpItemEffectMasterData>();
        carrier.Tarray = BoughtEffects;
        string s = JsonUtility.ToJson(carrier);
        PlayerPrefs.SetString(BoughtEffectsID, JsonUtility.ToJson(carrier));
        JSONArrayCarrier<string> carrier1 = new JSONArrayCarrier<string>();
        carrier1.Tarray = HasBoughtNameList;
        s = JsonUtility.ToJson(carrier1);
        PlayerPrefs.SetString(HasBoughNameListID, JsonUtility.ToJson(carrier1));
        money.Pay(item.Price);
        MoneyManager.Save(money);
        RefleshBuffers();
    }

    public static bool HasBought(PowerUpItemMasterData item)
    {
        var x = HasBoughtNameList;
        var ans = HasBoughtNameList.Contains(item.Name);
        return ans;
    }
}

public class JSONArrayCarrier<T>
{
    public T[] Tarray;
}