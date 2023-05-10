using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightShooter : MagicShooter
{
    private bool HasShot;
    private int ChargeFrame;

    public StraightShooter(ShootPlayer shootPlayer, ChargeUIControl chargeUI): base(shootPlayer, chargeUI)
    {

    }

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
        chargeUI.ChangeChargeAmount(0);
    }

    public override bool CanShoot()
    {
        var magic = ShootPlayer.usingMagic;
        if (magic.ChargeTime >= 0.01)
        {
            return base.CanShoot() && magic.ChargeTime <= ChargeFrame;
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
            chargeUI.ChangeChargeAmount(ChargeFrame / ShootPlayer.usingMagic.ChargeTime);
        }
    }

    public override GameObject[] GenerateShot()
    {
        // 不自然なマジックナンバー1を usingMagic.Rushに書き換えたら連射が有効になる
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
                attackShot.Init(attack,speed,canHitTimes,distance,range,attribute,badStatuses,badStatusPossibility, Effect, HitEffect);
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

    protected override float GetConsumeMP()
    {
        if(ShootPlayer.usingMagic.ChargeTime >= 0.01)
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
