using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class ControlTripleEnemy1 : ControlEnemy
{
    public GameObject Shot;
    public GameObject FrinedEnemy1;
    public GameObject FrinedEnemy2;
    protected override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    BackAndForce();
                    break;
                case 1:
                    UpAndDown();
                    break;
            }
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(Random.Range(3, 7)));
        }
    }

    new void Start()
    {
        base.Start();
        var one = Instantiate(FrinedEnemy1);
        var two = Instantiate(FrinedEnemy2);
        one.transform.position = transform.position + transform.right * 0.8f;
        two.transform.position = transform.position + transform.right * (-0.8f);
        one.GetComponent<ControlTripleEnemy2>().SetBoss(gameObject);
        two.GetComponent<ControlTripleEnemy3>().SetBoss(gameObject);
    }

    private void BackAndForce()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.forward + MoveToHelpPoint(), CalcTime(2.5f)).SetRelative(true));
        sequence.Append(transform.DOMove(-transform.forward + MoveToHelpPoint(), CalcTime(2.5f)).SetRelative(true));
        sequence.Play();
    }

    private void UpAndDown()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.up * 0.5f + MoveToHelpPoint(), CalcTime(2.5f)).SetRelative(true));
        sequence.Append(transform.DOMove(-transform.up * 0.5f + MoveToHelpPoint(), CalcTime(2.5f)).SetRelative(true));
        sequence.Play();
    }

    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(Random.Range(3, 7)));
            var shooter = new TripleEnemy1Shooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 0.3f, Distance: 3, Shot);
            shooter.SetDirection((GetNearestHelpPoint().transform.position - transform.position).normalized);
            shooter.Go();
        }
    }


    GameObject GetNearestHelpPoint()
    {
        var helpPoints = GameObject.FindGameObjectsWithTag("HelpPoint");
        return helpPoints.MinBy(x => (x.transform.position - transform.position).sqrMagnitude).First();
    }


    Vector3 MoveToHelpPoint()
    {

        GameObject nearestHelpPoint = GetNearestHelpPoint();
        if ((nearestHelpPoint.transform.position - transform.position).magnitude <= 2) { return Vector3.zero; }
        Vector3 moveDirection = (nearestHelpPoint.transform.position - transform.position).normalized;
        float Length = Mathf.Min((nearestHelpPoint.transform.position - transform.position).magnitude - 2, 0.33f);
        if ((nearestHelpPoint.transform.position - transform.position).magnitude >= 10) { Length = 3; }
        return moveDirection * Length;
    }
}
