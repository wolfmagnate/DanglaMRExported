using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ZukanMagicType")]
public class ZukanMagicType : ScriptableObject
{
    public string Description;

    [SerializeField]
    public MagicType magicType;
}
