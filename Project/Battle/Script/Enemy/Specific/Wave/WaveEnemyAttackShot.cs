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

        // ���O�̃x�N�g���̉e���𔲂�
        rigid.velocity -= verticalVector * Mathf.Cos(time);

        // 300�͐F�X�����ĕύX���Ȃ��Ƃ����Ȃ�
        time += Mathf.PI / (70);

        // ����̑��x�̉e����^����
        rigid.velocity += verticalVector * Mathf.Cos(time);
    }
}
