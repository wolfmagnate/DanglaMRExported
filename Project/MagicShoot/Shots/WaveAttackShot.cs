using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveAttackShot : AttackShot
{
    Rigidbody rigid;
    Vector3 startPoint;
    Vector3 verticalVector;
    public override void Go()
    {
        rigid = GetComponent<Rigidbody>();
        startPoint = transform.position;
        rigid.velocity = direction * Speed;
        var x = direction.x * Speed;
        var z = direction.z * Speed;
        verticalVector = new Vector3(-z, 0, x);
        rigid.velocity += verticalVector * Mathf.Cos(time);
    }

    public void FixedUpdate()
    {
        // 直前のベクトルの影響を抜く
        rigid.velocity -= verticalVector * Mathf.Cos(time);

        // 300は色々試して変更しないといけない
        time += Mathf.PI / (10);

        // 今回の速度の影響を与える
        rigid.velocity += verticalVector * Mathf.Cos(time);
    }


    float time = 0;
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
    private Vector3 direction = Vector3.zero;
    public override void SetDirection(Vector3 direction)
    {
        this.direction = direction;
        this.direction = this.direction.normalized;
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

        GenerateHitEffect();
        KillEffectGameObject(HitEffect);
    }


    int CanHitTimes;
    float Attack;
    float Speed;
    float Distance;
    MagicAttribute Attribute;
    List<BadStatus> BadStatuses;
    List<float> Possibilities;


    public override void Init(float attack, float speed, int canHitTimes, float distance, float range, MagicAttribute attribute, List<BadStatus> badStatuses, List<float> possiblities, GameObject effect,GameObject hitEffect)
    {
        CanHitTimes = canHitTimes;
        Attack = attack;
        Speed = speed;
        Distance = distance;
        Range = range;
        this.Attribute = attribute;
        BadStatuses = badStatuses;
        Possibilities = possiblities;
        Effect = effect;
        HitEffect = hitEffect;

        // Rangeの分だけの大きさの当たり判定にする
        transform.localScale = new Vector3(Range, Range, Range);
        GenerateEffect();
    }

    public override void SetRandom()
    {
    }
}
