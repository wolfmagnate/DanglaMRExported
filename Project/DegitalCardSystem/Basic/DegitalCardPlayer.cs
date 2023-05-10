using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegitalCardPlayer: IDegitalCardPlayer
{
    private CardStore store;
    private MoneyManager money;

    public CardStore GetCardStore()
    {
        return store;
    }

    public MoneyManager GetMoneyManager()
    {
        return money;
    }

    public void LoadOrNew()
    {
        store = CardStore.Load();
        money = MoneyManager.HasSaveData() ? MoneyManager.Load() : new MoneyManager();
    }

    private static IDegitalCardPlayer player;

    static DegitalCardPlayer()
    {
        player = new DegitalCardPlayer();
        player.LoadOrNew();
    }
    public static IDegitalCardPlayer GetDegitalCardPlayer()
    {
        return player;
    }
}


public interface IDegitalCardPlayer
{
    CardStore GetCardStore();
    MoneyManager GetMoneyManager();
    void LoadOrNew();
}