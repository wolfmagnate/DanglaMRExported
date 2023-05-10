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
    // 8�����ȊO�̏ꏊ���炫���ꍇ�̊��蓖��
    none
}

/// <summary>
/// �e��␳�⋭���J�[�h�ɂ�鋭���̑Ώێw��Ɏg��
/// </summary>
[System.Serializable]
public enum PowerUpTarget
{
    // ���l�n
    Attack,Speed,ChargeTime,Distance,Range,MP,Rush,RushInterval,CanHitTimes,

    // �t�^�n
    Attribute, BadStatus
}

[System.Serializable]
public enum PowerUpItemTarget
{
    Attack, HP, MP
}

/// <summary>
/// �����̌v�Z���@���w�肷��
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