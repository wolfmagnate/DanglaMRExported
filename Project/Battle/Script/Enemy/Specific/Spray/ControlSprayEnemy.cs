using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class ControlSprayEnemy : ControlEnemy
{
    public GameObject[] Shots;

    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(5));
            var shooter = new SprayEnemyShooter();
            shooter.CreateShot(transform.position, Quaternion.identity, Attack: CalcAttack(Attack), Speed: 0f, Distance: 3, Shot: Shots.GetRandomElement(), transform);
            shooter.LookAt(GetNearestHelpPoint().transform.position);
            shooter.RandomRotation(40);
            shooter = new SprayEnemyShooter();
            shooter.CreateShot(transform.position, Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))), Attack: CalcAttack(Attack), Speed: 0f, Distance: 3, Shot: Shots.GetRandomElement(), transform);
            shooter.LookAt(GetNearestHelpPoint().transform.position);
            shooter.RandomRotation(40);
            shooter = new SprayEnemyShooter();
            shooter.CreateShot(transform.position, Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))), Attack: CalcAttack(Attack), Speed: 0f, Distance: 3, Shot: Shots.GetRandomElement(), transform);
            shooter.LookAt(GetNearestHelpPoint().transform.position);
            shooter.RandomRotation(40);
        }
    }

    protected override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            switch((GetNearestHelpPoint().transform.position - transform.position).magnitude)
            {
                case float distance when distance > 0.8f:
                    JumpFar();
                    break;
                case float distance when distance <= 0.8f && distance > 0.3f:
                    Jump();
                    break;
                case float distance when distance <= 0.3f:
                    JumpNear();
                    break;
            }
            Jump();
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(1.5f));
        }
    }


    public GameObject JumpEffect;
    void Jump()
    {
        var effect1 = Instantiate(JumpEffect, transform.position, Quaternion.identity);
        Destroy(effect1, 5);
        Vector3 direc = (GetNearestHelpPoint().transform.position - transform.position).normalized * 0.5f;
        direc = Quaternion.Euler(Random.Range(-360f, 360f), Random.Range(-360f, 360f), Random.Range(-360f, 360f)) * direc;
        transform.position += direc;
    }

    void JumpFar()
    {
        var effect1 = Instantiate(JumpEffect, transform.position, Quaternion.identity);
        Destroy(effect1, 5);
        Vector3 direc = (GetNearestHelpPoint().transform.position - transform.position).normalized * 0.5f;
        direc = Quaternion.Euler(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * direc;
        transform.position += direc;
    }

    void JumpNear()
    {
        var effect1 = Instantiate(JumpEffect, transform.position, Quaternion.identity);
        Destroy(effect1, 5);
        Vector3 direc = -(GetNearestHelpPoint().transform.position - transform.position).normalized * 0.5f;
        direc = Quaternion.Euler(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)) * direc;
        transform.position += direc;
    }

    GameObject GetNearestHelpPoint()
    {
        var helpPoints = GameObject.FindGameObjectsWithTag("HelpPoint");
        return helpPoints.MinBy(x => (x.transform.position - transform.position).sqrMagnitude).First();
    }

    Vector3 GetRandomVector(Vector3 forward)
        => Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180)) * forward;
}
