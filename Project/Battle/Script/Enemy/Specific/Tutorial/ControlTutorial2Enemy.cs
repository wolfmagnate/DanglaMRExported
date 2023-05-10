using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTutorial2Enemy : ControlNormalEnemyB
{
    protected override IEnumerator AttackCoroutine()
    {
        yield return null;
    }
}
