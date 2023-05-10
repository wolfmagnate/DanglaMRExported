using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class MagicCreater
{
    public static MagicTypeCard DefaultMagicTypeCard = new MagicTypeCard("Default");

    public static Magic Create(MagicField magicField, List<Vector2Int> MoveHistory)
    {
        // magicにいろいろ
        var magic = InitMagic(magicField);

        var powerUps = new List<PowerUpType>();
        int orderIndex = 0;

        // カードのリストを作成
        List<MagicCard> cards = new List<MagicCard>();
        foreach(var cardPosition in MoveHistory)
        {
            MagicCard card = magicField.MagicCards[cardPosition.y, cardPosition.x];
            cards.Add(card);
        }

        // カードを取り出して、場所とともにリストに保存
        foreach (var cardPosition in MoveHistory){
            MagicCard card = magicField.MagicCards[cardPosition.y, cardPosition.x];
            // 位置補正
            card.AddPositionPowerUp(cardPosition,powerUps);
            // 順番補正
            card.AddOrderPowerUp(orderIndex,powerUps);
            // 入口補正は最初のカードには行えないため
            if(orderIndex != 0)
            {
                // 移動履歴から入ってきた方向を計算
                var prev = MoveHistory[orderIndex - 1];
                var now = MoveHistory[orderIndex];
                // 注意！prev - nowが正解。EnterUpなどは、「上から入ってきた」なので、直前のカードがどこにあるかが重要
                var diff = prev - now;
                CardDirection direction = diff.CalcDirection();
                card.AddEnterPowerUp(direction,powerUps);
            }
            // 出口補正は最後のカードには行えないため
            if(orderIndex != MoveHistory.Count - 1)
            {
                // 移動履歴から出ていく方向を計算
                var now = MoveHistory[orderIndex];
                var next = MoveHistory[orderIndex + 1];
                var diff = next - now;
                CardDirection direction = diff.CalcDirection();
                card.AddLeavePowerUp(direction,powerUps);
            }
            
            // 種族補正
            card.AddRacePowerUp(cards, powerUps);
            
            // 直前カード補正
            if (orderIndex != 0)
            {
                var prev = MoveHistory[orderIndex - 1];
                var prevCard = magicField.MagicCards[prev.y, prev.x];
                card.AddPreviousMemberPowerUp(prevCard, powerUps);
            }
            // 直後カード補正
            if(orderIndex != MoveHistory.Count - 1)
            {
                var next = MoveHistory[orderIndex + 1];
                var nextCard = magicField.MagicCards[next.y, next.x];
                card.AddNextMemberPowerUp(nextCard, powerUps);
            }

            // カードの属性補正
            card.AddCardAttributePowerUp(cards,powerUps);

            orderIndex++;
        }

        // それぞれのカードに対して
        // 強化カードならばカードのもつPowerUpを追加
        foreach (var cardPosition in MoveHistory)
        {
            if (magicField.MagicCards[cardPosition.y, cardPosition.x] is PowerUpCard powerUpCard)
            {
                foreach(var powerUp in powerUpCard.PowerUps)
                {
                    powerUps.Add(powerUp);
                }
            }
        }

            // PowerUpの補正を一括でかけていく
        foreach (var powerUp in powerUps)
        {
            magic.PowerUp(powerUp);
        }

        // 属性を集計する
        foreach (var cardPosition in MoveHistory)
        {
            magic.CardAttributes.Add(magicField.MagicCards[cardPosition.y, cardPosition.x].CardAttribute);
        }

            return magic;
    }

    public static Magic Create(MagicTypeCard magicTypeCard)
    {
        Magic m = new Magic();
        m.Init(magicTypeCard);
        return m;
    }

    public static CardDirection CalcDirection(this Vector2Int diff)
    {
        if(diff.y > 0 && diff.x == 0)
        {
            return CardDirection.down;
        }
        if (diff.y < 0 && diff.x == 0)
        {
            return CardDirection.up;
        }
        if (diff.y == 0 && diff.x < 0)
        {
            return CardDirection.left;
        }
        if (diff.y == 0 && diff.x > 0)
        {
            return CardDirection.right;
        }

        if(diff.x > 0 && diff.x == diff.y)
        {
            return CardDirection.down_right;
        }
        if (diff.x > 0 && diff.x == -diff.y)
        {
            return CardDirection.up_right;
        }
        if (diff.x < 0 && diff.x == diff.y)
        {
            return CardDirection.up_left;
        }
        if (diff.x < 0 && diff.x == -diff.y)
        {
            return CardDirection.down_left;
        }
        return CardDirection.none;
    }
    private static Magic InitMagic(MagicField magicField)
    {
        Magic magic = new Magic();
        bool breakFlag = false;
        // 術式カードを見つける
        for (int row = 0; row < magicField.Height; row++)
        {
            if (breakFlag) { break; }
            for (int col = 0; col < magicField.Width; col++)
            {
                if (magicField.MagicCards[row, col] is MagicTypeCard magicTypeCard)
                {
                    magic.Init(magicTypeCard);
                    breakFlag = true;
                    break;
                }
            }
        }
        // 術式が存在しなければデフォルト術式を
        if (breakFlag == false)
        {
            magic.Init(DefaultMagicTypeCard);
        }
        return magic;
    }

    private static List<PowerUpType> GetNumberPowerUps(List<MagicCard> cards)
    {
        List<PowerUpType> powerUps = new List<PowerUpType>();
        foreach (var card in cards)
        {
            card.AddRacePowerUp(cards, powerUps);
            card.AddCardAttributePowerUp(cards, powerUps);
        }
        return powerUps;
    }
}
