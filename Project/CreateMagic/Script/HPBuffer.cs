using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class HPBuffer
{
    [SerializeField]
    float hp;
    public float HP { get => hp; }
    public HPBuffer(float hp)
    {
        this.hp = hp;
    }
}
