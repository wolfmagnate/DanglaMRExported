using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage10SpecialAttackShot : EnemyAttackShot
{
    protected override void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerStatus>().Damage(Attack);
        Destroy(gameObject);
    }

    public Vector3 Target { get; set; }
    Vector3 CenterPower;
    public override void Go()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = Quaternion.Euler(Random.Range(-150f,150f), Random.Range(-150f, 150f), Random.Range(-150f, 150f)) * (Target - transform.position).normalized * Speed;
        startPosition = gameObject.transform.position;


        Vector3 direction = (Target - transform.position);

        float apow2 = rigid.velocity.sqrMagnitude;
        float bpow2 = direction.sqrMagnitude;
        float abdot = Vector3.Dot(rigid.velocity, direction);
        float s = (bpow2 / 2) / (bpow2 - abdot * abdot / apow2);
        float t = -abdot / apow2 * s;
        float radius = (t * rigid.velocity + s * direction).magnitude;
        float velocitypow2 = rigid.velocity.sqrMagnitude;
        float mass = rigid.mass;
        CenterPower = (mass * velocitypow2 / radius) * (t * rigid.velocity + s * direction).normalized;
        float distance = radius * 2 * Mathf.PI * (Vector3.Angle(rigid.velocity, direction) * 2) / 360;
        rigid.velocity *= distance;

    }
    Rigidbody rigid;
    protected override void Update()
    {
        base.Update();
        Vector3 direction = (Target - transform.position);

        float apow2 = rigid.velocity.sqrMagnitude;
        float bpow2 = direction.sqrMagnitude;
        float abdot = Vector3.Dot(rigid.velocity, direction);
        float s = (bpow2 / 2) / (bpow2 - abdot * abdot / apow2);
        float t = -abdot / apow2 * s;
        float radius = (t * rigid.velocity + s * direction).magnitude;
        float velocitypow2 = rigid.velocity.sqrMagnitude;
        float mass = rigid.mass;
        CenterPower = (mass * velocitypow2 / radius) * (t * rigid.velocity + s * direction).normalized;
        float distance = radius * 2 * Mathf.PI * (Vector3.Angle(rigid.velocity, direction) * 2) / 360;
        GetComponent<ConstantForce>().force = CenterPower;
    }
}
