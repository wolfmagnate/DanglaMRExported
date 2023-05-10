using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "ScriptableObject/PowerUp")]
public class PowerUp : ScriptableObject
{
    [Header("カードの基本データ")]
    public string CardName;
    public List<CardRace> Race;
    public MagicAttribute CardAttribute;
    [Header("アイコン")]
    public Sprite Icon;

    [Header("レアリティ")]
    public Rarity Rarity;
    public int SellPrice { get => Rarity.GetSellPrice(0); }
    public int BuyPrice { get => Rarity.GetBuyPrice(0); }

    [Header("デフォルトの効果")]
    public List<PowerUpType> PowerUps;

    [Header("入ってきた方向による補正")]
    // 色々な強化について強化方法を記す
    public PowerUpType EnterLeftPowerUp;
    public PowerUpType EnterRightPowerUp;
    public PowerUpType EnterUpPowerUp;
    public PowerUpType EnterDownPowerUp;
    public PowerUpType EnterUpLeftPowerUp;
    public PowerUpType EnterUpRightPowerUp;
    public PowerUpType EnterDownLeftPowerUp;
    public PowerUpType EnterDownRightPowerUp;

    [Header("出ていく方向による補正")]
    public PowerUpType LeaveLeftPowerUp;
    public PowerUpType LeaveRightPowerUp;
    public PowerUpType LeaveUpPowerUp;
    public PowerUpType LeaveDownPowerUp;
    public PowerUpType LeaveUpLeftPowerUp;
    public PowerUpType LeaveUpRightPowerUp;
    public PowerUpType LeaveDownLeftPowerUp;
    public PowerUpType LeaveDownRightPowerUp;

    [Header("種族による補正")]
    public List<CardRace> PowerUpRace;
    public List<int> RaceNumber;
    public List<PowerUpType> RacePowerUp;

    [Header("直前のカードによる補正")]
    public List<string> PowerUpPreviousCardName;
    public List<PowerUpType> PreviousCardNamePowerUp;

    [Header("直後のカードによる補正")]
    public List<string> PowerUpNextCardName;
    public List<PowerUpType> NextCardNamePowerUp;

    [Header("順序による補正")]
    public List<int> PowerUpOrder;
    public List<PowerUpType> OrderPowerUp;

    [Header("位置による補正")]
    public List<Vector2Int> PowerUpPosition;
    public List<PowerUpType> PositionPowerUp;

    [Header("カード属性による補正")]
    public List<MagicAttribute> PowerUpCardAttribute;
    public List<int> CardAttributeNumber;
    public List<PowerUpType> CardAttributePowerUp;

}
