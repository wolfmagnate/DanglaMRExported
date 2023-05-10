using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEnemyAttackShot : EnemyAttackShot
{

    bool CanHeal = true;
    protected override void OnTriggerEnter(Collider other)
    {
        if (!CanHeal) { return; }
        other.gameObject.GetComponent<EnemyStatusController>().HP += Attack;
        CanHeal = false;
        Destroy(gameObject, 3);
    }

    Rigidbody rigid;
    protected override void Start()
    {
        base.Start();
        rigid = GetComponent<Rigidbody>();
    }

    protected override void Update()
    {
        if ((startPosition - transform.position).magnitude > Distance) { Destroy(gameObject); }
        var targets = GameObject.FindGameObjectsWithTag("Enemy");
        if(targets.Length == 0) { return; }
        if(targets[0].name == "HealEnemy(Clone)" && targets.Length == 1) { return; }
        if(targets[0].name == "HealEnemy(Clone)")
        {
            targets[0] = targets[1];
        }
        rigid.velocity = (targets[0].transform.position - transform.position).normalized * rigid.velocity.magnitude;
    }
}
