using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage5EnemyFarBeamAttackShot : EnemyAttackShot
{
    protected override IEnumerator Die()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    bool HasHit = false;
    protected override void OnTriggerEnter(Collider other)
    {
        if (HasHit) { return; }
        other.gameObject.GetComponent<PlayerStatus>().Damage(Attack);
        HasHit = true;
    }
}
