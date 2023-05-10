using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObject/Rarity")]
public class Rarity : ScriptableObject
{
    [SerializeField]
    string RarityName;
    [SerializeField]
    int[] Prices;

    public int GetSellPrice(int level) => Prices[level] / 4;
    public int GetBuyPrice(int level) => Prices[level];
}
