using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBossStage10SummonEnemy : ControlEnemy
{
    public GameObject Target { get; set; }

    protected override IEnumerator AttackCoroutine()
    {
        yield break;
    }

    protected override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            transform.DOMove((Target.transform.position - transform.position).normalized, 2);
            yield return new WaitForSeconds(2);
        }
    }
}
