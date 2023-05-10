using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControlGatlingEnemy : ControlEnemy
{
    public GameObject Shot;
    public GameObject Effect;
    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(5));
            if ((GetNearestHelpPoint().transform.position - transform.position).magnitude > 4) { continue; }
            // ‚½‚ß
            // ƒKƒgƒŠƒ“ƒO‚Ì‘_‚¢‚ð’è‚ß‚é
            Vector3 playerDirection = (GetNearestHelpPoint().transform.position - transform.position).normalized;
            var effect = Instantiate(Effect, transform.position, Quaternion.identity);
            Destroy(effect, 3);
            yield return new WaitForSeconds(3f);
            for(int i = 0;i < 5;i++)
            {
                var shooter = new GatlingEnemyShooter();
                shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 0.9f, Distance: 4, Shot: Shot);
                shooter.SetDirection(playerDirection);
                shooter.Go();
                yield return new WaitForSeconds(0.3f);
            }
        }
    }

    protected override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            switch((GetNearestHelpPoint().transform.position - transform.position).magnitude)
            {
                case float distance when distance > 3:
                    RapidFar();
                    yield return new WaitForSeconds(CalcTime(2));
                    SlowFar();
                    yield return new WaitForSeconds(CalcTime(2));
                    break;
                case float distance when distance <= 3 && distance > 2:
                    Rapid();
                    yield return new WaitForSeconds(CalcTime(2));
                    Slow();
                    yield return new WaitForSeconds(CalcTime(2));
                    break;
                case float distance when distance <= 2:
                    RapidNear();
                    yield return new WaitForSeconds(CalcTime(2));
                    SlowNear();
                    yield return new WaitForSeconds(CalcTime(2));
                    break;
            }
            AvoidGoingTooFarFromPlayer();
        }
    }

    Vector3 GetRandomVector()
    {
        return Quaternion.Euler(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360)) * Vector3.one;
    }

    void Rapid()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOMove(GetRandomVector(), CalcTime(2)).SetRelative(true));
        seq.Play();
    }

    void Slow()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOMove(GetRandomVector() * 0.5f, CalcTime(2)).SetRelative(true));
        seq.Play();
    }
    void RapidFar()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOMove((GetNearestHelpPoint().transform.position - transform.position).normalized, CalcTime(2)).SetRelative(true));
        seq.Play();
    }

    void SlowFar()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOMove((GetNearestHelpPoint().transform.position - transform.position).normalized * 0.5f, CalcTime(2)).SetRelative(true));
        seq.Play();
    }
    void RapidNear()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOMove(-(GetNearestHelpPoint().transform.position - transform.position).normalized, CalcTime(2)).SetRelative(true));
        seq.Play();
    }

    void SlowNear()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOMove(-(GetNearestHelpPoint().transform.position - transform.position).normalized * 0.5f, CalcTime(2)).SetRelative(true));
        seq.Play();
    }

    GameObject GetNearestHelpPoint()
    {
        var helpPoints = GameObject.FindGameObjectsWithTag("HelpPoint");
        return helpPoints.MinBy(x => (x.transform.position - transform.position).sqrMagnitude).First();
    }

}
