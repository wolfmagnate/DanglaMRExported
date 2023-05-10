using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/PowerUpItemEffect")]
public class PowerUpItemEffectMasterData : ScriptableObject
{
    public PowerUpItemTarget Target;
    [Header("HP,MP�͎����l�ő����ʂ��L�q����AAttack��+10%�̏ꍇ��0.1�ƋL�q����")]
    public float PowerUpValue;
}
