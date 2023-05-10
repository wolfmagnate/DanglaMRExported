using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeEnemyShooter : EnemyShooter
{
    private SmokeEnemyAttackShot attackShot;

    private GameObject Myshot;

    public override void CreateShot(Vector3 position, Quaternion rotation, float Attack, float Speed, float Distance, GameObject Shot)
    {
        var shot = GameObject.Instantiate(Shot);
        shot.transform.position = position;
        shot.transform.rotation = rotation;
        shot.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        attackShot = shot.GetComponent<SmokeEnemyAttackShot>();
        attackShot.Attack = Attack;
        attackShot.Speed = Speed;
        attackShot.Distance = Distance;

        Myshot = shot;
    }

    public void SmodeMode()
    {
        Myshot.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
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
