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
        // magic�ɂ��낢��
        var magic = InitMagic(magicField);

        var powerUps = new List<PowerUpType>();
        int orderIndex = 0;

        // �J�[�h�̃��X�g���쐬
        List<MagicCard> cards = new List<MagicCard>();
        foreach(var cardPosition in MoveHistory)
        {
            MagicCard card = magicField.MagicCards[cardPosition.y, cardPosition.x];
            cards.Add(card);
        }

        // �J�[�h�����o���āA�ꏊ�ƂƂ��Ƀ��X�g�ɕۑ�
        foreach (var cardPosition in MoveHistory){
            MagicCard card = magicField.MagicCards[cardPosition.y, cardPosition.x];
            // �ʒu�␳
            card.AddPositionPowerUp(cardPosition,powerUps);
            // ���ԕ␳
            card.AddOrderPowerUp(orderIndex,powerUps);
            // �����␳�͍ŏ��̃J�[�h�ɂ͍s���Ȃ�����
            if(orderIndex != 0)
            {
                // �ړ�������������Ă����������v�Z
                var prev = MoveHistory[orderIndex - 1];
                var now = MoveHistory[orderIndex];
                // ���ӁIprev - now�������BEnterUp�Ȃǂ́A�u�ォ������Ă����v�Ȃ̂ŁA���O�̃J�[�h���ǂ��ɂ��邩���d�v
                var diff = prev - now;
                CardDirection direction = diff.CalcDirection();
                card.AddEnterPowerUp(direction,powerUps);
            }
            // �o���␳�͍Ō�̃J�[�h�ɂ͍s���Ȃ�����
            if(orderIndex != MoveHistory.Count - 1)
            {
                // �ړ���������o�Ă����������v�Z
                var now = MoveHistory[orderIndex];
                var next = MoveHistory[orderIndex + 1];
                var diff = next - now;
                CardDirection direction = diff.CalcDirection();
                card.AddLeavePowerUp(direction,powerUps);
            }
            
            // �푰�␳
            card.AddRacePowerUp(cards, powerUps);
            
            // ���O�J�[�h�␳
            if (orderIndex != 0)
            {
                var prev = MoveHistory[orderIndex - 1];
                var prevCard = magicField.MagicCards[prev.y, prev.x];
                card.AddPreviousMemberPowerUp(prevCard, powerUps);
            }
            // ����J�[�h�␳
            if(orderIndex != MoveHistory.Count - 1)
            {
                var next = MoveHistory[orderIndex + 1];
                var nextCard = magicField.MagicCards[next.y, next.x];
                card.AddNextMemberPowerUp(nextCard, powerUps);
            }

            // �J�[�h�̑����␳
            card.AddCardAttributePowerUp(cards,powerUps);

            orderIndex++;
        }

        // ���ꂼ��̃J�[�h�ɑ΂���
        // �����J�[�h�Ȃ�΃J�[�h�̂���PowerUp��ǉ�
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

            // PowerUp�̕␳���ꊇ�ł����Ă���
        foreach (var powerUp in powerUps)
        {
            magic.PowerUp(powerUp);
        }

        // �������W�v����
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
        // �p���J�[�h��������
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
        // �p�������݂��Ȃ���΃f�t�H���g�p����
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
