using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������@��\���B�l�X�ȃo�t�̌��ʂ͂��ׂ�PowerUpType�Ƃ��ĕ\�����
/// </summary>
[System.Serializable]
[CreateAssetMenu(menuName = "ScriptableObject/PowerUpType")]
public class PowerUpType : ScriptableObject
{
    public PowerUpTarget Target;
    public PowerUpPattern Pattern;
    public float PowerUpValue;

    [Header("Pattern��Add Attribute����Target��Attribute�̂Ƃ��̂ݗL��")]
    public MagicAttribute Attribute;
    [Header("Pattern��Add Attribute����Target��BadStatus�̂Ƃ��̂ݗL��")]
    public List<BadStatus> BadStatuses;
    public List<float> BadStatusPossibilities;
}

