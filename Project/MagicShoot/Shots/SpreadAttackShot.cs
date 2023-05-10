using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpreadAttackShot : AttackShot
{
    Vector3 startPoint;
    Rigidbody rigid;
    public override void Go()
    {
        startPoint = transform.position;
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = direction * Speed;
    }

    private void Update()
    {
        if ((transform.position - startPoint).magnitude > Distance)
        {
            Destroy(gameObject);
            DestroyEffect();
        }
        if (CanHitTimes <= 0)
        {
            Destroy(gameObject);
            DestroyEffect();
        }
    }

    private void Start()
    {
        float search_radius = 10f;
        int mask = LayerMask.GetMask("Enemy");
        var hits = Physics.SphereCastAll(
            transform.position,
            search_radius,
            transform.forward,
            0.01f,
            mask
        ).Select(h => h.transform.gameObject).ToList();

        if (0 < hits.Count())
        {
            float min_target_distance = float.MaxValue;
            GameObject target = null;

            foreach (var hit in hits)
            {
                float target_distance = Vector3.Dot(rigid.velocity, (hit.transform.position - transform.position)) / (rigid.velocity.magnitude * (hit.transform.position - transform.position).magnitude);
                target_distance *= -1;
                if (target_distance < min_target_distance)
                {
                    min_target_distance = target_distance;
                    target = hit.transform.gameObject;
                }
            }

            // targetの方向へ行く
            float target_angle = Vector3.Dot(rigid.velocity, (target.transform.position - transform.position)) / (rigid.velocity.magnitude * (target.transform.position - transform.position).magnitude);
            if (target_angle > 0.98)
            {
                var rotation = Quaternion.FromToRotation(rigid.velocity, (target.transform.position - transform.position));
                rigid.velocity = rotation * rigid.velocity;
                targetObject = target;
                StartCoroutine(Homing());
            }
        }
    }

    private GameObject targetObject;

    IEnumerator Homing()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if(targetObject == null) { yield break; }
            // targetの方向へ行く
            float target_angle = Vector3.Dot(rigid.velocity, (targetObject.transform.position - transform.position)) / (rigid.velocity.magnitude * (targetObject.transform.position - transform.position).magnitude);
            if (target_angle > 0.98)
            {
                var rotation = Quaternion.FromToRotation(rigid.velocity, (targetObject.transform.position - transform.position));
                rigid.velocity = rotation * rigid.velocity;
            }
        }
    }

    private Vector3 direction = Vector3.zero;
    public override void SetDirection(Vector3 direction)
    {
        this.direction = Quaternion.Euler(RandomX, RandomY, RandomZ) * direction;
        this.direction = this.direction.normalized;
    }

    private float RandomX, RandomY, RandomZ;
    public override void SetRandom()
    {
        (RandomX, RandomY, RandomZ) = (Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
    }

    private List<string> hitEnemynames = new List<string>();
    public void OnTriggerStay(Collider other)
    {
        // 一度当たった敵にはもう当たらない
        if (hitEnemynames.Contains(other.gameObject.name)) { return; }
        // 貫通可能回数以上は当たらない
        if (CanHitTimes <= 0) { return; }
        var status = other.gameObject.GetComponent<EnemyStatusController>();
        // ダメージを与える
        status.Damage(Attack, Attribute);
        // 状態異常を与える
        int count = BadStatuses.Count;

        for (int i = 0; i < count; i++)
        {
            status.AddBadStatus(BadStatuses[i], Possibilities[i]);
        }

        hitEnemynames.Add(other.gameObject.name);
        CanHitTimes--;

        // エフェクト
        GenerateHitEffect();
        Destroy(HitEffect, 2);
        KillEffectGameObject(HitEffect);
    }


    int CanHitTimes;
    float Attack;
    float Speed;
    float Distance;
    MagicAttribute Attribute;
    List<BadStatus> BadStatuses;
    List<float> Possibilities;


    public override void Init(float attack, float speed, int canHitTimes, float distance, float range, MagicAttribute attribute, List<BadStatus> badStatuses, List<float> possiblities, GameObject effect, GameObject hitEffect)
    {
        CanHitTimes = canHitTimes;
        Attack = attack;
        Speed = speed;
        Distance = distance;
        Range = range;
        this.Attribute = attribute;
        BadStatuses = badStatuses;
        Possibilities = possiblities;
        HitEffect = hitEffect;
        Effect = effect;

        // Rangeの分だけの大きさの当たり判定にする
        transform.localScale = new Vector3(Range, Range, Range);

        // エフェクト発生
        GenerateEffect();
    }

}
