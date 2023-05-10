using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MagicBuffer
{
    public float Attack
    {
        get => attack;
        private set => attack = value;
    }
    [SerializeField]
    private float attack;
    public MagicBuffer(float attack = 1)
    {
        Attack = attack;
    }
}
