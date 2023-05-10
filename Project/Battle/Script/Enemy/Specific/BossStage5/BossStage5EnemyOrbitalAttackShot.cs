using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage5EnemyOrbitalAttackShot : EnemyAttackShot
{

    protected override void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerStatus>().Damage(Attack);
        Destroy(gameObject);
    }


    protected override IEnumerator Die()
    {
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }

    protected override void Update()
    {
    }
}
