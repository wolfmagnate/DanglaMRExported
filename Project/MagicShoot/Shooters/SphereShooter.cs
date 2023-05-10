using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereShooter : MagicShooter
{
    public SphereShooter(ShootPlayer shootPlayer, ChargeUIControl chargeUI): base(shootPlayer, chargeUI) { }

    public override void OnClickLeave(ShootPlayer shootPlayer)
    {
        GameObject.Destroy(RealEffect);
    }

    public override void AfterShoot()
    {
    }


    public override void Charge()
    {
    }

    public override GameObject[] GenerateShot()
    {
        var shots = new GameObject[1];

        
        for (int i = 0; i < 1; i++)
        {
            shots[i] = GameObject.Instantiate(ShootPlayer.usingShot);
            var attackShot = shots[i].GetComponent<OneTimeAttackShot>();
            attackShot.Init(ShootPlayer.usingMagic.BattleAttack, ShootPlayer.usingMagic.Speed, ShootPlayer.usingMagic.BattleCanHitTimes,
                ShootPlayer.usingMagic.Distance, ShootPlayer.usingMagic.Range, ShootPlayer.usingMagic.Attribute,
                ShootPlayer.usingMagic.BadStatuses, ShootPlayer.usingMagic.BadStatusPossibility, Effect, HitEffect);
        }
        
        return shots;
    }


    private GameObject RealEffect;
    public override void OnClickStart()
    {
        // エフェクト作成開始
        RealEffect = GameObject.Instantiate(Effect,shootPlayer.transform.position,Quaternion.identity);
        RealEffect.transform.parent = shootPlayer.transform;

    }

}
