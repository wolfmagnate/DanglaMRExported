using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage5EnemyBrustAttackShot : EnemyAttackShot
{
    protected override IEnumerator Die()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
