using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 強化方法を表す。様々なバフの効果はすべてPowerUpTypeとして表される
/// </summary>
[System.Serializable]
[CreateAssetMenu(menuName = "ScriptableObject/PowerUpType")]
public class PowerUpType : ScriptableObject
{
    public PowerUpTarget Target;
    public PowerUpPattern Pattern;
    public float PowerUpValue;

    [Header("PatternがAdd AttributeかつTargetがAttributeのときのみ有効")]
    public MagicAttribute Attribute;
    [Header("PatternがAdd AttributeかつTargetがBadStatusのときのみ有効")]
    public List<BadStatus> BadStatuses;
    public List<float> BadStatusPossibilities;
}

