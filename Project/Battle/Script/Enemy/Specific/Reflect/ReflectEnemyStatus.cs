using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReflectEnemyStatus : EnemyStatusController
{
    public void AddListenerToOnDamage(UnityAction action)
    {
        OnDamage.AddListener(action);
    }

    public void RemoveListenerToOnDamate()
    {
        OnDamage.RemoveAllListeners();
    }
}
