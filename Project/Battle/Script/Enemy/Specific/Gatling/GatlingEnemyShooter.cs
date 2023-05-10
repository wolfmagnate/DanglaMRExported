using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingEnemyShooter : EnemyShooter
{
    private GatlingEnemyAttackShot attackShot;

    public override void CreateShot(Vector3 position, Quaternion rotation, float Attack, float Speed, float Distance, GameObject Shot)
    {
        var shot = GameObject.Instantiate(Shot);
        shot.transform.position = position;
        shot.transform.rotation = rotation;
        shot.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        attackShot = shot.GetComponent<GatlingEnemyAttackShot>();
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
