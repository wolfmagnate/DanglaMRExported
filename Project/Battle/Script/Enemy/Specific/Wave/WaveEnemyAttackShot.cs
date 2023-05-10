using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyAttackShot : EnemyAttackShot
{
    public Vector3 verticalVector;

    Rigidbody rigid;
    protected override void Start()
    {
        base.Start();
        rigid = GetComponent<Rigidbody>();
    }

    public override void Go()
    {
        base.Go();

        rigid = GetComponent<Rigidbody>();
        var x = transform.forward.x * Speed * 5;
        var z = transform.forward.z * Speed * 5;
        verticalVector = new Vector3(-z, 0, x);
        rigid.velocity += verticalVector * Mathf.Cos(time);
    }

    float time = 0;
    protected override void Update()
    {
        if ((startPosition - transform.position).magnitude > Distance) { Destroy(gameObject); }

        // 直前のベクトルの影響を抜く
        rigid.velocity -= verticalVector * Mathf.Cos(time);

        // 300は色々試して変更しないといけない
        time += Mathf.PI / (70);

        // 今回の速度の影響を与える
        rigid.velocity += verticalVector * Mathf.Cos(time);
    }
}
