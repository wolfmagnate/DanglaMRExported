using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAttackShot : AttackShot
{
    public override void Go()
    {
        LifeFrame = 2;
    }

    public override void Init(float attack, float speed, int canHitTimes, float distance, float range, MagicAttribute attribute, List<BadStatus> badStatuses, List<float> possiblities, GameObject effect, GameObject hitEffect)
    {
        CanHitTimes = canHitTimes;
        Attack = attack;
        Speed = speed;
        Distance = distance;
        Range = range;
        Attribute = attribute;
        BadStatuses = badStatuses;
        Possibilities = possiblities;
        Effect = effect;
        HitEffect = hitEffect;

    }


    private List<string> hitEnemynames = new List<string>();
    public void OnTriggerStayRay(Collider other)
    {
        // ��x���������G�ɂ͂���������Ȃ�
        if (hitEnemynames.Contains(other.gameObject.GetInstanceID().ToString())) { return; }
        // �ђʉ\�񐔈ȏ�͓�����Ȃ�
        if (CanHitTimes <= 0) { return; }
        var status = other.gameObject.GetComponent<EnemyStatusController>();
        // �_���[�W��^����
        status.Damage(Attack, Attribute);
        // ��Ԉُ��^����
        var EnemyStatus = other.gameObject.GetComponent<EnemyStatusController>();
        if (!EnemyStatus.OneTimeShotBadStatusTried)
        { 
            int count = BadStatuses.Count;

            for (int i = 0; i < count; i++)
            {
                status.AddBadStatus(BadStatuses[i], Possibilities[i]);
            }

            EnemyStatus.OneTimeShotBadStatusTry();
        }


        hitEnemynames.Add(other.gameObject.GetInstanceID().ToString());
        CanHitTimes--;

        GenerateHitEffect(other);
        Destroy(HitEffect, 1);
    }

    protected void GenerateHitEffect(Collider other)
    {
        GenerateHitEffect();
        HitEffect.transform.position = other.transform.position;
        HitEffect.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    Vector3 direction;
    public override void SetDirection(Vector3 direction)
    {
        this.direction = direction;

    }

    private int LifeFrame;

    int CanHitTimes;
    float Attack;
    float Speed;
    float Distance;
    MagicAttribute Attribute;
    List<BadStatus> BadStatuses;
    List<float> Possibilities;

    // Update is called once per frame
    void Update()
    {

        // Ray�œ����蔻��
        Ray ray = new Ray(transform.position + new Vector3(0, -0.1f, 0), direction);
        // layerMask
        int layerMask = 1 << LayerMask.NameToLayer("Enemy");
        // �f�o�b�O�p
        var hits = Physics.SphereCastAll(ray, Range, Distance, layerMask);
        foreach(var hitInfo in hits)
        {
            OnTriggerStayRay(hitInfo.collider);
            CanHitTimes--;
        }

        if (LifeFrame == 0)
        {
            Destroy(gameObject);
            DestroyEffect();
        }
        LifeFrame--;

        if (CanHitTimes <= 0)
        {
            Destroy(gameObject);
            DestroyEffect();
        }

    }


    protected override void DestroyEffect()
    {
        KillEffectGameObject(HitEffect);
    }

    public override void SetRandom()
    {
    }
}
