using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyAttackShot2 : EnemyAttackShot
{
    private bool HasHit = false;
    protected override void OnTriggerEnter(Collider other)
    {
        if (HasHit) { return; }
        other.gameObject.GetComponent<PlayerStatus>().Damage(Attack);
        HasHit = true;
    }


    public override void Go()
    {
    }

    protected override IEnumerator Die()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }


    protected override void Update()
    {
    }
}
