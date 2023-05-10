using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MagicShooter
{
    public RayShooter(ShootPlayer shootPlayer, ChargeUIControl chargeUI): base(shootPlayer, chargeUI) { }

    public override void OnClickLeave(ShootPlayer shootPlayer)
    {
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

        RealEffect = GameObject.Instantiate(Effect);
        var lineRenderer = RealEffect.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, shootPlayer.transform.position + new Vector3(0, -0.05f, 0) - shootPlayer.transform.forward * 0.3f);
        lineRenderer.SetPosition(1, shootPlayer.transform.position + new Vector3(0, -0.05f, 0) + ShootPlayer.usingDirection.normalized * ShootPlayer.usingMagic.Distance);
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        RealEffect.transform.parent = shootPlayer.transform;
        GameObject.Destroy(RealEffect, 0.05f);

        for (int i = 0; i < 1; i++)
        {
            shots[i] = GameObject.Instantiate(ShootPlayer.usingShot);
            var attackShot = shots[i].GetComponent<RayAttackShot>();
            attackShot.Init(ShootPlayer.usingMagic.BattleAttack, ShootPlayer.usingMagic.Speed, ShootPlayer.usingMagic.BattleCanHitTimes,
                ShootPlayer.usingMagic.Distance, ShootPlayer.usingMagic.Range, ShootPlayer.usingMagic.Attribute,
                ShootPlayer.usingMagic.BadStatuses, ShootPlayer.usingMagic.BadStatusPossibility, Effect, HitEffect);
            attackShot.SetDirection(shootPlayer.transform.forward);
        }

        return shots;
    }


    GameObject RealEffect;
    public override void OnClickStart()
    {
    }

}
