using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShooter : MagicShooter
{
    private bool HasShot;
    private int ChargeFrame;

    public WaveShooter(ShootPlayer shootPlayer, ChargeUIControl chargeUI) : base(shootPlayer, chargeUI) { }

    public override void OnClickLeave(ShootPlayer shootPlayer)
    {
        if (ShootPlayer.usingMagic.ChargeTime >= 0.01)
        {
            if (base.CanShoot())
            {
                Shoot(GenerateShot());
                ConsumeMP(shootPlayer);
                AfterShoot();
            }

            HasShot = false;
        }
        else
        {
            ChargeFrame = 0;
            HasShot = false;
        }
    }

    public override void AfterShoot()
    {

        ChargeFrame = 0;
        HasShot = true;
    }

    public override bool CanShoot()
    {

        if (ShootPlayer.usingMagic.ChargeTime >= 0.01)
        {
            return base.CanShoot() && ShootPlayer.usingMagic.ChargeTime < ChargeFrame;
        }
        else
        {
            return base.CanShoot() && !HasShot;
        }
    }

    public override void Charge()
    {

        if (ShootPlayer.usingMagic.ChargeTime >= 0.01)
        {
            ChargeFrame++;
        }
    }

    public override GameObject[] GenerateShot()
    {
        var shots = new GameObject[1];

        if (ShootPlayer.usingMagic.ChargeTime >= 0.01)
        {
            float ratio = ChargeFrame / ShootPlayer.usingMagic.ChargeTime;
            var magic = ShootPlayer.usingMagic;
            var (attack, speed, canHitTimes, distance, range, attribute, badStatuses, badStatusPossibility) =
                (magic.BattleAttack * ratio, magic.Speed, magic.BattleCanHitTimes, magic.Distance, magic.Range * ratio, magic.Attribute, magic.BadStatuses, magic.BadStatusPossibility);
            for (int i = 0; i < 1; i++)
            {
                shots[i] = GameObject.Instantiate(ShootPlayer.usingShot);
                var attackShot = shots[i].GetComponent<AttackShot>();
                attackShot.Init(attack, speed, canHitTimes, distance, range, attribute, badStatuses, badStatusPossibility, Effect, HitEffect);
            }

        }
        else
        {
            for (int i = 0; i < 1; i++)
            {
                shots[i] = GameObject.Instantiate(ShootPlayer.usingShot);
                var attackShot = shots[i].GetComponent<AttackShot>();
                attackShot.Init(ShootPlayer.usingMagic.BattleAttack, ShootPlayer.usingMagic.Speed, ShootPlayer.usingMagic.BattleCanHitTimes,
                    ShootPlayer.usingMagic.Distance, ShootPlayer.usingMagic.Range, ShootPlayer.usingMagic.Attribute,
                    ShootPlayer.usingMagic.BadStatuses, ShootPlayer.usingMagic.BadStatusPossibility, Effect, HitEffect);
            }
        }
        return shots;
    }

    public override void OnClickStart()
    {
    }
}
