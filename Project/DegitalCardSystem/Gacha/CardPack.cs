using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CardPack")]
public class CardPack : ScriptableObject
{
    [SerializeField]
    public string PackName;
    public List<MagicType> MagicTypeContents;
    public List<float> MagicTypePossibilities;
    public List<PowerUp> PowerUpContents;
    public List<float> PowerUpPossibilities;
    public List<int> Prices;

    public int Price => Prices[FlagManager.StageFlag() - 1];
}
