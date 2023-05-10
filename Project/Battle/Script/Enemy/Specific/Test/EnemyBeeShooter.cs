using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeeShooter : EnemyShooter
{
    private EnemyAttackShot attackShot;

    public override void CreateShot(Vector3 position, Quaternion rotation, float Attack, float Speed, float Distance, GameObject Shot)
    {
        var shot = GameObject.CreatePrimitive(PrimitiveType.Cube);
        shot.layer = LayerMask.NameToLayer("EnemyBullet");
        shot.transform.position = position;
        shot.transform.rotation = rotation;
        var rigid = shot.AddComponent<Rigidbody>();
        rigid.useGravity = false;
        var coll = shot.GetComponent<Collider>();
        coll.isTrigger = false;
        shot.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        attackShot = shot.AddComponent<EnemyBeeAttackShot>();
        attackShot.Attack = Attack;
        attackShot.Speed = Speed;
        attackShot.Distance = Distance;
    }

    public override void Go()
    {
        attackShot.Go();
    }

    public override void SetDirection(Vector3 direction)
    {
        attackShot.gameObject.transform.forward = direction;
    }

}
