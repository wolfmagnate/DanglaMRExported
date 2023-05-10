using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ControlGigantEnemy : ControlEnemy
{
    public GameObject Shot;

    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(Random.Range(3, 7)));
            var shooter = new GigantEnemyShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 0.9f, Distance: 3, Shot: Shot);
            shooter.SetDirection((GetNearestHelpPoint().transform.position - transform.position).normalized);
            shooter.Go();
        }
    }

    protected override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            Smaller();
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(1.5f));
            Bigger();
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(1.5f));
            MoveToHelpPoint();
        }
    }

    void Bigger()
    {
        var seq = DOTween.Sequence();
        seq.Append(transform.DOScale(2, CalcTime(1f)).SetEase(Ease.InQuad));
        seq.Play();
    }

    void Smaller()
    {
        var seq = DOTween.Sequence();
        seq.Append(transform.DOScale(0.2f, CalcTime(1f)).SetEase(Ease.OutQuad));
        seq.Play();
    }


    void MoveToHelpPoint()
    {
        Sequence seq = DOTween.Sequence();
        GameObject nearestHelpPoint = GetNearestHelpPoint();
        if ((nearestHelpPoint.transform.position - transform.position).magnitude <= 2) { return; }
        Vector3 moveDirection = (nearestHelpPoint.transform.position - transform.position).normalized;
        float Length = Mathf.Min((nearestHelpPoint.transform.position - transform.position).magnitude - 2, 0.33f);
        seq.Append(transform.DOMove(moveDirection * Length, CalcTime(3)).SetRelative(true));
        seq.Play();
    }


    GameObject GetNearestHelpPoint()
    {
        var helpPoints = GameObject.FindGameObjectsWithTag("HelpPoint");
        return helpPoints.MinBy(x => (x.transform.position - transform.position).sqrMagnitude).First();
    }
}
