using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoneyManager
{
    [SerializeField]
    private int money = 0;
    
    public int Money { private set { money = value; } get { return money; } }


    private readonly static string SaveID = "vfhe87km35cjfhjzoqasdnm63b";

    private static string ToJSON(MoneyManager moneyManager) => JsonUtility.ToJson(moneyManager);

    public static void Save(MoneyManager moneyManager) => PlayerPrefs.SetString(SaveID, ToJSON(moneyManager));

    public static MoneyManager Load() {
        var saved = JsonUtility.FromJson<MoneyManager>(PlayerPrefs.GetString(SaveID));
        if(saved != null) { return saved; }
        var created = new MoneyManager();
        created.money = 0;
        Save(created);
        return created;
    }

    public static bool HasSaveData() => PlayerPrefs.HasKey(SaveID);

    public bool CanPay(int value) => value <= money;

    public void Pay(int value) => money -= value;

    public void Gain(int value) => money += value;
}
