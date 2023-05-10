using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ZukanPowerUp")]
public class ZukanPowerUp : ScriptableObject
{
    public string Description;

    [SerializeField]
    public PowerUp powerUp;
}
