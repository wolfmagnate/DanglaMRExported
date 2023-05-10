using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShopItemPanel : MonoBehaviour
{
    public bool Sold;
    public int Price;

    public int Index
    { 
        get
        {
            int i = 0;
            if (Sold)
            {
                i += 10000000;
            }
            i += Price;
            return i;
        }
    }
}
