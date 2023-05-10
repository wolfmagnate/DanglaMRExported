using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 各種補正を加えて出来上がった魔法の完成品のデータを保存しておくクラス
/// </summary>
[System.Serializable]
public class Magic
{
    [SerializeField]
    public string MagicName;

    // 数値系のパラメータ
    [SerializeField]
    float attack;
    public float Attack
    {
        get
        {
            return attack;
        }
        private set
        {
            attack = value;
        }
    }
    public float BattleAttack
    {
        get => attack * bufferAttack;
    }
    [SerializeField]
    public float Speed;
    [SerializeField]
    public float ChargeTime;
    [SerializeField]
    public float Distance;
    [SerializeField]
    public float Range;
    [SerializeField]
    public float MP;
    [SerializeField]
    float canHitTimes;
    public float CanHitTimes
    {
        get
        {
            return canHitTimes;
        }
        private set
        {
            canHitTimes = value;
        }
    }
    public int BattleCanHitTimes
    {
        get => Mathf.RoundToInt(canHitTimes);
    }
    [SerializeField]
    float rush;
    public float Rush
    {
        get => rush;
        set => rush = value;
    }
    public int BattleRush
    {
        get => Mathf.RoundToInt(rush);
    }
    [SerializeField]
    public float RushInterval;
    // 選択系のパラメータ
    [SerializeField]
    public MagicAttribute Attribute;
    [SerializeField]
    public MoveType MoveType;
    [SerializeField]
    public List<BadStatus> BadStatuses;
    [SerializeField]
    public List<float> BadStatusPossibility;
    [SerializeField]
    public List<MagicAttribute> CardAttributes;

    private MagicTypeCard MasterData;

    public void Init(MagicTypeCard magicTypeCard)
    {
        Attack = magicTypeCard.Attack;
        Attribute = magicTypeCard.Attribute;
        BadStatusPossibility = magicTypeCard.BadStatusPossibility;
        CanHitTimes = magicTypeCard.CanHitTimes;
        ChargeTime = magicTypeCard.ChargeTime;
        BadStatuses = magicTypeCard.BadStatuses;
        MagicName = magicTypeCard.CardName;
        Distance = magicTypeCard.Distance;
        MagicName = magicTypeCard.CardName;
        MoveType = magicTypeCard.MoveType;
        MP = magicTypeCard.MP;
        Range = magicTypeCard.Range;
        Rush = magicTypeCard.Rush;
        RushInterval = magicTypeCard.RushInterval;
        Speed = magicTypeCard.Speed;
        MasterData = magicTypeCard;
        CardAttributes = new List<MagicAttribute>();
    }

    float bufferAttack;
    public void AddBuffer(MagicBuffer buffer)
    {
        bufferAttack = buffer.Attack;
    }

    public void PowerUp(PowerUpType powerUp)
    {
        // なんで人間様がわざわざswitchしているんだろう。こういうのって多態性を用いて.netにやらせるもんじゃないの？
        switch (powerUp.Pattern)
        {
            case PowerUpPattern.Add:
                switch (powerUp.Target)
                {
                    case PowerUpTarget.Attack:
                        Attack += powerUp.PowerUpValue;
                        break;
                    case PowerUpTarget.CanHitTimes:
                        CanHitTimes += powerUp.PowerUpValue;
                        break;
                    case PowerUpTarget.ChargeTime:
                        ChargeTime += powerUp.PowerUpValue;
                        break;
                    case PowerUpTarget.Distance:
                        Distance += powerUp.PowerUpValue;
                        break;
                    case PowerUpTarget.MP:
                        MP += powerUp.PowerUpValue;
                        break;
                    case PowerUpTarget.Range:
                        Range += powerUp.PowerUpValue;
                        break;
                    case PowerUpTarget.Rush:
                        Rush += powerUp.PowerUpValue;
                        break;
                    case PowerUpTarget.RushInterval:
                        RushInterval += powerUp.PowerUpValue;
                        break;
                    case PowerUpTarget.Speed:
                        Speed += powerUp.PowerUpValue;
                        break;
                }
                break;
            case PowerUpPattern.Product:
                switch (powerUp.Target)
                {
                    case PowerUpTarget.Attack:
                        Attack *= powerUp.PowerUpValue;
                        break;
                    case PowerUpTarget.CanHitTimes:
                        // 最悪！こんなの補正の意味ないじゃん…
                        CanHitTimes *= powerUp.PowerUpValue;
                        break;
                    case PowerUpTarget.ChargeTime:
                        ChargeTime *= powerUp.PowerUpValue;
                        break;
                    case PowerUpTarget.Distance:
                        Distance *= powerUp.PowerUpValue;
                        break;
                    case PowerUpTarget.MP:
                        MP *= powerUp.PowerUpValue;
                        break;
                    case PowerUpTarget.Range:
                        Range *= powerUp.PowerUpValue;
                        break;
                    case PowerUpTarget.Rush:
                        Rush *= powerUp.PowerUpValue;
                        break;
                    case PowerUpTarget.RushInterval:
                        RushInterval *= powerUp.PowerUpValue;
                        break;
                    case PowerUpTarget.Speed:
                        Speed *= powerUp.PowerUpValue;
                        break;
                }
                break;
            case PowerUpPattern.AddAttribute:
                switch (powerUp.Target)
                {
                    case PowerUpTarget.Attribute:
                        Attribute = powerUp.Attribute;
                        break;
                    case PowerUpTarget.BadStatus:
                        for (int i = 0; i < powerUp.BadStatuses.Count; i++)
                        {
                            if (BadStatuses.Contains(powerUp.BadStatuses[i]))
                            {
                                BadStatusPossibility[BadStatuses.IndexOf(powerUp.BadStatuses[i])] += powerUp.BadStatusPossibilities[i];
                            }
                            else
                            {
                                BadStatuses.Add(powerUp.BadStatuses[i]);
                                BadStatusPossibility.Add(powerUp.BadStatusPossibilities[i]);
                            }
                        }
                        break;
                }
                break;
        }
    }

    public (float Attack, int CanHitTimes, float ChargeTime, float Distance, float MP, float Range, int Rush,float RushInterval,float Speed) GetPowerUpAmount()
    {
        if(MasterData == null && (!string.IsNullOrEmpty(MagicName)))
        {
            var magicType = Resources.LoadAll<MagicType>("Project/MagicTypeCards");
            foreach(var type in magicType)
            {
                if(type.CardName == MagicName)
                {
                    MasterData = new MagicTypeCard(type);
                }
            }
        }
        var naive = MagicCreater.Create(MasterData);
        return (
            Attack - naive.Attack,
            BattleCanHitTimes - naive.BattleCanHitTimes,
            ChargeTime - naive.ChargeTime,
            Distance - naive.Distance,
            MP - naive.MP,
            Range - naive.Range,
            BattleRush - naive.BattleRush,
            RushInterval - naive.RushInterval,
            Speed - naive.Speed
        );
    }

    public Sprite Icon => MasterData.GetIcon();
}
