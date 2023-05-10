using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBombShooter : EnemyShooter
{
    private EnemyAttackShot attackShot;
    public GameObject Explosion;



    public override void CreateShot(Vector3 position, Quaternion rotation, float Attack, float Speed, float Distance, GameObject Shot)
    {
        if(Explosion == null) { Debug.LogError("ExplosionÇ…îöîjÇÃGameObjectÇí«â¡ÇµÇƒÇ≠ÇÍÅI"); }
        var shot = GameObject.Instantiate(Shot);
        shot.transform.position = position;
        shot.transform.rotation = rotation;
        shot.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        var attackShot = shot.GetComponent<BossBombAttackShot1>();
        this.attackShot = attackShot;
        attackShot.Attack = Attack;
        attackShot.Speed = Speed;
        attackShot.Distance = Distance;
        attackShot.OnDie.AddListener(() => {
            var exp = GameObject.Instantiate(Explosion);
            exp.transform.position = position;
            exp.transform.rotation = rotation;
            exp.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            var expAttack = exp.GetComponent<BossBombAttackShot2>();
            expAttack.Attack = Attack;
            expAttack.Speed = 0;
            expAttack.Distance = 1000;
        });
    }

    public override void Go()
    {
    }

    public override void SetDirection(Vector3 direction)
    {
    }
}
