using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNormalEnemyD : ControlEnemy
{
    public GameObject[] Shots;

    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(0.5f));
            if ((Player.transform.position - transform.position).magnitude > 6) { continue; }
            var shooter = new NormalEnemyDShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 0.5f, Distance: 6, Shot: Shots.GetRandomElement());
            shooter.SetDirection(GetRandomVector(transform.forward));
            shooter.Go();
        }
    }

    protected override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            if ((Player.transform.position - transform.position).magnitude > 3)
            {
                BackAndForceFar();
            }
            else
            {
                BackAndForce();
            }
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(3));
        }
    }

    protected override void Update() { }

    private void BackAndForce()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.forward * 0.5f, CalcTime(1.5f)).SetRelative(true));
        sequence.Join(transform.DORotate(new Vector3(720, 720, 720), CalcTime(1.5f), RotateMode.FastBeyond360)).SetEase(Ease.Linear);
        sequence.Append(transform.DOMove(-transform.forward * 0.5f, CalcTime(1.5f)).SetRelative(true));
        sequence.Join(transform.DORotate(new Vector3(720, 720, 720), CalcTime(1.5f), RotateMode.FastBeyond360)).SetEase(Ease.Linear);
        sequence.Play();
    }

    private void BackAndForceFar()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.forward * 0.5f + (Player.transform.position - transform.position).normalized * 0.5f, CalcTime(1.5f)).SetRelative(true));
        sequence.Join(transform.DORotate(new Vector3(720, 720, 720), CalcTime(1.5f), RotateMode.FastBeyond360)).SetEase(Ease.Linear);
        sequence.Append(transform.DOMove(-transform.forward * 0.5f + (Player.transform.position - transform.position).normalized * 0.5f, CalcTime(1.5f)).SetRelative(true));
        sequence.Join(transform.DORotate(new Vector3(720, 720, 720), CalcTime(1.5f), RotateMode.FastBeyond360)).SetEase(Ease.Linear);
        sequence.Play();
    }

    Vector3 GetRandomVector(Vector3 forward)
        => Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180)) * forward;
}
