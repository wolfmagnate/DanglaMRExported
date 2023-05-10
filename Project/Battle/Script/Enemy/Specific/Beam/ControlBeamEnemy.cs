using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static LoopUtil;

public class ControlBeamEnemy : ControlEnemy
{
    public GameObject Shot;
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
                    Circle();
                    break;
            }
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(Random.Range(3, 7)));
        }
    }

    private void BackAndForce()
    {
        var sequence = DOTween.Sequence();
        if((Player.transform.position - transform.position).magnitude > 3)
        {
            sequence.Append(transform.DOMove(transform.forward + (Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
            sequence.Append(transform.DOMove(-transform.forward + (Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
        }
        else if ((Player.transform.position - transform.position).magnitude < 1)
        {
            sequence.Append(transform.DOMove(transform.forward + -(Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
            sequence.Append(transform.DOMove(-transform.forward + -(Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
        }
        else
        {
            sequence.Append(transform.DOMove(transform.forward, CalcTime(2.5f)).SetRelative(true));
            sequence.Append(transform.DOMove(-transform.forward, CalcTime(2.5f)).SetRelative(true));
        }
        sequence.Play();
    }

    private void Circle()
    {
        var seq = DOTween.Sequence();
        float now = 0.0f;
        seq.Append(DOTween.To(x => RotateAround(x), 0, Random.Range(-60,-40), CalcTime(5)));
        void RotateAround(float x)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(Player.transform.position, axis, x - now);
            // ƒvƒŒƒCƒ„[‚Ì•ûŒü‚ÖˆÚ“®
            if((Player.transform.position - transform.position).magnitude > 3)
            {
                transform.Translate((Player.transform.position - transform.position).normalized * 0.005f);
            }
            if ((Player.transform.position - transform.position).magnitude < 2)
            {
                transform.Translate(-(Player.transform.position - transform.position).normalized * 0.005f);
            }
            now = x;
        }
        seq.Play();
    }


    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(1));
            3.Times(()=>
            {
                var shooter = new BeamEnemyShooter();
                shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 0.3f, Distance: 3, Shot);
                shooter.SetDirection(GetRandomVector(transform.forward));
                shooter.Go();
            });
        }
    }

    Vector3 GetRandomVector(Vector3 forward)
        => Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180)) * forward;
}
