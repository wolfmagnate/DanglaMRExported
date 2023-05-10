using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 魔法の基本術式を決めるカード
/// 魔法のベースとなり、基本性能は術式の時点ですべて決まる
/// </summary>
public class MagicTypeCard : MagicCard
{
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
    // アイコン画像
    private Sprite icon;
    public override Sprite GetIcon()
    {
        return icon;
    }

    public MagicType MagicTypeScriptableObject { get { return magicTypeScriptableObject; } }
    private MagicType magicTypeScriptableObject;

    public MagicTypeCard(string path) : base(path)
    {
        
        Attack = magicTypeScriptableObject.Attack;
        Speed = magicTypeScriptableObject.Speed;
        ChargeTime = magicTypeScriptableObject.ChargeTime;
        Distance = magicTypeScriptableObject.Distance;
        Range = magicTypeScriptableObject.Range;
        MP = magicTypeScriptableObject.MP;
        CanHitTimes = magicTypeScriptableObject.CanHitTimes;
        Rush = magicTypeScriptableObject.Rush;
        RushInterval = magicTypeScriptableObject.RushInterval;
        Attribute = magicTypeScriptableObject.Attribute;
        MoveType = magicTypeScriptableObject.MoveType;
        BadStatuses = magicTypeScriptableObject.BadStatuses;
        BadStatusPossibility = magicTypeScriptableObject.BadStatusPossibility;
        CardName = magicTypeScriptableObject.CardName;
        Race = magicTypeScriptableObject.Race;
        CardAttribute = magicTypeScriptableObject.CardAttribute;
        icon = magicTypeScriptableObject.Icon;
        BuyPrice = magicTypeScriptableObject.BuyPrice;
        SellPrice = magicTypeScriptableObject.SellPrice;
    }

    public MagicTypeCard(MagicType magicType)
    {
        magicTypeScriptableObject = magicType;
        Attack = magicType.Attack;
        Speed = magicType.Speed;
        ChargeTime = magicType.ChargeTime;
        Distance = magicType.Distance;
        Range = magicType.Range;
        MP = magicType.MP;
        CanHitTimes = magicType.CanHitTimes;
        Rush = magicType.Rush;
        RushInterval = magicType.RushInterval;
        Attribute = magicType.Attribute;
        MoveType = magicType.MoveType;
        BadStatuses = magicType.BadStatuses;
        BadStatusPossibility = magicType.BadStatusPossibility;
        CardName = magicType.CardName;
        Race = magicType.Race;
        CardAttribute = magicType.CardAttribute;
        icon = magicType.Icon;
        BuyPrice = magicType.BuyPrice;
        SellPrice = magicType.SellPrice;
    }

    public override void AddCardAttributePowerUp(List<MagicCard> cards, List<PowerUpType> powerUps)
    {
        int count = magicTypeScriptableObject.PowerUpCardAttribute.Count;
        for (int i = 0; i < count; i++)
        {
            int AttributeCount = 0;
            foreach (var card in cards)
            {
                if (card.CardAttribute == magicTypeScriptableObject.PowerUpCardAttribute[i])
                {
                    AttributeCount++;
                }
            }
            if (AttributeCount >= magicTypeScriptableObject.CardAttributeNumber[i])
            {
                powerUps.Add(magicTypeScriptableObject.CardAttributePowerUp[i]);
            }
        }
    }

    public override void AddEnterPowerUp(CardDirection cardDirection, List<PowerUpType> powerUps)
    {

        switch (cardDirection)
        {
            case CardDirection.up:
                powerUps.Add(magicTypeScriptableObject.EnterUpPowerUp);
                break;
            case CardDirection.down:
                powerUps.Add(magicTypeScriptableObject.EnterDownPowerUp);
                break;
            case CardDirection.left:
                powerUps.Add(magicTypeScriptableObject.EnterLeftPowerUp);
                break;
            case CardDirection.right:
                powerUps.Add(magicTypeScriptableObject.EnterRightPowerUp);
                break;

            case CardDirection.up_left:
                powerUps.Add(magicTypeScriptableObject.EnterUpLeftPowerUp);
                break;
            case CardDirection.up_right:
                powerUps.Add(magicTypeScriptableObject.EnterUpRightPowerUp);
                break;
            case CardDirection.down_left:
                powerUps.Add(magicTypeScriptableObject.EnterDownLeftPowerUp);
                break;
            case CardDirection.down_right:
                powerUps.Add(magicTypeScriptableObject.EnterDownRightPowerUp);
                break;
        }
    }

    public override void AddLeavePowerUp(CardDirection cardDirection, List<PowerUpType> powerUps)
    {
        switch (cardDirection)
        {
            case CardDirection.up:
                powerUps.Add(magicTypeScriptableObject.LeaveUpPowerUp);
                break;
            case CardDirection.down:
                powerUps.Add(magicTypeScriptableObject.LeaveDownPowerUp);
                break;
            case CardDirection.left:
                powerUps.Add(magicTypeScriptableObject.LeaveLeftPowerUp);
                break;
            case CardDirection.right:
                powerUps.Add(magicTypeScriptableObject.LeaveRightPowerUp);
                break;

            case CardDirection.up_left:
                powerUps.Add(magicTypeScriptableObject.LeaveUpLeftPowerUp);
                break;
            case CardDirection.up_right:
                powerUps.Add(magicTypeScriptableObject.LeaveUpRightPowerUp);
                break;
            case CardDirection.down_left:
                powerUps.Add(magicTypeScriptableObject.LeaveDownLeftPowerUp);
                break;
            case CardDirection.down_right:
                powerUps.Add(magicTypeScriptableObject.LeaveDownRightPowerUp);
                break;
        }
    }

    public override void AddNextMemberPowerUp(MagicCard nextCard, List<PowerUpType> powerUps)
    {
        int count = magicTypeScriptableObject.NextCardNamePowerUp.Count;

        for (int i = 0; i < count; i++)
        {
            if (magicTypeScriptableObject.PowerUpNextCardName[i] == nextCard.CardName)
            {
                powerUps.Add(magicTypeScriptableObject.NextCardNamePowerUp[i]);
                break;
            }
        }
    }

    public override void AddOrderPowerUp(int index, List<PowerUpType> powerUps)
    {

        int count = magicTypeScriptableObject.PowerUpOrder.Count;
        for (int i = 0; i < count; i++)
        {
            if (index == magicTypeScriptableObject.PowerUpOrder[i])
            {
                powerUps.Add(magicTypeScriptableObject.OrderPowerUp[i]);
                break;
            }
        }
    }

    public override void AddPositionPowerUp(Vector2Int position, List<PowerUpType> powerUps)
    {
        int count = magicTypeScriptableObject.PositionPowerUp.Count;
        for (int i = 0; i < count; i++)
        {
            if (magicTypeScriptableObject.PowerUpPosition[i] == position)
            {
                powerUps.Add(magicTypeScriptableObject.PositionPowerUp[i]);
                break;
            }
        }
    }

    public override void AddPreviousMemberPowerUp(MagicCard previousCard, List<PowerUpType> powerUps)
    {
        int count = magicTypeScriptableObject.PreviousCardNamePowerUp.Count;

        for (int i = 0; i < count; i++)
        {
            if (magicTypeScriptableObject.PowerUpPreviousCardName[i] == previousCard.CardName)
            {
                powerUps.Add(magicTypeScriptableObject.PreviousCardNamePowerUp[i]);
                break;
            }
        }
    }

    public override void AddRacePowerUp(List<MagicCard> cards, List<PowerUpType> powerUps)
    {
        int count = magicTypeScriptableObject.PowerUpRace.Count;
        for (int i = 0; i < count; i++)
        {
            int RaceCount = 0;
            foreach (var card in cards)
            {
                if (card.Race.Contains(magicTypeScriptableObject.PowerUpRace[i]))
                {
                    RaceCount++;
                }
            }
            if (RaceCount >= magicTypeScriptableObject.RaceNumber[i])
            {
                powerUps.Add(magicTypeScriptableObject.RacePowerUp[i]);
            }
        }
    }

    public override void LoadFromPath()
    {
        Path = @"Project/MagicTypeCards/" + Path;
        magicTypeScriptableObject = Resources.Load<MagicType>(Path);
    }

    bool IsDefaultPowerUp(PowerUpType put)
    {
        return (put.PowerUpValue == 0 && put.Target == PowerUpTarget.Attack && put.Pattern == PowerUpPattern.Add);
    }

    public override List<CardDirection> GetAllEnterPowerUpDirections()
    {
        var enterPowerUpDirections = new List<CardDirection>();
        if (!IsDefaultPowerUp(magicTypeScriptableObject.EnterUpPowerUp))
        {
            enterPowerUpDirections.Add(CardDirection.up);
        }
        if (!IsDefaultPowerUp(magicTypeScriptableObject.EnterUpLeftPowerUp))
        {
            enterPowerUpDirections.Add(CardDirection.up_left);
        }
        if (!IsDefaultPowerUp(magicTypeScriptableObject.EnterLeftPowerUp))
        {
            enterPowerUpDirections.Add(CardDirection.left);
        }
        if (!IsDefaultPowerUp(magicTypeScriptableObject.EnterDownLeftPowerUp))
        {
            enterPowerUpDirections.Add(CardDirection.down_left);
        }
        if (!IsDefaultPowerUp(magicTypeScriptableObject.EnterDownPowerUp))
        {
            enterPowerUpDirections.Add(CardDirection.down);
        }
        if (!IsDefaultPowerUp(magicTypeScriptableObject.EnterDownRightPowerUp))
        {
            enterPowerUpDirections.Add(CardDirection.down_right);
        }
        if (!IsDefaultPowerUp(magicTypeScriptableObject.EnterRightPowerUp))
        {
            enterPowerUpDirections.Add(CardDirection.right);
        }
        if (!IsDefaultPowerUp(magicTypeScriptableObject.EnterUpRightPowerUp))
        {
            enterPowerUpDirections.Add(CardDirection.up_right);
        }
        return enterPowerUpDirections;
    }
    public override List<CardDirection> GetAllLeavePowerUpDirections()
    {
        var leavePowerUpDirections = new List<CardDirection>();
        if (!IsDefaultPowerUp(magicTypeScriptableObject.LeaveUpPowerUp))
        {
            leavePowerUpDirections.Add(CardDirection.up);
        }
        if (!IsDefaultPowerUp(magicTypeScriptableObject.LeaveUpLeftPowerUp))
        {
            leavePowerUpDirections.Add(CardDirection.up_left);
        }
        if (!IsDefaultPowerUp(magicTypeScriptableObject.LeaveLeftPowerUp))
        {
            leavePowerUpDirections.Add(CardDirection.left);
        }
        if (!IsDefaultPowerUp(magicTypeScriptableObject.LeaveDownLeftPowerUp))
        {
            leavePowerUpDirections.Add(CardDirection.down_left);
        }
        if (!IsDefaultPowerUp(magicTypeScriptableObject.LeaveDownPowerUp))
        {
            leavePowerUpDirections.Add(CardDirection.down);
        }
        if (!IsDefaultPowerUp(magicTypeScriptableObject.LeaveDownRightPowerUp))
        {
            leavePowerUpDirections.Add(CardDirection.down_right);
        }
        if (!IsDefaultPowerUp(magicTypeScriptableObject.LeaveRightPowerUp))
        {
            leavePowerUpDirections.Add(CardDirection.right);
        }
        if (!IsDefaultPowerUp(magicTypeScriptableObject.LeaveUpRightPowerUp))
        {
            leavePowerUpDirections.Add(CardDirection.up_right);
        }
        return leavePowerUpDirections;
    }

    public override bool HasOrderPowerUp(int index)
    {
        return magicTypeScriptableObject.PowerUpOrder.Contains(index);
    }

    public override bool HasPositionPowerUp(Vector2Int position)
    {
        return magicTypeScriptableObject.PowerUpPosition.Contains(position);
    }
}