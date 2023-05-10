using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectEnemyAttackShot : EnemyAttackShot
{
    Rigidbody rigid;

    protected override void Start()
    {
        base.Start();
        rigid = GetComponent<Rigidbody>();
        StartCoroutine(Wind());
    }

    protected IEnumerator Wind()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            rigid.velocity = Quaternion.Euler(new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5))) * rigid.velocity;
        }
    }
}
