using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage5EnemySprayAttackShot : EnemyAttackShot
{
    protected override void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerStatus>().Damage(Attack);
    }
    protected override IEnumerator Die()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    public void Init(float attack)
    {
        Attack = attack;
        Distance = 3;
        Speed = 0;
    }
}
