using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enums
{
}


[System.Serializable]
public enum CardRace
{
    experimental, direction, connection, freedom, position, number, order, cheat
}

[System.Serializable]
public enum CardDirection
{
    up, down, left, right, up_right, up_left, down_right, down_left,
    // 8方向以外の場所からきた場合の割り当て
    none
}

/// <summary>
/// 各種補正や強化カードによる強化の対象指定に使う
/// </summary>
[System.Serializable]
public enum PowerUpTarget
{
    // 数値系
    Attack,Speed,ChargeTime,Distance,Range,MP,Rush,RushInterval,CanHitTimes,

    // 付与系
    Attribute, BadStatus
}

[System.Serializable]
public enum PowerUpItemTarget
{
    Attack, HP, MP
}

/// <summary>
/// 強化の計算方法を指定する
/// </summary>
[System.Serializable]
public enum PowerUpPattern
{
    Add, Product, AddAttribute
}

[System.Serializable]
public enum MagicAttribute
{
    Wind,Lightning,Tree,Water,Fire,Ice,Mountain,Metal,Light,Darkness,Nothing
}

[System.Serializable]
public enum BadStatus
{
    poisoned, burnt, frozen, paralyzed, broken
}


[System.Serializable]
public enum MoveType
{
    straight,spread,wave,sphere,ray,gatling
}