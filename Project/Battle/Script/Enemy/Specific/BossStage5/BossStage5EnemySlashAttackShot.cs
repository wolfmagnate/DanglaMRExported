using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage5EnemySlashAttackShot : EnemyAttackShot
{
    public void Init(float attack)
    {
        this.Distance = 4;
        this.Attack = attack;
        this.Speed = 0;
    }
}
