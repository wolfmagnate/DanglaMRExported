using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShooter : MagicShooter
{
    private bool HasShot;
    private int ChargeFrame;
    
    public SpreadShooter(ShootPlayer shootPlayer, ChargeUIControl chargeUI): base(shootPlayer, chargeUI) { }
    public override void OnClickLeave(ShootPlayer shootPlayer)
    {
        if (ShootPlayer.usingMagic.ChargeTime >= 0.01)
        {
            if (CanShoot())
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
        var shots = new GameObject[ShootPlayer.usingMagic.BattleRush];

        if (ShootPlayer.usingMagic.ChargeTime >= 0.01)
        {
            float ratio = ChargeFrame / ShootPlayer.usingMagic.ChargeTime;
            var magic = ShootPlayer.usingMagic;
            var (attack, speed, canHitTimes, distance, range, attribute, badStatuses, badStatusPossibility) =
                (magic.BattleAttack * ratio, magic.Speed, magic.BattleCanHitTimes, magic.Distance, magic.Range * ratio, magic.Attribute, magic.BadStatuses, magic.BadStatusPossibility);
            for (int i = 0; i < ShootPlayer.usingMagic.BattleRush; i++)
            {
                shots[i] = GameObject.Instantiate(ShootPlayer.usingShot);
                var attackShot = shots[i].GetComponent<AttackShot>();
                attackShot.Init(attack, speed, canHitTimes, distance, range, attribute, badStatuses, badStatusPossibility, Effect, HitEffect);
                attackShot.SetRandom();
            }

        }
        else
        {
            for (int i = 0; i < ShootPlayer.usingMagic.BattleRush; i++)
            {
                shots[i] = GameObject.Instantiate(ShootPlayer.usingShot);
                var attackShot = shots[i].GetComponent<AttackShot>();
                attackShot.Init(ShootPlayer.usingMagic.BattleAttack, ShootPlayer.usingMagic.Speed, ShootPlayer.usingMagic.BattleCanHitTimes,
                    ShootPlayer.usingMagic.Distance, ShootPlayer.usingMagic.Range, ShootPlayer.usingMagic.Attribute,
                    ShootPlayer.usingMagic.BadStatuses, ShootPlayer.usingMagic.BadStatusPossibility, Effect, HitEffect);
                attackShot.SetRandom();
            }
        }
        return shots;

    }

    protected override float GetConsumeMP()
    {
        if (ShootPlayer.usingMagic.ChargeTime >= 0.01)
        {
            float ratio = ChargeFrame / ShootPlayer.usingMagic.ChargeTime;
            return base.GetConsumeMP() * ratio;
        }
        else
        {
            return base.GetConsumeMP();
        }
    }

    public override void OnClickStart()
    {
    }
}
