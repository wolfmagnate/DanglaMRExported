using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MPBuffer
{
    [SerializeField]
    float mp;
    public float MP { get => mp; }
    public MPBuffer(float mp)
    {
        this.mp = mp;
    }
}
