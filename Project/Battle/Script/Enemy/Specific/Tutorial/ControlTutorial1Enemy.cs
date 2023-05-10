using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ControlTutorial1Enemy : ControlNormalEnemyA
{
    protected override IEnumerator AttackCoroutine()
    {
        yield return null;
    }
}
