using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/PowerUpItem")]
public class PowerUpItemMasterData : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public int Price;
    public PowerUpItemEffectMasterData Effect;
    [TextArea]
    public string Description;
    
}
