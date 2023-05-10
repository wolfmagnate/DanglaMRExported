using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingShooter : MagicShooter
{
    public GatlingShooter(ShootPlayer shootPlayer, ChargeUIControl chargeUI):base(shootPlayer, chargeUI) { }

    private int ChargeFrame;
    public override void OnClickLeave(ShootPlayer shootPlayer)
    {
        if (CanShootMid())
        {
            Shoot(GenerateShot());
            ConsumeMP(shootPlayer);
            AfterShoot();
        }
    }

    /// <summary>
    /// フルチャージしていない状態で弾丸を打てるのか
    /// </summary>
    /// <returns>打てるかどうか</returns>
    private bool CanShootMid()
    {
        int Rush = ShootPlayer.usingMagic.BattleRush;
        float ChargeTime = ShootPlayer.usingMagic.ChargeTime;
        int n = Mathf.RoundToInt(Rush * ChargeFrame / ChargeTime);
        Debug.Log(n);
        return base.CanShoot() && n >= 15;
    }

    public override void AfterShoot()
    {
        ChargeFrame = 0;
        chargeUI.ChangeChargeAmount(0);
    }

    public override bool CanShoot()
    {
        return base.CanShoot() && ShootPlayer.usingMagic.ChargeTime <= ChargeFrame;
    }

    public override void Charge()
    {
        ChargeFrame++;
        chargeUI.ChangeChargeAmount(ChargeFrame / ShootPlayer.usingMagic.ChargeTime);
    }

    public override GameObject[] GenerateShot()
    {
        int Rush = ShootPlayer.usingMagic.BattleRush;
        float ChargeTime = ShootPlayer.usingMagic.ChargeTime;
        int n = Mathf.RoundToInt(Rush * ChargeFrame / ChargeTime);
        return new GameObject[n];
    }

    protected override float GetConsumeMP()
    {
        float ChargeTime = ShootPlayer.usingMagic.ChargeTime;
        return base.GetConsumeMP() * (ChargeFrame / ChargeTime);
    }

    public override void OnClickStart()
    {
        
    }

    public override void Shoot(GameObject[] shots)
    {
        // shotsをintervalごとに弾を発生させて打ち出すコルーチンを呼び出す
        CoroutineHandler.StartStaticCoroutine(RushInvervalCoroutine(shots.Length, shootPlayer.transform.position, shootPlayer.transform.rotation));
    }

    private IEnumerator RushInvervalCoroutine(int Rush, Vector3 position, Quaternion rotation)
    {
        for(int i = 0;i < Rush; i++)
        {
            var shot = IntervaledShoot();
            shot.transform.position = position;
            shot.transform.rotation = rotation;
            var attackshot = shot.GetComponent<AttackShot>();
            attackshot.SetDirection(ShootPlayer.usingDirection);
            attackshot.Go();
            var sp = GameObject.Instantiate(SpecialEffect);
            sp.transform.position = shootPlayer.transform.position;
            sp.transform.rotation = shootPlayer.transform.rotation;
            GameObject.Destroy(sp, 10);
            yield return new WaitForSeconds(ShootPlayer.usingMagic.RushInterval);
        }
    }

    private GameObject IntervaledShoot()
    {
        GameObject shot = GameObject.Instantiate(ShootPlayer.usingShot);
        var attackShot = shot.GetComponent<AttackShot>();
        attackShot.Init(ShootPlayer.usingMagic.BattleAttack, ShootPlayer.usingMagic.Speed, ShootPlayer.usingMagic.BattleCanHitTimes,
            ShootPlayer.usingMagic.Distance, ShootPlayer.usingMagic.Range, ShootPlayer.usingMagic.Attribute,
            ShootPlayer.usingMagic.BadStatuses, ShootPlayer.usingMagic.BadStatusPossibility, Effect, HitEffect);
        return shot;
    }

    public GameObject SpecialEffect { get; set; }
}
