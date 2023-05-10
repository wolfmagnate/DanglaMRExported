using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage10EnemyJumpAttackShot : EnemyAttackShot
{
    protected override void Start()
    {
        StartCoroutine(Die());
        startPosition = gameObject.transform.position;
    }

    protected override void Update()
    {
    }

}
