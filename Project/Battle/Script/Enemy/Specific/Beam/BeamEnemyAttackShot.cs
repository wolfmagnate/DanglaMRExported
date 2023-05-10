using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamEnemyAttackShot : EnemyAttackShot
{
    protected override IEnumerator Die()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    bool HasHit = false;

    protected override void OnTriggerEnter(Collider other)
    {
        if (HasHit)
        {
            return;
        }
        HasHit = true;
        other.gameObject.GetComponent<PlayerStatus>().Damage(Attack);
    }

    private void OnTriggerStay(Collider other)
    {
        OnTriggerEnter(other);
    }

    public override void Go()
    {
    }
}
