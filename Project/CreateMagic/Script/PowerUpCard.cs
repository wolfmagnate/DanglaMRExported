using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCard : MagicCard
{

    public List<PowerUpType> PowerUps;
    private PowerUp powerUpScriptableObject;
    private Sprite icon;

    public PowerUp PowerUpScriptableObject { get { return powerUpScriptableObject; } }

    public PowerUpCard(string path):base(path)
    {
        CardName = powerUpScriptableObject.CardName;
        Race = powerUpScriptableObject.Race;
        CardAttribute = powerUpScriptableObject.CardAttribute;
        PowerUps = powerUpScriptableObject.PowerUps;
        icon = powerUpScriptableObject.Icon;
        BuyPrice = powerUpScriptableObject.BuyPrice;
        SellPrice = powerUpScriptableObject.SellPrice;
    }

    public PowerUpCard(PowerUp powerUp)
    {
        powerUpScriptableObject = powerUp;
        CardName = powerUp.CardName;
        Race = powerUp.Race;
        CardAttribute = powerUp.CardAttribute;
        PowerUps = powerUp.PowerUps;
        icon = powerUp.Icon;
        BuyPrice = powerUp.BuyPrice;
        SellPrice = powerUp.SellPrice;
    }

    public override void AddCardAttributePowerUp(List<MagicCard> cards, List<PowerUpType> powerUps)
    {
        int count = powerUpScriptableObject.PowerUpCardAttribute.Count;
        for (int i = 0; i < count; i++)
        {
            int AttributeCount = 0;
            foreach (var card in cards)
            {
                if (card.CardAttribute == powerUpScriptableObject.PowerUpCardAttribute[i])
                {
                    AttributeCount++;
                }
            }
            if (AttributeCount >= powerUpScriptableObject.CardAttributeNumber[i])
            {
                powerUps.Add(powerUpScriptableObject.CardAttributePowerUp[i]);
            }
        }
    }

    public override void AddEnterPowerUp(CardDirection cardDirection, List<PowerUpType> powerUps)
    {
        switch (cardDirection)
        {
            case CardDirection.up:
                powerUps.Add(powerUpScriptableObject.EnterUpPowerUp);
                break;
            case CardDirection.down:
                powerUps.Add(powerUpScriptableObject.EnterDownPowerUp);
                break;
            case CardDirection.left:
                powerUps.Add(powerUpScriptableObject.EnterLeftPowerUp);
                break;
            case CardDirection.right:
                powerUps.Add(powerUpScriptableObject.EnterRightPowerUp);
                break;

            case CardDirection.up_left:
                powerUps.Add(powerUpScriptableObject.EnterUpLeftPowerUp);
                break;
            case CardDirection.up_right:
                powerUps.Add(powerUpScriptableObject.EnterUpRightPowerUp);
                break;
            case CardDirection.down_left:
                powerUps.Add(powerUpScriptableObject.EnterDownLeftPowerUp);
                break;
            case CardDirection.down_right:
                powerUps.Add(powerUpScriptableObject.EnterDownRightPowerUp);
                break;
        }
    }

    public override void AddLeavePowerUp(CardDirection cardDirection, List<PowerUpType> powerUps)
    {
        switch (cardDirection)
        {
            case CardDirection.up:
                powerUps.Add(powerUpScriptableObject.LeaveUpPowerUp);
                break;
            case CardDirection.down:
                powerUps.Add(powerUpScriptableObject.LeaveDownPowerUp);
                break;
            case CardDirection.left:
                powerUps.Add(powerUpScriptableObject.LeaveLeftPowerUp);
                break;
            case CardDirection.right:
                powerUps.Add(powerUpScriptableObject.LeaveRightPowerUp);
                break;

            case CardDirection.up_left:
                powerUps.Add(powerUpScriptableObject.LeaveUpLeftPowerUp);
                break;
            case CardDirection.up_right:
                powerUps.Add(powerUpScriptableObject.LeaveUpRightPowerUp);
                break;
            case CardDirection.down_left:
                powerUps.Add(powerUpScriptableObject.LeaveDownLeftPowerUp);
                break;
            case CardDirection.down_right:
                powerUps.Add(powerUpScriptableObject.LeaveDownRightPowerUp);
                break;
        }
    }

    public override void AddNextMemberPowerUp(MagicCard nextCard, List<PowerUpType> powerUps)
    {
        int count = powerUpScriptableObject.NextCardNamePowerUp.Count;

        for(int i = 0;i < count; i++)
        {
            if(powerUpScriptableObject.PowerUpNextCardName[i] == nextCard.CardName)
            {
                powerUps.Add(powerUpScriptableObject.NextCardNamePowerUp[i]);
                break;
            }
        }
    }

    public override void AddOrderPowerUp(int index, List<PowerUpType> powerUps)
    {
        int count = powerUpScriptableObject.PowerUpOrder.Count;
        for(int i= 0;i < count; i++)
        {
            if(index == powerUpScriptableObject.PowerUpOrder[i])
            {
                powerUps.Add(powerUpScriptableObject.OrderPowerUp[i]);
                break;
            }
        }
    }

    public override void AddPositionPowerUp(Vector2Int position, List<PowerUpType> powerUps)
    {
        int count = powerUpScriptableObject.PositionPowerUp.Count;
        for(int i = 0; i < count; i++)
        {
            if(powerUpScriptableObject.PowerUpPosition[i] == position)
            {
                powerUps.Add(powerUpScriptableObject.PositionPowerUp[i]);
                break;
            }
        }
    }

    public override void AddPreviousMemberPowerUp(MagicCard previousCard, List<PowerUpType> powerUps)
    {
        int count = powerUpScriptableObject.PreviousCardNamePowerUp.Count;

        for (int i = 0; i < count; i++)
        {
            if (powerUpScriptableObject.PowerUpPreviousCardName[i] == previousCard.CardName)
            {
                powerUps.Add(powerUpScriptableObject.PreviousCardNamePowerUp[i]);
                break;
            }
        }
    }

    public override void AddRacePowerUp(List<MagicCard> cards, List<PowerUpType> powerUps)
    {
        int count = powerUpScriptableObject.PowerUpRace.Count;
        for(int i = 0; i < count; i++)
        {
            int RaceCount = 0;
            foreach(var card in cards)
            {
                if(card.Race.Contains(powerUpScriptableObject.PowerUpRace[i]))
                {
                    RaceCount++; 
                }
            }
            if(RaceCount >= powerUpScriptableObject.RaceNumber[i])
            {
                powerUps.Add(powerUpScriptableObject.RacePowerUp[i]);
            }
        }
    }

    public override Sprite GetIcon()
    {
        return icon;
    }

    public override void LoadFromPath()
    {
        Path = @"Project/PowerUpCards/" + Path;
        powerUpScriptableObject = Resources.Load<PowerUp>(Path);
    }
    bool IsDefaultPowerUp(PowerUpType put)
    {
        return (put.PowerUpValue == 0 && put.Target == PowerUpTarget.Attack && put.Pattern == PowerUpPattern.Add);
    }

    public override List<CardDirection> GetAllEnterPowerUpDirections()
    {
        var enterPowerUpDirections = new List<CardDirection>();
        if (!IsDefaultPowerUp(powerUpScriptableObject.EnterUpPowerUp))
        {
            enterPowerUpDirections.Add(CardDirection.up);
        }
        if (!IsDefaultPowerUp(powerUpScriptableObject.EnterUpLeftPowerUp))
        {
            enterPowerUpDirections.Add(CardDirection.up_left);
        }
        if (!IsDefaultPowerUp(powerUpScriptableObject.EnterLeftPowerUp))
        {
            enterPowerUpDirections.Add(CardDirection.left);
        }
        if (!IsDefaultPowerUp(powerUpScriptableObject.EnterDownLeftPowerUp))
        {
            enterPowerUpDirections.Add(CardDirection.down_left);
        }
        if (!IsDefaultPowerUp(powerUpScriptableObject.EnterDownPowerUp))
        {
            enterPowerUpDirections.Add(CardDirection.down);
        }
        if (!IsDefaultPowerUp(powerUpScriptableObject.EnterDownRightPowerUp))
        {
            enterPowerUpDirections.Add(CardDirection.down_right);
        }
        if (!IsDefaultPowerUp(powerUpScriptableObject.EnterRightPowerUp))
        {
            enterPowerUpDirections.Add(CardDirection.right);
        }
        if (!IsDefaultPowerUp(powerUpScriptableObject.EnterUpRightPowerUp))
        {
            enterPowerUpDirections.Add(CardDirection.up_right);
        }
        return enterPowerUpDirections;
    }
    public override List<CardDirection> GetAllLeavePowerUpDirections()
    {
        var leavePowerUpDirections = new List<CardDirection>();
        if (!IsDefaultPowerUp(powerUpScriptableObject.LeaveUpPowerUp))
        {
            leavePowerUpDirections.Add(CardDirection.up);
        }
        if (!IsDefaultPowerUp(powerUpScriptableObject.LeaveUpLeftPowerUp))
        {
            leavePowerUpDirections.Add(CardDirection.up_left);
        }
        if (!IsDefaultPowerUp(powerUpScriptableObject.LeaveLeftPowerUp))
        {
            leavePowerUpDirections.Add(CardDirection.left);
        }
        if (!IsDefaultPowerUp(powerUpScriptableObject.LeaveDownLeftPowerUp))
        {
            leavePowerUpDirections.Add(CardDirection.down_left);
        }
        if (!IsDefaultPowerUp(powerUpScriptableObject.LeaveDownPowerUp))
        {
            leavePowerUpDirections.Add(CardDirection.down);
        }
        if (!IsDefaultPowerUp(powerUpScriptableObject.LeaveDownRightPowerUp))
        {
            leavePowerUpDirections.Add(CardDirection.down_right);
        }
        if (!IsDefaultPowerUp(powerUpScriptableObject.LeaveRightPowerUp))
        {
            leavePowerUpDirections.Add(CardDirection.right);
        }
        if (!IsDefaultPowerUp(powerUpScriptableObject.LeaveUpRightPowerUp))
        {
            leavePowerUpDirections.Add(CardDirection.up_right);
        }
        return leavePowerUpDirections;
    }

    public override bool HasOrderPowerUp(int index)
    {
        return powerUpScriptableObject.PowerUpOrder.Contains(index);
    }


    public override bool HasPositionPowerUp(Vector2Int position)
    {
        return powerUpScriptableObject.PowerUpPosition.Contains(position);
    }
}
