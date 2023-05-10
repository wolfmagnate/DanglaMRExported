using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/PowerUpItemEffect")]
public class PowerUpItemEffectMasterData : ScriptableObject
{
    public PowerUpItemTarget Target;
    [Header("HP,MPは実数値で増加量を記述する、Attackは+10%の場合に0.1と記述する")]
    public float PowerUpValue;
}
