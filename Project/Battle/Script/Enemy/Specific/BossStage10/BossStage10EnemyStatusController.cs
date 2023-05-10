using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossStage10EnemyStatusController : EnemyStatusController
{
    public void AddOnDamage(UnityAction<float> action)
    {
        OnDamageWithAmount.AddListener(action);
    }

    public void RemoveOnDamage(UnityAction<float> action)
    {
        OnDamageWithAmount.RemoveListener(action);
    }
}
