using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossBombAttackShot1 : EnemyAttackShot
{
    protected override void OnTriggerEnter(Collider other)
    {
    }

    public UnityEvent OnDie;

    protected override IEnumerator Die()
    {
        yield return new WaitForSeconds(5);
        OnDie.Invoke();
        Destroy(gameObject);
    }


    protected override void Update()
    {
    }

}
