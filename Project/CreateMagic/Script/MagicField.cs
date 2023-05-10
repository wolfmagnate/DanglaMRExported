using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicField
{
    public readonly MagicCard[,] MagicCards;
    public readonly int Height;
    public readonly int Width;

    public MagicField(int height,int width)
    {
        Height = height;
        Width = width;
        MagicCards = new MagicCard[Height,Width];
    }
}
