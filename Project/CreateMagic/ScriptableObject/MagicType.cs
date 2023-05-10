using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObject/MagicType")]
public class MagicType : ScriptableObject
{
    [Header("�J�[�h�̊�{�f�[�^")]
    public string CardName;
    public List<CardRace> Race;
    [Header("�A�C�R���摜")]
    public Sprite Icon;


    [Header("���p�̊�{�p�����[�^�[")]


    // ���l�n�̃p�����[�^
    public float Attack;
    public float Speed;
    public float ChargeTime;
    public float Distance;
    public float Range;
    public float MP;
    public int CanHitTimes;
    public int Rush;
    public float RushInterval;
    // �I���n�̃p�����[�^
    public MagicAttribute Attribute;
    public MoveType MoveType;
    public List<BadStatus> BadStatuses;
    public List<float> BadStatusPossibility;
    public MagicAttribute CardAttribute;


    [Header("���A���e�B")]
    public Rarity Rarity;
    public int SellPrice => Rarity.GetSellPrice(FlagManager.StageFlag() - 1);
    public int BuyPrice => Rarity.GetBuyPrice(FlagManager.StageFlag() - 1);


    [Header("�����Ă��������ɂ��␳")]
    // �F�X�ȋ����ɂ��ċ������@���L��
    public PowerUpType EnterLeftPowerUp;
    public PowerUpType EnterRightPowerUp;
    public PowerUpType EnterUpPowerUp;
    public PowerUpType EnterDownPowerUp;
    public PowerUpType EnterUpLeftPowerUp;
    public PowerUpType EnterUpRightPowerUp;
    public PowerUpType EnterDownLeftPowerUp;
    public PowerUpType EnterDownRightPowerUp;

    [Header("�o�Ă��������ɂ��␳")]
    public PowerUpType LeaveLeftPowerUp;
    public PowerUpType LeaveRightPowerUp;
    public PowerUpType LeaveUpPowerUp;
    public PowerUpType LeaveDownPowerUp;
    public PowerUpType LeaveUpLeftPowerUp;
    public PowerUpType LeaveUpRightPowerUp;
    public PowerUpType LeaveDownLeftPowerUp;
    public PowerUpType LeaveDownRightPowerUp;

    [Header("�푰�ɂ��␳")]
    public List<CardRace> PowerUpRace;
    public List<int> RaceNumber;
    public List<PowerUpType> RacePowerUp;

    [Header("���O�̃J�[�h�ɂ��␳")]
    public List<string> PowerUpPreviousCardName;
    public List<PowerUpType> PreviousCardNamePowerUp;

    [Header("����̃J�[�h�ɂ��␳")]
    public List<string> PowerUpNextCardName;
    public List<PowerUpType> NextCardNamePowerUp;

    [Header("�����ɂ��␳")]
    public List<int> PowerUpOrder;
    public List<PowerUpType> OrderPowerUp;

    [Header("�ʒu�ɂ��␳")]
    public List<Vector2Int> PowerUpPosition;
    public List<PowerUpType> PositionPowerUp;

    [Header("�J�[�h�����ɂ��␳")]
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
