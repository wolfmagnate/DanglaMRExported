using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ControlSpinEnemy : ControlEnemy
{
    public GameObject Shot;

    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(Random.Range(3, 7)));
            var shooter = new SpinEnemyShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 0.9f, Distance: 3, Shot: Shot);
            shooter.SetDirection((GetNearestHelpPoint().transform.position - transform.position).normalized);
            shooter.Go();
        }
    }

    protected override void Update()
    {
    }

    protected override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            Spin1();
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(3));
            Spin2();
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(3));
        }
    }

    void Spin1()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DORotate(new Vector3(0,3600,0),CalcTime(3), RotateMode.FastBeyond360));
        sequence.Join(transform.DOScale(new Vector3(0.3f,1.5f,0.3f),CalcTime(3)));
        MoveToHelpPoint(sequence);
        sequence.Play();
    }

    void Spin2()
    {

        var sequence = DOTween.Sequence();
        sequence.Append(transform.DORotate(new Vector3(0, -3600, 0), CalcTime(3), RotateMode.FastBeyond360));
        sequence.Join(transform.DOScale(new Vector3(1.5f, 0.3f, 1.5f), CalcTime(3)));
        MoveToHelpPoint(sequence);
        sequence.Play();
    }

    void MoveToHelpPoint(Sequence seq)
    {
        GameObject nearestHelpPoint = GetNearestHelpPoint();
        if ((nearestHelpPoint.transform.position - transform.position).magnitude <= 3) { return; }
        Vector3 moveDirection = (nearestHelpPoint.transform.position - transform.position).normalized;
        float Length = Mathf.Min((nearestHelpPoint.transform.position - transform.position).magnitude - 3, 1);
        seq.Join(transform.DOMove(moveDirection * Length,CalcTime(3)).SetRelative(true));
    }

    GameObject GetNearestHelpPoint()
    {
        var helpPoints = GameObject.FindGameObjectsWithTag("HelpPoint");
        return helpPoints.MinBy(x => (x.transform.position - transform.position).sqrMagnitude).First();
    }

}
