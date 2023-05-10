using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public static class GeneratorUtil {
    public static IEnumerator WaitDieOf(EnemyStatusController[] enemyStatusControllers)
    {
        bool[] hasDied = new bool[enemyStatusControllers.Length];
        for(int i = 0;i < hasDied.Length; i++)
        {
            hasDied[i] = false;
        }
        for(int i = 0;i < enemyStatusControllers.Length; i++)
        {
            if(enemyStatusControllers[i].HP <= 0) { hasDied[i] = true; }
            int a = i;
            enemyStatusControllers[i].OnDie.AddListener(()=> { hasDied[a] = true; });
        }
        while (hasDied.Any(x => x == false))
        {
            yield return new WaitForSeconds(0.5f);
        }
    }


    public static IEnumerator WaitDamageOfEnemyHelpPoint(EnemyPointStatus enemyPointStatus, float damage, float maxWaitTime)
    {
        int maxLoop = Mathf.RoundToInt(maxWaitTime * 5);
        int i = 0;
        while((enemyPointStatus.MaxHP - enemyPointStatus.HP) < damage && i < maxLoop)
        {
            yield return new WaitForSeconds(0.2f);
            i++;
        }
    }
}
