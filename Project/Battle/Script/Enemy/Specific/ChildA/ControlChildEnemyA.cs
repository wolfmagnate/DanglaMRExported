using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ControlChildEnemyA : ControlEnemy
{
    public GameObject Shot;
    protected override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    BackAndForce();
                    break;
                case 1:
                    Circle();
                    break;
                case 2:
                    UpAndDown();
                    break;
            }
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(Random.Range(3, 7)));
        }
    }

    private void BackAndForce()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.forward, CalcTime(2.5f)).SetRelative(true));
        sequence.Append(transform.DOMove(-transform.forward, CalcTime(2.5f)).SetRelative(true));
        sequence.Play();
    }

    private void Circle()
    {
        var seq = DOTween.Sequence();
        float now = 0.0f;
        seq.Append(DOTween.To(x => RotateAround(x), 0, Random.Range(-60, 60), CalcTime(5)));
        void RotateAround(float x)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(Player.transform.position, axis, x - now);
            now = x;
        }
        seq.Play();
    }

    private void UpAndDown()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.up * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Append(transform.DOMove(-transform.up * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Play();
    }

    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(Random.Range(3, 7)));
            var shooter = new ChildEnemyAShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 0.3f, Distance: 3, Shot);
            shooter.SetDirection(transform.forward);
            shooter.Go();
        }
    }
}
