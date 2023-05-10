using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ControlHoppingEnemy : ControlEnemy
{
    public GameObject Shot;

    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(Random.Range(3, 7)));
            var shooter = new HoppingEnemyShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 0.9f, Distance: 3, Shot: Shot);
            shooter.SetDirection((GetNearestHelpPoint().transform.position - transform.position).normalized);
            shooter.Go();
        }
    }


    GameObject GetNearestHelpPoint()
    {
        var helpPoints = GameObject.FindGameObjectsWithTag("HelpPoint");
        return helpPoints.MinBy(x => (x.transform.position - transform.position).sqrMagnitude).First();
    }

    protected override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            Hop();
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(1));
        }
    }

    void Hop()
    {
        var seq = DOTween.Sequence();
        seq.Append(transform.DOJump(transform.position + MoveToHelpPoint(), 1, 1, CalcTime(1)).SetEase(Ease.Linear));
        seq.Play();
    }


    Vector3 MoveToHelpPoint()
    {
        
        GameObject nearestHelpPoint = GetNearestHelpPoint();
        if ((nearestHelpPoint.transform.position - transform.position).magnitude <= 3) { return Vector3.zero; }
        Vector3 moveDirection = (nearestHelpPoint.transform.position - transform.position).normalized;
        float Length = Mathf.Min((nearestHelpPoint.transform.position - transform.position).magnitude - 3, 0.33f);
        return moveDirection * Length;
    }
}
