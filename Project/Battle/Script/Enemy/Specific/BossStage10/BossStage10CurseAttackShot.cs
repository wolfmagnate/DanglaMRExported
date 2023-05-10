using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage10CurseAttackShot : EnemyAttackShot
{
    protected override IEnumerator Die()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    protected override void Update()
    {
        
    }

    bool HasHit = false;
    protected override void OnTriggerEnter(Collider other)
    {
        if (HasHit) { return; }
        CoroutineHandler.StartStaticCoroutine(Curse(other.GetComponent<PlayerStatus>(), Attack));
        transform.localScale = Vector3.zero;
        HasHit = true;
    }

    static IEnumerator Curse(PlayerStatus status, float attack)
    {
        for (int i = 0; i < 100; i++)
        {
            status.Damage(attack);
            yield return null;
        }
    }
}
