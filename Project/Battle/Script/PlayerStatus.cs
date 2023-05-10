using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float HP;
    public float MP;

    public float MPRatio = 1;
    public float HPRatio = 1;

    float SetHP;
    float SetMP;

    public float MaxHP
    {
        get => (SetHP + PowerUpItemShop.GetHPBuffer().HP) * HPRatio;
    }
    public float MaxMP
    {
        get => (SetMP + PowerUpItemShop.GetMPBuffer().MP) * MPRatio;
    }

    private void Start()
    {
        SetHP = HP;
        SetMP = MP;
        HP += PowerUpItemShop.GetHPBuffer().HP;
        MP += PowerUpItemShop.GetMPBuffer().MP;
        HP *= HPRatio;
        MP *= MPRatio;
    }

    public void Damage(float attack)
    {
        HP -= attack;
    }
}
