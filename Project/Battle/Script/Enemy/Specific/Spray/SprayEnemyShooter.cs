using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayEnemyShooter : EnemyShooter
{
    private SprayEnemyAttackShot attackShot;

    public void CreateShot(Vector3 position, Quaternion rotation, float Attack, float Speed, float Distance, GameObject Shot, Transform parent)
    {
        var shot = GameObject.Instantiate(Shot);
        shot.transform.parent = parent;
        shot.transform.position = position;
        shot.transform.rotation = rotation;
        shot.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        attackShot = shot.GetComponent<SprayEnemyAttackShot>();
        attackShot.Attack = Attack;
        attackShot.Speed = Speed;
        attackShot.Distance = Distance;
    }

    internal void RandomRotation(int v)
    {
        attackShot.transform.rotation = Quaternion.Euler(UnityEngine.Random.Range(-v, v), UnityEngine.Random.Range(-v, v), UnityEngine.Random.Range(-v, v)) * attackShot.transform.rotation;
    }

    public void LookAt(Vector3 position)
    {
        attackShot.transform.LookAt(position);
    }

    public override void CreateShot(Vector3 position, Quaternion rotation, float Attack, float Speed, float Distance, GameObject Shot)
    {
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
