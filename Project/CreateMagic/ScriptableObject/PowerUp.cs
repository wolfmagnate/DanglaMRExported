using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "ScriptableObject/PowerUp")]
public class PowerUp : ScriptableObject
{
    [Header("�J�[�h�̊�{�f�[�^")]
    public string CardName;
    public List<CardRace> Race;
    public MagicAttribute CardAttribute;
    [Header("�A�C�R��")]
    public Sprite Icon;

    [Header("���A���e�B")]
    public Rarity Rarity;
    public int SellPrice { get => Rarity.GetSellPrice(0); }
    public int BuyPrice { get => Rarity.GetBuyPrice(0); }

    [Header("�f�t�H���g�̌���")]
    public List<PowerUpType> PowerUps;

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

}
