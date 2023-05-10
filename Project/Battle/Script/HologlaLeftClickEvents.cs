using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologlaLeftClickEvents : MonoBehaviour
{
    public static bool Clicking { get; private set; } = false;
    public void OnDown()
    {
        Clicking = true;
    }

    public void OnUp()
    {
        Clicking = false;
    }
}
