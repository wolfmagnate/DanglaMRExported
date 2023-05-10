using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage10EnemyNegativeAttackShot : EnemyAttackShot
{

    protected override void Start()
    {
        startPosition = transform.position;
        StartCoroutine(Die());
    }

}
