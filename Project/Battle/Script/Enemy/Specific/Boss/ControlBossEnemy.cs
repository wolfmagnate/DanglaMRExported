using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ControlBossEnemy : ControlEnemy
{
    public float AttackStoneEdge;

    [Header("近接：爆弾設置")]
    public GameObject Explosion1;
    public GameObject Explosion2;
    
    [Header("近接：二属性爆撃")]
    public GameObject SpreadShot1;
    public GameObject SpreadShot2;

    [Header("遠隔：激流")]
    public GameObject WallEffect;
    public GameObject Beam;
    public GameObject BeamEffect;

    [Header("遠隔：ストーンエッジ")]
    public GameObject StoneEdgeEffect;
    public GameObject StoneEdgeShot;

    [Header("遠隔：召喚")]
    public GameObject ChildrenEffectA;
    public GameObject ChildrenEffectB;
    public GameObject ChildrenEffectC;
    public GameObject ChildrenA;
    public GameObject ChildrenB;
    public GameObject ChildrenC;

    [Header("遠隔：8連雷")]
    public GameObject ThunderShot;

    [Header("死亡エフェクト")]
    public GameObject DeathEffectDOT;
    public GameObject DeathEffectSlashHit;
    public GameObject DeathEffectExplosion;

    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(Random.Range(3, 7)));
            // 一定以上のダメージを受けたらそれによって反撃をしてくる
            //if (IsOverDamage())
            {
             //   OverDamangeMode();
            }
            switch (Random.Range(0,8))
            {
                case 0:
                    SummonEnemyA();
                    SummonEnemyB();
                    break;
                case 1:
                    SummonEnemyB();
                    SummonEnemyC();
                    break;
                case 2:
                    SummonEnemyA();
                    SummonEnemyC();
                    break;
                case 3:
                    // ボスから距離をとる
                    StoneEdge();
                    break;
                case 4:
                    // 頑張って躱す
                    DeathBeam();
                    break;
                case 5:
                    // ボスから距離をとる
                    ExplosionArea();
                    break;
                case 6:
                    // 近づかない
                    SpreadShot();
                    break;
                case 7:
                    // その場から離れる
                    LightningShot();
                    break;
            }
        }
    }

    void SummonEnemyA()
    {
        var pos = transform.position + GetRandomVector(transform.forward) * 0.5f;
        var effect = Instantiate(ChildrenEffectA);
        effect.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        GameObject.Destroy(effect, 5);
        effect.transform.position = pos + new Vector3(0, -0.2f, 0);
        StartCoroutine(Summon(pos, ChildrenA));
    }

    void SummonEnemyB()
    {

        var pos = transform.position + GetRandomVector(transform.forward) * 0.5f;
        var effect = Instantiate(ChildrenEffectB);
        effect.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        GameObject.Destroy(effect,5);
        effect.transform.position = pos + new Vector3(0, -0.2f, 0);
        StartCoroutine(Summon(pos, ChildrenB));
    }

    void SummonEnemyC()
    {
        
        var pos = transform.position + GetRandomVector(transform.forward) * 0.5f;
        var effect = Instantiate(ChildrenEffectC);
        effect.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        GameObject.Destroy(effect,5);
        effect.transform.position = pos + new Vector3(0,-0.2f,0);
        StartCoroutine(Summon(pos, ChildrenC));
    }

    IEnumerator Summon(Vector3 pos,GameObject obj)
    {
        yield return new WaitForSeconds(1);
        var child = Instantiate(obj);
        child.transform.position = pos;
    }

    void StoneEdge()
    {
        StartCoroutine(StoneEdgeCoroutine());
    }

    IEnumerator StoneEdgeCoroutine()
    {
        var effect = Instantiate(StoneEdgeEffect, transform.position, Quaternion.identity);
        effect.transform.localScale = 0.2f * Vector3.one;
        Destroy(effect, CalcTime(4));
        yield return new WaitForSeconds(CalcTime(4f));
        for(int i = 0; i < 24; i++)
        {
            var shooter = new BossEnemyStoneEdgeShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(5), Speed: 0.6f, Distance: 6, Shot: StoneEdgeShot);
            shooter.SetDirection(Quaternion.Euler(0, 30 * i, 0) * transform.forward);
            shooter.Go();
            yield return new WaitForSeconds(CalcTime(0.2f));
        }
    }

    // ダメージエリア設置→ビーム
    void DeathBeam()
    {
        for(int i = 0;i < 2;i++)
        {
            var pos = transform.position + GetRandomVector(transform.forward);
            var effect = Instantiate(WallEffect);
            effect.transform.position = pos;
            effect.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            effect.transform.LookAt(Player.transform.position);
            Destroy(effect, 3.5f);
            StartCoroutine(SetUpBeam(effect.transform, pos));
            SetUpBeamEffect(effect.transform, pos);
        }
    }

    void SetUpBeamEffect(Transform trans, Vector3 pos)
    {
        // 4秒間、エフェクトを出すだけの弾丸を作成する
        var beamEffect = Instantiate(BeamEffect);
        var effectComponent = beamEffect.GetComponent<BossEnemyBeamAttackShotEffect>();
        effectComponent.SetPositions(new Vector3[] { pos + trans.forward * 25f, pos - trans.forward * 25f });
        Destroy(beamEffect, 4);
    }

    IEnumerator SetUpBeam(Transform trans, Vector3 pos)
    {
        yield return new WaitForSeconds(3);
        var beam = Instantiate(Beam);
        var linerender = beam.GetComponent<LineRenderer>();
        linerender.SetPositions(new Vector3[] { pos + trans.forward * 25f, pos - trans.forward * 25f });
        beam.GetComponent<BossEnemyBeamAttackShot>().Attack = 5;
        yield return new WaitForSeconds(1);
        linerender.SetPositions(new Vector3[] { });
        Destroy(beam);
    }


    // 爆弾を設置して、爆破する
    void ExplosionArea()
    {
        for(int i = 0;i < 18;i++) {
            var shooter = new BossBombShooter();
            shooter.Explosion = Explosion2;
            shooter.CreateShot(transform.position + GetRandomVector(transform.forward) * Random.Range(0.2f, 2), transform.rotation, Attack: CalcAttack(10), Speed: 0.9f, Distance: 3, Shot: Explosion1);
        };
    }

    void SpreadShot()
    {
        StartCoroutine(SpreadShotCoroutine());
    }

    IEnumerator SpreadShotCoroutine()
    {
        void Shot()
        {
            var shooter = new BossEnemyShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(10), Speed: 2f, Distance: 9, Shot: SpreadShot1);
            shooter.SetDirection(GetRandomVector(transform.forward));
            shooter.Go();
            shooter = new BossEnemyShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(10), Speed: 2f, Distance: 9, Shot: SpreadShot2);
            shooter.SetDirection(GetRandomVector(transform.forward));
            shooter.Go();
            shooter = new BossEnemyShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(10), Speed: 2f, Distance: 2, Shot: SpreadShot1);
            shooter.SetDirection(GetRandomVector(transform.forward));
            shooter.Go();
            shooter = new BossEnemyShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(10), Speed: 2f, Distance: 2, Shot: SpreadShot2);
            shooter.SetDirection(GetRandomVector(transform.forward));
            shooter.Go();
        }
        for(int i = 0;i < 5; i++)
        {
            Shot();
        }
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 10; i++)
        {
            Shot();
        }
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 10; i++)
        {
            Shot();
        }
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 10; i++)
        {
            Shot();
        }
    }

    void LightningShot()
    {
        GameObject[] shots = new GameObject[8];
        Vector3 cashedPosition = Player.transform.position;
        for(int i = 0;i < 8;i++)
        {
            int a = i;
            shots[a] = Instantiate(ThunderShot, transform.position + Quaternion.Euler(0, 45 * a, 0) * transform.forward, Quaternion.identity);
            shots[a].transform.localScale = 0.3f * Vector3.one;
            var seq = DOTween.Sequence();
            seq.Append(shots[a].transform.DoRotateAround(360, CalcTime(2), transform.position).SetRelative(true));
            seq.Append(shots[a].transform.DOMove(Quaternion.Euler(0, 45 * a, 0) * transform.forward * 1.5f, CalcTime(2)).SetRelative(true)).AppendCallback(
                () =>
                {
                    var enemyAttackShot = shots[a].AddComponent<BossEnemyAttackShot1>();
                    enemyAttackShot.Attack = CalcAttack(4);
                    enemyAttackShot.Distance = 6;
                    enemyAttackShot.Speed = 2;
                    enemyAttackShot.transform.forward = cashedPosition - enemyAttackShot.transform.position;
                    enemyAttackShot.Go();
                }
            );
            seq.Play();
        }

    }

    Vector3 GetRandomVector(Vector3 forward)
        => Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180)) * forward;

    protected override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    BackAndForce();
                    break;
                case 1:
                    Circle();
                    break;
                case 2:
                    UpAndDown();
                    break;
            }
            yield return new WaitForSeconds(CalcTime(Random.Range(3, 7)));
        }
    }
    private void BackAndForce()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.forward, CalcTime(2.5f)).SetRelative(true));
        sequence.Append(transform.DOMove(-transform.forward, CalcTime(2.5f)).SetRelative(true));
        sequence.Play();
    }

    private void Circle()
    {
        var seq = DOTween.Sequence();
        float now = 0.0f;
        seq.Append(DOTween.To(x => RotateAround(x), 0, Random.Range(-60, 60), CalcTime(5)));
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
        sequence.Append(transform.DOMove(transform.up * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Append(transform.DOMove(-transform.up * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Play();
    }

    protected override void Start()
    {
        base.Start();
        GetComponent<EnemyStatusController>().OnDie.AddListener(()=>{
            CoroutineHandler.StartStaticCoroutine(DeathEffect());
        });
    }


    IEnumerator DeathEffect()
    {
        // DOTのエフェクトを配置
        var genDOT = Instantiate(DeathEffectDOT, transform.position, Quaternion.identity);
        var slash = DeathEffectSlashHit;
        var exp = DeathEffectExplosion;
        var pos = transform.position;
        // 大量にslashHitをばらまく
        for (int i = 0;i < 20; i++)
        {
            Instantiate(slash, pos, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1);
        // 大爆発
        Destroy(genDOT);
        var explosion = Instantiate(exp, pos, Quaternion.identity);
        explosion.transform.localScale = new Vector3(3, 3, 3);
    }
}
