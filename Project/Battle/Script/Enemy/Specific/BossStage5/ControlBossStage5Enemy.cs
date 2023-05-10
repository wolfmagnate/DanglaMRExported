using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public static class DOTweenUtils
{

    public static Tween DoRotateAround(this Transform target, float endValue, float duration, Vector3 origin)
    {
        float prevVal = 0.0f;

        Tween ret = DOTween.To(x => RotateAroundPrc(x), 0.0f, endValue, duration);

        void RotateAroundPrc(float value)
        {
            float delta = value - prevVal;
            target.RotateAround(origin, Vector3.up, delta);
            prevVal = value;
        }

        return ret;
    }
}

public class ControlBossStage5Enemy : ControlEnemy
{
    protected override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            if(currentMode == BattleMode.blue)
            {
                // 出来る限り距離を保つような移動を行う
                switch((Player.transform.position - transform.position).magnitude)
                {
                    case float distance when distance > 5:
                        // 近づく
                        switch (Random.Range(0, 3))
                        {
                            case 0:
                                UpAndDownFar();
                                break;
                            case 1:
                                BackAndForceFar();
                                break;
                            case 2:
                                CircleFar();
                                break;
                        }
                        break;

                    case float distance when distance <= 5 && distance > 4:
                        // 距離を保つ
                        switch (Random.Range(0, 3))
                        {
                            case 0:
                                UpAndDown();
                                break;
                            case 1:
                                BackAndForce();
                                break;
                            case 2:
                                Circle();
                                break;
                        }
                        break;

                    case float distance when distance <= 4:
                        // 遠ざかる
                        switch (Random.Range(0, 3))
                        {
                            case 0:
                                UpAndDownNear();
                                break;
                            case 1:
                                BackAndForceNear();
                                break;
                            case 2:
                                CircleNear();
                                break;
                        }
                        break;
                }
                
            }
            if(currentMode == BattleMode.green)
            {
                // 出来るだけ近接を保つ
                switch ((Player.transform.position - transform.position).magnitude)
                {
                    case float distance when distance > 3:
                        // 近づく
                        switch (Random.Range(0, 3))
                        {
                            case 0:
                                UpAndDownFar();
                                break;
                            case 1:
                                BackAndForceFar();
                                break;
                            case 2:
                                CircleFar();
                                break;
                        }
                        break;

                    case float distance when distance <= 3 && distance > 1:
                        // 距離を保つ
                        switch (Random.Range(0, 3))
                        {
                            case 0:
                                UpAndDown();
                                break;
                            case 1:
                                BackAndForce();
                                break;
                            case 2:
                                Circle();
                                break;
                        }
                        break;

                    case float distance when distance <= 1:
                        // 遠ざかる
                        switch (Random.Range(0, 3))
                        {
                            case 0:
                                UpAndDownNear();
                                break;
                            case 1:
                                BackAndForceNear();
                                break;
                            case 2:
                                CircleNear();
                                break;
                        }
                        break;
                }
            }
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(5));
        }
    }
    private void BackAndForce()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.forward * 1.5f - (Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Append(transform.DOMove(-transform.forward * 1.5f - (Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Play();
    }

    private void Circle()
    {
        var seq = DOTween.Sequence();
        float now = 0.0f;
        seq.Append(DOTween.To(x => RotateAround(x), 0, Random.Range(-100, 100), CalcTime(2.5f)));
        seq.Append(transform.DOMove(-(Player.transform.position - transform.position).normalized, CalcTime(2.5f)).SetRelative(true));
        void RotateAround(float x)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(Player.transform.position, axis, x - now);
            now = x;
        }
        seq.Play();
    }

    private void UpAndDown()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.up * 1f - (Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Append(transform.DOMove(-transform.up * 1f - (Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Play();
    }

    private void BackAndForceFar()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.forward * 1.5f + (Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Append(transform.DOMove(-transform.forward * 1.5f + (Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Play();
    }

    private void CircleFar()
    {
        var seq = DOTween.Sequence();
        float now = 0.0f;
        seq.Append(DOTween.To(x => RotateAround(x), 0, Random.Range(-100, 100), CalcTime(2.5f)));
        seq.Append(transform.DOMove((Player.transform.position - transform.position).normalized * 1.5f, CalcTime(2.5f)).SetRelative(true));
        void RotateAround(float x)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(Player.transform.position, axis, x - now);
            now = x;
        }
        seq.Play();
    }

    private void UpAndDownFar()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.up * 1f + (Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Append(transform.DOMove(-transform.up * 1f + (Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Play();
    }

    private void BackAndForceNear()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.forward * 1.5f + -(Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Append(transform.DOMove(-transform.forward * 2f + -(Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Play();
    }

    private void CircleNear()
    {
        var seq = DOTween.Sequence();
        float now = 0.0f;
        seq.Append(DOTween.To(x => RotateAround(x), 0, Random.Range(-100, 100), CalcTime(2.5f)));
        seq.Append(transform.DOMove(-(Player.transform.position - transform.position).normalized * 1.5f, CalcTime(2.5f)).SetRelative(true));
        void RotateAround(float x)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(Player.transform.position, axis, x - now);
            now = x;
        }
        seq.Play();
    }

    private void UpAndDownNear()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.up * 1f + -(Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Append(transform.DOMove(-transform.up * 1f + -(Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Play();
    }
    [Header("オーラ変更エフェクト")]
    public GameObject BlueBottom;
    public GameObject BlueCharge;
    public GameObject BlueExplosion;
    public GameObject GreenBottom;
    public GameObject GreenCharge;
    public GameObject GreenExplosion;
    [Header("オーラ")]
    public GameObject BlueAura;
    public GameObject GreenAura;

    enum BattleMode { blue, green }
    void ChangeMode(BattleMode mode)
    {
        currentMode = mode;
        GameObject bottomEffect = null;
        GameObject chargeEffect = null;
        GameObject explodeEffect = null;
        GameObject nowAura = null;
        GameObject nextAura = null;
        if(mode == BattleMode.blue)
        {
            bottomEffect = BlueBottom;
            chargeEffect = BlueCharge;
            explodeEffect = BlueExplosion;
            nowAura = transform.Find("LifeAura(Clone)")?.gameObject;
            nextAura = BlueAura;
        }
        if (mode == BattleMode.green)
        {
            bottomEffect = GreenBottom;
            chargeEffect = GreenCharge;
            explodeEffect = GreenExplosion;
            nowAura = transform.Find("WaterAura(Clone)")?.gameObject;
            nextAura = GreenAura;
        }
        StartCoroutine(ChangeRoutine(bottomEffect,chargeEffect,explodeEffect,nowAura,nextAura,mode));
    }

    IEnumerator ChangeRoutine(GameObject bottom, GameObject charge, GameObject explode, GameObject nowAura, GameObject nextAura, BattleMode mode)
    {
        var btnEffect = Instantiate(bottom,transform.position - new Vector3(0,0.3f,0),Quaternion.identity);
        Destroy(btnEffect, 0.5f);
        yield return new WaitForSeconds(0.5f);
        var chargeEffect = Instantiate(charge, transform.position, Quaternion.identity);
        Destroy(chargeEffect, 1f);
        yield return new WaitForSeconds(1f);
        var explodeEffect = Instantiate(explode, transform.position, Quaternion.identity);
        Destroy(explodeEffect, 3);
        if (nowAura != null) { Destroy(nowAura); }
        var next = Instantiate(nextAura, transform);
        next.transform.localPosition = Vector3.zero;
        next.transform.localScale = 0.6f * Vector3.one;
        ChangeStatusMode(mode);
    }


    Func<float, float> GetModeAttack;
    BattleMode currentMode;
    void ChangeStatusMode(BattleMode mode)
    {
        if(mode == BattleMode.blue)
        {
            GetModeAttack = (float attack) => attack * (Player.transform.position - transform.position).magnitude switch
            {
                float distance when distance <= 3 => 1.5f,
                float distance when distance > 3 => 0.5f,
                _ => 1
            };
        }
        if(mode == BattleMode.green)
        {
            GetModeAttack = (float attack) => attack * (Player.transform.position - transform.position).magnitude switch
            {
                float distance when distance <= 3 => 0.5f,
                float distance when distance > 3 => 1.5f,
                _ => 1
            };
        }
    }

    protected override IEnumerator AttackCoroutine()
    {
        GetModeAttack = (float attack) => attack * (Player.transform.position - transform.position).magnitude switch
        {
            float distance when distance <= 3 => 0.5f,
            float distance when distance > 3 => 1.5f,
            _ => 1
        };
        ChangeMode(BattleMode.green);
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(7));
            if(currentMode == BattleMode.blue)
            {
                switch (Random.Range(0, 3))
                {
                    case 0:
                        FarAttack_Summon();
                        break;
                    case 1:
                        FarAttack_Orbital();
                        break;
                    case 2:
                        FarAttack_Beam();
                        break;
                }
            }
            if(currentMode == BattleMode.green)
            {
                switch (Random.Range(0, 3))
                {
                    case 0:
                        NearAttack_Spray();
                        break;
                    case 1:
                        NearAttack_Slash();
                        break;
                    case 2:
                        NearAttack_Brust();
                        break;
                }
            }
        }
    }

    protected override float CalcAttack(float attack) => GetModeAttack(base.CalcAttack(attack));

    [Header("近距離攻撃：スプレー")]
    public GameObject Spray;
    void NearAttack_Spray()
    {
        var spray = Spray;
        // まずはSprayを横方向に発射する
        var generatedSpray1 = Instantiate(spray, transform.position, Quaternion.Euler(0, 90, 0) * transform.rotation);
        var generatedSpray2 = Instantiate(spray, transform.position, Quaternion.Euler(0, -90,0) * transform.rotation);

        var attackshot1 = generatedSpray1.GetComponent<BossStage5EnemySprayAttackShot>();
        attackshot1.Init(CalcAttack(5f));
        var attackshot2 = generatedSpray2.GetComponent<BossStage5EnemySprayAttackShot>();
        attackshot2.Init(CalcAttack(5f));

        // 待機後、回転させる
        Sequence seq = DOTween.Sequence();
        seq.Append(generatedSpray1.transform.DORotate(Vector3.zero, CalcTime(3)).SetRelative(true));
        seq.Join(generatedSpray2.transform.DORotate(Vector3.zero, CalcTime(3)).SetRelative(true));
        seq.Append(generatedSpray1.transform.DORotate(new Vector3(0, 360, 0), CalcTime(2), RotateMode.FastBeyond360).SetRelative(true));
        seq.Join(generatedSpray2.transform.DORotate(new Vector3(0, 360, 0), CalcTime(2), RotateMode.FastBeyond360).SetRelative(true));
        seq.Play();
    }

    [Header("近距離攻撃：スラッシュ")]
    public GameObject SlashEffectLifeOrbit;
    public GameObject SlashShot;
    void NearAttack_Slash()
    {
        // まずはOrbitを4つ発射する
        GameObject[] orbits = new GameObject[4];
        for(int i = 0;i < 4; i++)
        {
            int a = i;
            orbits[a] = Instantiate(SlashEffectLifeOrbit, transform.position, Quaternion.identity);
            orbits[a].transform.localScale = 0.5f * Vector3.one;
            // 90i度だけ回転させればいい
            Sequence seq = DOTween.Sequence();
            seq.Append(orbits[a].transform.DOMove(Quaternion.Euler(0, 90 * i, 0) * transform.forward * 1.5f, CalcTime(1)).SetRelative(true));
            seq.Append(orbits[a].transform.DoRotateAround(360, CalcTime(4), transform.position).SetRelative(true)).AppendCallback(() =>
            {
                // Orbitが破壊されると同時に、周囲に32個のSlashが展開される(32/4==8個)
                for(int j = 0;j < 8; j++)
                {
                    var xx = Instantiate(SlashShot, orbits[a].transform.position + GetRandomVector() * 1.5f, Quaternion.Euler(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360)));
                    xx.transform.localScale = 0.5f * Vector3.one;
                    var attackShot = xx.GetComponent<BossStage5EnemySlashAttackShot>();
                    attackShot.Init(CalcAttack(5));
                    Destroy(xx, 1);
                }
                for (int j = 0; j < 4; j++)
                {
                    var xx = Instantiate(SlashShot, orbits[a].transform.position + GetRandomVector() * 2.5f, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
                    xx.transform.localScale = 0.5f * Vector3.one;
                    var attackShot = xx.GetComponent<BossStage5EnemySlashAttackShot>();
                    attackShot.Init(CalcAttack(5));
                    Destroy(xx, 1);
                }
            });
            seq.Play();
            Destroy(orbits[i], CalcTime(5.1f));
        }
    }

    Vector3 GetRandomVector() => Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))) * new Vector3(1, 0, 0);

    [Header("近距離攻撃：バースト射撃")]
    public GameObject BrustChargeEffect;
    public GameObject PillarBrustShot;
    void NearAttack_Brust()
    {
        // 4秒間チャージ
        var effect = Instantiate(BrustChargeEffect, transform.position + transform.right, Quaternion.identity);
        Destroy(effect, CalcTime(4));
        var effect2 = Instantiate(BrustChargeEffect, transform.position - transform.right, Quaternion.identity);
        Destroy(effect2, CalcTime(4));
        StartCoroutine(NearAttack_Brust_Coroutine());
    }

    IEnumerator NearAttack_Brust_Coroutine()
    {
        yield return new WaitForSeconds(CalcTime(4));
        for(int i = 0;i < 15; i++)
        {
            Vector3 generatePosition = transform.position + Quaternion.Euler(0, 24 * i, 0) * transform.forward;
            var shooter = new BossStage5EnemyBrustShooter();
            shooter.CreateShot(generatePosition, transform.rotation, Attack: CalcAttack(5), Speed: 1f, Distance: 3, Shot: PillarBrustShot);
            shooter.SetDirection(Quaternion.Euler(0, 24 * i, 0) * transform.forward);
            shooter.Go();
        }
        ChangeMode(BattleMode.blue);
    }

    [Header("遠距離攻撃：デスビームエリア")]
    public GameObject FarBeamEffect;
    void FarAttack_Beam()
    {
        var pos = Player.transform.position;
        var effect = Instantiate(FarBeamEffect, pos, Quaternion.identity);
        effect.transform.localScale = 0.3f * Vector3.one;
        effect.transform.rotation = Quaternion.Euler(90, 0, 0);
        for(int i = 0;i < 12; i++)
        {
            Vector3 generatePosition = pos + Quaternion.Euler(0, 30 * i, 0) * Player.transform.forward;
            var effect2 = Instantiate(FarBeamEffect,generatePosition, Quaternion.identity );
            effect2.transform.LookAt(Player.transform);
            effect2.transform.localScale = 0.05f * Vector3.one;
            Destroy(effect2, 4.5f);
        }
        Destroy(effect, 4.5f);
        StartCoroutine(SetUpFarBeam(pos));
    }

    public GameObject FarBeamExplosionShot;
    IEnumerator SetUpFarBeam(Vector3 center)
    {
        yield return new WaitForSeconds(4);
        // 大量の爆発with当たり判定
        for (int i = 0; i < 5; i++)
        {
            for(int j = 0;j < 5; j++)
            {
                var explosion = Instantiate(FarBeamExplosionShot, center + GetRandomVector(), Quaternion.identity);
                var attackShot = explosion.GetComponent<BossStage5EnemyFarBeamAttackShot>();
                explosion.transform.localScale = 0.2f * Vector3.one;
                attackShot.Attack = CalcAttack(2);
                attackShot.Distance = 100;
                attackShot.Speed = 0;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    [Header("遠距離攻撃：軌道爆撃")]
    public GameObject FarOrbitalShot;
    void FarAttack_Orbital()
    {

        // まずはOrbitを4つ発射する
        GameObject[] orbits = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            int a = i;
            orbits[a] = Instantiate(FarOrbitalShot, transform.position, Quaternion.identity);
            orbits[a].transform.localScale = 0.5f * Vector3.one;
            // 90i度だけ回転させればいい
            Sequence seq = DOTween.Sequence();
            seq.Append(orbits[a].transform.DOMove(Quaternion.Euler(0, 90 * i, 0) * transform.forward * 1.5f, CalcTime(1)).SetRelative(true));
            seq.Append(orbits[a].transform.DoRotateAround(360 * 3, CalcTime(4), transform.position).SetRelative(true)).AppendCallback(() =>
            {
                orbits[a].GetComponent<Rigidbody>().velocity = (Player.transform.position - orbits[a].transform.position).normalized;
                var atttackShot = orbits[a].GetComponent<BossStage5EnemyOrbitalAttackShot>();
                atttackShot.Attack = CalcAttack(4);
                atttackShot.Distance = 10;
            });
            seq.Play();
            Destroy(orbits[a], CalcTime(20f));
        }
    }

    [Header("遠距離攻撃：配下出撃")]
    public GameObject SummonEffect;
    public GameObject SummonCharge;
    public GameObject SummonEnemy;
    void FarAttack_Summon()
    {
        var effect = Instantiate(SummonCharge, transform.position, Quaternion.identity);
        effect.transform.localScale = 2f * Vector3.one;
        effect.transform.rotation = Quaternion.Euler(90, 0, 0);
        Destroy(effect, CalcTime(4));
        StartCoroutine(FarAttack_Summon_Next());
    }

    IEnumerator FarAttack_Summon_Next()
    {
        yield return new WaitForSeconds(CalcTime(4));
        for(int i = 0;i < 3; i++)
        {
            Vector3 generatePosition = transform.position + 2 * GetRandomVector();
            var summon = Instantiate(SummonEffect, generatePosition + new Vector3(0, -0.2f, 0), Quaternion.identity);
            summon.transform.localScale = 0.2f * Vector3.one;
            summon.transform.rotation = Quaternion.Euler(90, 0, 0);
            Destroy(summon, 1);
            Instantiate(SummonEnemy, generatePosition, Quaternion.identity);
        }
        ChangeMode(BattleMode.green);
    }
}