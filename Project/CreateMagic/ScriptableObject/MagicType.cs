using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObject/MagicType")]
public class MagicType : ScriptableObject
{
    [Header("カードの基本データ")]
    public string CardName;
    public List<CardRace> Race;
    [Header("アイコン画像")]
    public Sprite Icon;


    [Header("魔術の基本パラメーター")]


    // 数値系のパラメータ
    public float Attack;
    public float Speed;
    public float ChargeTime;
    public float Distance;
    public float Range;
    public float MP;
    public int CanHitTimes;
    public int Rush;
    public float RushInterval;
    // 選択系のパラメータ
    public MagicAttribute Attribute;
    public MoveType MoveType;
    public List<BadStatus> BadStatuses;
    public List<float> BadStatusPossibility;
    public MagicAttribute CardAttribute;


    [Header("レアリティ")]
    public Rarity Rarity;
    public int SellPrice => Rarity.GetSellPrice(FlagManager.StageFlag() - 1);
    public int BuyPrice => Rarity.GetBuyPrice(FlagManager.StageFlag() - 1);


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
    public void Awakee()
    {
        EnterDownLeftPowerUp = ScriptableObjectReferences.DefaultPowerUp;
        EnterDownRightPowerUp = ScriptableObjectReferences.DefaultPowerUp;
        EnterUpLeftPowerUp = ScriptableObjectReferences.DefaultPowerUp;
        EnterUpRightPowerUp = ScriptableObjectReferences.DefaultPowerUp;
        EnterDownPowerUp = ScriptableObjectReferences.DefaultPowerUp;
        EnterLeftPowerUp = ScriptableObjectReferences.DefaultPowerUp;
        EnterRightPowerUp = ScriptableObjectReferences.DefaultPowerUp;
        EnterUpPowerUp = ScriptableObjectReferences.DefaultPowerUp;
        LeaveDownLeftPowerUp = ScriptableObjectReferences.DefaultPowerUp;
        LeaveDownRightPowerUp = ScriptableObjectReferences.DefaultPowerUp;
        LeaveUpLeftPowerUp = ScriptableObjectReferences.DefaultPowerUp;
        LeaveUpRightPowerUp = ScriptableObjectReferences.DefaultPowerUp;
        LeaveDownPowerUp = ScriptableObjectReferences.DefaultPowerUp;
        LeaveLeftPowerUp = ScriptableObjectReferences.DefaultPowerUp;
        LeaveRightPowerUp = ScriptableObjectReferences.DefaultPowerUp;
        LeaveUpPowerUp = ScriptableObjectReferences.DefaultPowerUp;
    }
}
