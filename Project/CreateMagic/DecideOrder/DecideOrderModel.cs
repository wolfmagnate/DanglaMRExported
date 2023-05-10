using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideOrderModel
{
    public MagicCard[,] MagicField { get; private set; }
    
    public DecideOrderModel(MagicCard[,] field)
    {
        MagicField = field;
    }

    public bool HasPositionPowerUp(Vector2Int position)
    {
        if(MagicField[position.y, position.x] == null)
        {
            return false;
        }
        var card = MagicField[position.y, position.x];
        return card.HasPositionPowerUp(position);
    }

    public List<CardDirection> GetEnterPowerUpDirections(Vector2Int position)
    {
        if(MagicField[position.y, position.x] == null)
        {
            return new List<CardDirection>();
        }
        var card = MagicField[position.y, position.x];
        return card.GetAllEnterPowerUpDirections();
    }
    public List<CardDirection> GetLeavePowerUpDirections(Vector2Int position)
    {
        if (MagicField[position.y, position.x] == null)
        {
            return new List<CardDirection>();
        }
        var card = MagicField[position.y, position.x];
        return card.GetAllLeavePowerUpDirections();
    }

    Vector2Int gridMagicCard;
    bool Selecting = false;
    public void StartSelect(Vector2Int position)
    {
        gridMagicCard = new Vector2Int(position.x, position.y);
        Selecting = true;
    }

    public void GridMove(Vector2Int position)
    {
        if (Selecting)
        {
            if(position == gridMagicCard) { return; }
            (MagicField[position.y, position.x], MagicField[gridMagicCard.y, gridMagicCard.x]) = (MagicField[gridMagicCard.y, gridMagicCard.x], MagicField[position.y, position.x]);
            gridMagicCard = position;
        }
    }

    public void EndSelect()
    {
        Selecting = false;
        gridMagicCard = new Vector2Int(-1,-1);
    }
}
