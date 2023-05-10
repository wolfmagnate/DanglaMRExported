using DG.Tweening;
using System.Collections;
using System.Linq;
using UnityEngine;

public class ControlBossStage10Enemy : ControlEnemy
{

    protected override IEnumerator AttackCoroutine()
    {
        int i = 0;
        while (true)
        {
            switch (Random.Range(0, 6))
            {
                case 0:
                    CurseField();
                    break;
                case 1:
                    HealField();
                    break;
                case 2:
                    NegativeAccelShot();
                    break;
                case 3:
                    ManyBeamShot();
                    break;
                case 4:
                    JumpHomingShot();
                    break;
                case 5:
                    SpecialShot();
                    break;
            }
            i++;
            yield return new WaitForSeconds(CalcTime(8));
        }
    }

    [Header("毒攻撃")]
    public GameObject CurseFieldEffect;
    public GameObject CurseShot;
    void CurseField()
    {
        var effect = Instantiate(CurseFieldEffect, transform.position, Quaternion.identity);
        effect.transform.parent = transform;
        Sequence seq = DOTween.Sequence();
        seq.Append(effect.transform.DOScale(0.5f * Vector3.one, CalcTime(2.5f)));
        seq.Append(effect.transform.DOScale(Vector3.one, CalcTime(2.5f)));
        StartCoroutine(CurseShotCoroutine());
        seq.Play();
    }

    IEnumerator CurseShotCoroutine()
    {
        for(int i = 0;i < 4; i++)
        {
            yield return new WaitForSeconds(1.5f);
            var shot = Instantiate(CurseShot, transform.position, Quaternion.Euler(-90, 0, 0));
            var attackShot = shot.GetComponent<BossStage10CurseAttackShot>();
            attackShot.transform.forward = (Player.transform.position - transform.position).normalized;
            attackShot.Attack = CalcAttack(0.1f);
            attackShot.Distance = 5;
            attackShot.Speed = 0.5f;
            attackShot.Go();
        }
    }

    [Header("回復エリア")]
    public GameObject HealChargeEffect;
    public GameObject HealChargeSucceed;
    public GameObject HealChargeFail;
    BossStage10EnemyStatusController statusController;
    float DamageAmount;
    void HealField()
    {
        StartCoroutine(HealFieldCoroutine());
    }

    IEnumerator HealFieldCoroutine()
    {
        // チャージエフェクト
        var charge = Instantiate(HealChargeEffect, transform.position, Quaternion.identity);
        charge.transform.parent = transform;
        // ダメージ量判定開始
        DamageAmount = 0;
        statusController = GetComponent<BossStage10EnemyStatusController>();
        statusController.AddOnDamage(DamageCounter);
        yield return new WaitForSeconds(CalcTime(4));
        Destroy(charge);
        // ダメージ量判定
        statusController.RemoveOnDamage(DamageCounter);
        if (DamageAmount > 200)
        {
            // 回復失敗
            var effect = Instantiate(HealChargeFail, transform.position, Quaternion.identity);
            Destroy(effect, 2);
        }
        else
        {
            // 回復成功
            var effect = Instantiate(HealChargeSucceed, transform.position, Quaternion.identity);
            statusController.HP += 500;
            Destroy(effect, 2);
        }
    }

    void DamageCounter(float amount)
    {
        DamageAmount += amount;
    }

    [Header("負の加速度を持つショット")]
    public GameObject NegativeShot;
    void NegativeAccelShot()
    {
        GameObject[] shots = new GameObject[30];
        // 30個ほどランダムに方向を決める
        for (int i = 0; i < 30; i++)
        {
            var shotDirection = GetRandomVector();
            shots[i] = Instantiate(NegativeShot, transform.position, Quaternion.identity);
            shots[i].GetComponent<Rigidbody>().velocity = shotDirection;
            shots[i].GetComponent<ConstantForce>().force = -shotDirection * 0.5f;
            var attackShot = shots[i].GetComponent<BossStage10EnemyNegativeAttackShot>();
            attackShot.Attack = CalcAttack(5);
            attackShot.Distance = 8;
            attackShot.Speed = 1;
        }
    }
    [Header("工場建設")]
    public GameObject BeamPoint;
    public GameObject BeamExplosion;
    public GameObject Factory;
    void ManyBeamShot()
    {
        StartCoroutine(ManyBeamCoroutine());
    }

    IEnumerator ManyBeamCoroutine()
    {
        yield return new WaitForSeconds(CalcTime(1.5f));
        Vector3 effectPosition1 = transform.position + transform.right;
        Vector3 effectPosition2 = transform.position - transform.right;
        var effect1 = Instantiate(BeamPoint, effectPosition1, Quaternion.identity);
        var effect2 = Instantiate(BeamPoint, effectPosition2, Quaternion.identity);
        yield return new WaitForSeconds(CalcTime(4.5f));
        CreateFactory(effectPosition1);
        CreateFactory(effectPosition2);
        var effect11 = Instantiate(BeamExplosion, effectPosition1, Quaternion.identity);
        var effect22 = Instantiate(BeamExplosion, effectPosition2, Quaternion.identity);
        Destroy(effect1);
        Destroy(effect2);
        Destroy(effect11,3);
        Destroy(effect22,3);
    }

    void CreateFactory(Vector3 position)
    {
        Instantiate(Factory, position, Quaternion.identity);
    }

    [Header("ジャンプ弾")]
    public GameObject JumpShot;
    public GameObject JumpEffect;
    void JumpHomingShot()
    {
        Vector3[] positions = new Vector3[6];
        positions[0] = transform.position;
        for (int i = 1; i < 5; i++)
        {
            positions[i] = positions[i - 1] + 2.5f * GetRandomVector();
            var effect = Instantiate(JumpEffect, positions[i], Quaternion.identity);
            effect.transform.localScale = 0.2f * Vector3.one;
            effect.transform.rotation = Quaternion.Euler(90, 0, 0);
            Destroy(effect, i);
        }
        positions[5] = Player.transform.position;

        var shot = Instantiate(JumpShot, transform.position, Quaternion.identity);
        var attackShot = shot.GetComponent<BossStage10EnemyJumpAttackShot>();
        attackShot.Attack = CalcAttack(15);
        attackShot.Distance = 10;
        attackShot.Speed = 0;

        Sequence seq = DOTween.Sequence();
        seq.Append(shot.transform.DOJump(positions[1], 0.5f, 2, 1));
        seq.Append(shot.transform.DOJump(positions[2], 0.5f, 2, 1));
        seq.Append(shot.transform.DOJump(positions[3], 0.5f, 2, 1));
        seq.Append(shot.transform.DOJump(positions[4], 0.5f, 2, 1));
        seq.Append(shot.transform.DOJump(positions[5], 0.5f, 2, 1));
        seq.Play(); ;
    }


    // 結界は3地点
    public GameObject[] SpecialShots;
    public GameObject SpecialShotEffectDome;
    protected override void StartMethod()
    {
    }

    void SpecialShot()
    {
        StartCoroutine(SpecialShotCoroutine());
    }

    IEnumerator SpecialShotCoroutine()
    {
        Vector3 cashedPosition = Player.transform.position;
        yield return new WaitForSeconds(0.2f);
        var dome = Instantiate(SpecialShotEffectDome, transform.position, Quaternion.identity);
        dome.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        dome.transform.parent = transform;
        dome.transform.localPosition = Vector3.zero;
        var seq = DOTween.Sequence();
        seq.Append(dome.transform.DOScale(Vector3.one, CalcTime(2.5f)));
        seq.Append(dome.transform.DOScale(0.5f * Vector3.one, CalcTime(2.5f)));
        yield return new WaitForSeconds(CalcTime(5));
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                var shot1 = SpecialShots.GetRandomElement();
                var shot = Instantiate(shot1, transform.position, Quaternion.identity);
                shot.transform.localScale = 0.3f * Vector3.one;
                var attackshot = shot.GetComponent<BossStage10SpecialAttackShot>();
                attackshot.Target = cashedPosition;
                attackshot.Attack = CalcAttack(2);
                attackshot.Distance = 10;
                attackshot.Speed = 1;
                attackshot.Go();
            }
            yield return new WaitForSeconds(CalcTime(0.3f));
        }
        yield return new WaitForSeconds(CalcTime(1));
        Destroy(dome);
    }

    Vector3 GetRandomVector() => Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))) * new Vector3(1, 0, 0);

    public GameObject[] MoveLocations;
    GameObject[] MoveLocationInstances;
    protected override IEnumerator MoveCoroutine()
    {
        MoveLocationInstances = new GameObject[3];
        for (int i = 0; i < MoveLocations.Length; i++)
        {
            // 移動先用エフェクトを3つ飛ばす
            // 移動先用エフェクトは、プレイヤーの周り3mを高速でゆらゆらと回転する(挙動自体はNormalEnemyBと同じ実装)
            MoveLocationInstances[i] = Instantiate(MoveLocations[i]);
        }
        Hop();
        yield return new WaitForSeconds(CalcTime(8));
        while (true)
        {
            switch ((Player.transform.position - transform.position).magnitude)
            {
                case float distance when distance > 4:
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            HopFar();
                            break;
                        case 1:
                            Jump();
                            break;
                        case 2:
                            FastCircleFar();
                            break;
                    }
                    break;
                case float distance when distance <= 4 && distance > 2:
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            Hop();
                            break;
                        case 1:
                            Jump();
                            break;
                        case 2:
                            FastCircle();
                            break;
                    }
                    break;
                case float distance when distance <= 2:
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            HopNear();
                            break;
                        case 1:
                            Jump();
                            break;
                        case 2:
                            FastCircleNear();
                            break;
                    }
                    break;
            }
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(8));
        }
    }

    void Hop()
    {
        var seq = DOTween.Sequence();
        Vector3 cashedCurrentPosition = transform.position;
        seq.Append(transform.DOJump(cashedCurrentPosition + transform.forward * 0.5f, 1, 1, CalcTime(2)).SetEase(Ease.Linear));
        seq.Append(transform.DOJump(cashedCurrentPosition + transform.right * 0.5f, 1, 1, CalcTime(2)).SetEase(Ease.Linear));
        seq.Append(transform.DOJump(cashedCurrentPosition, 1, 1, CalcTime(2)).SetEase(Ease.Linear));
        seq.Play();
    }

    void HopFar()
    {
        var seq = DOTween.Sequence();
        Vector3 cashedCurrentPosition = transform.position;
        var direction = (Player.transform.position - transform.position).normalized;
        seq.Append(transform.DOJump(cashedCurrentPosition + direction * 0.33f, 1, 1, CalcTime(2)).SetEase(Ease.Linear));
        seq.Append(transform.DOJump(cashedCurrentPosition + direction * 0.66f, 1, 1, CalcTime(2)).SetEase(Ease.Linear));
        seq.Append(transform.DOJump(cashedCurrentPosition + direction, 1, 1, CalcTime(2)).SetEase(Ease.Linear));
        seq.Play();
    }

    void HopNear()
    {
        var seq = DOTween.Sequence();
        Vector3 cashedCurrentPosition = transform.position;
        var direction = -(Player.transform.position - transform.position).normalized;
        seq.Append(transform.DOJump(cashedCurrentPosition + direction * 0.33f, 1, 1, CalcTime(2)).SetEase(Ease.Linear));
        seq.Append(transform.DOJump(cashedCurrentPosition + direction * 0.66f, 1, 1, CalcTime(2)).SetEase(Ease.Linear));
        seq.Append(transform.DOJump(cashedCurrentPosition + direction, 1, 1, CalcTime(2)).SetEase(Ease.Linear));
        seq.Play();
    }

    void Jump()
    {
        int[] locationIndexes = Shaffle3();
        var seq = DOTween.Sequence();
        seq.Append(transform.DOJump(MoveLocationInstances[locationIndexes[0]].transform.position, 1, 2, CalcTime(6)).SetEase(Ease.Linear));
        seq.Play();
    }

    private static int[] Shaffle3() => Random.Range(0, 6) switch
    {
        0 => new[] { 0, 1, 2 },
        1 => new[] { 0, 2, 1 },
        2 => new[] { 1, 0, 2 },
        3 => new[] { 1, 2, 0 },
        4 => new[] { 2, 1, 0 },
        5 => new[] { 2, 0, 1 },
        _ => null,
    };

    void FastCircle()
    {
        var seq = DOTween.Sequence();
        float now = 0.0f;
        seq.Append(DOTween.To(x => RotateAround(x), 0, 360, CalcTime(3f)));
        seq.Append(DOTween.To(x => RotateAround(x), 0, Random.Range(-20,20), CalcTime(3f)));
        void RotateAround(float x)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(Player.transform.position, axis, x - now);
            now = x;
        }
        seq.Play();
    }

    void FastCircleNear()
    {
        var seq = DOTween.Sequence();
        float now = 0.0f;
        var direction = (Player.transform.position - transform.position).normalized;
        seq.Append(DOTween.To(x => RotateAround(x), 0, 360, CalcTime(3f)));
        seq.Append(DOTween.To(x => RotateAround(x), 0, Random.Range(-20,20), CalcTime(3f)));
        void RotateAround(float x)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(Player.transform.position, axis, x - now);
            transform.position = transform.position + direction / 90f;
            now = x;
        }
        seq.Play();
    }

    void FastCircleFar()
    {
        var seq = DOTween.Sequence();
        float now = 0.0f;
        var direction = -(Player.transform.position - transform.position).normalized;
        seq.Append(DOTween.To(x => RotateAround(x), 0, 360, CalcTime(3f)));
        seq.Append(DOTween.To(x => RotateAround(x), 0, Random.Range(-20,20), CalcTime(3f)));
        void RotateAround(float x)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(Player.transform.position, axis, x - now);
            transform.position = transform.position + direction / 90f;
            now = x;
        }
        seq.Play();
    }
}
