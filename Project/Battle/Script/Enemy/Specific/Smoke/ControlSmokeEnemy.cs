using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class ControlSmokeEnemy : ControlEnemy
{
    public GameObject RealShot;
    public GameObject SmokeShot;

    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(Random.Range(3, 6)));
            if ((Player.transform.position - transform.position).magnitude > 4) { continue; }
            var shooter = new SmokeEnemyShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 0.3f, Distance: 3, Shot: RealShot);
            shooter.SetDirection((GetNearestHelpPoint().transform.position - transform.position).normalized);
            shooter.Go();
            6.Times(() => {
                shooter = new SmokeEnemyShooter();
                shooter.CreateShot(transform.position + GetRandomVector(transform.forward) * Random.Range(1f,3f), transform.rotation, Attack: CalcAttack(Attack/10), Speed: 0f, Distance: 3, Shot: SmokeShot);
                shooter.SetDirection(transform.forward);
                shooter.SmodeMode();
                shooter.Go();
            });
        }
    }

    protected override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            Minus();
            yield return new WaitForSeconds(CalcTime(1f));
            Plus();
            yield return new WaitForSeconds(CalcTime(1f));
        }
    }

    void Minus()
    {
        var seq = DOTween.Sequence();
        seq.Append(transform.DoRotateAround(Random.Range(-20, -30), CalcTime(1f), GetNearestHelpPoint().transform.position).SetRelative(true));
        MoveToHelpPoint(seq);
        seq.Play();
    }

    void Plus()
    {
        var seq = DOTween.Sequence();
        seq.Append(transform.DoRotateAround(Random.Range(20, 30), CalcTime(1f), GetNearestHelpPoint().transform.position).SetRelative(true));
        MoveToHelpPoint(seq);
        seq.Play();
    }

    Vector3 GetRandomVector(Vector3 forward)
        => Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180)) * forward;


    void MoveToHelpPoint(Sequence seq)
    {
        GameObject nearestHelpPoint = GetNearestHelpPoint();
        if ((nearestHelpPoint.transform.position - transform.position).magnitude <= 3) { return; }
        Vector3 moveDirection = (nearestHelpPoint.transform.position - transform.position).normalized;
        float Length = Mathf.Min((nearestHelpPoint.transform.position - transform.position).magnitude - 3, 0.33f);
        seq.Join(transform.DOMove(moveDirection * Length, CalcTime(3)).SetRelative(true));
    }


    GameObject GetNearestHelpPoint()
    {
        var helpPoints = GameObject.FindGameObjectsWithTag("HelpPoint");
        return helpPoints.MinBy(x => (x.transform.position - transform.position).sqrMagnitude).First();
    }
}
