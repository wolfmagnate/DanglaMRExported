using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeAttackShot : AttackShot
{
    public override void Go()
    {
        LifeFrame = 1;
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

        // Range�̕������̑傫���̓����蔻��ɂ���
        transform.localScale = new Vector3(Range, Range, Range);

    }

    private List<string> hitEnemynames = new List<string>();
    public void OnTriggerStay(Collider other)
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

        Destroy(GenerateHitEffect(other),1);
    }

    protected GameObject GenerateHitEffect(Collider other)
    {
        HitEffect = Instantiate(HitEffect);
        HitEffect.transform.position = other.transform.position;
        HitEffect.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
        return HitEffect;
    }

    public override void SetDirection(Vector3 direction)
    {
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
        if(LifeFrame == 0)
        {
            Destroy(gameObject);
        }
        LifeFrame--;

        if (CanHitTimes <= 0)
        {
            Destroy(gameObject);
        }
    }

    public override void SetRandom()
    {
    }
}
