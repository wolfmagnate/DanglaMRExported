using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNormalEnemyB : ControlEnemy
{
    public GameObject Shot;

    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(Random.Range(3, 7)));
            if ((Player.transform.position - transform.position).magnitude > 4) { continue; }
            var shooter = new NormalEnemyBShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 0.3f, Distance: 3, Shot: Shot);
            shooter.SetDirection(transform.forward);
            shooter.Go();
        }
    }

    protected override IEnumerator MoveCoroutine()
    {
        // ã‰ºˆÚ“®‚ð‚µ‚È‚ª‚çA‰ñ“]ˆÚ“®‚ð‚·‚é
        while (true)
        {
            if ((Player.transform.position - transform.position).magnitude > 2)
            {
                CircleFar();
                AvoidGoingTooFarFromPlayer();
                yield return new WaitForSeconds(CalcTime(5));
            }
            else
            {
                Circle();
                AvoidGoingTooFarFromPlayer();
                yield return new WaitForSeconds(CalcTime(5));
            }
        }
    }

    private void Circle()
    {
        var seq = DOTween.Sequence();
        float now = 0.0f;
        seq.Append(DOTween.To(x => RotateAround(x), 0, 30, CalcTime(5)).SetEase(Ease.InCirc));
        void RotateAround(float x)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(Player.transform.position, axis, x - now);
            now = x;
        }
        seq.Play();
    }

    private void CircleFar()
    {
        var seq = DOTween.Sequence();
        float now = 0.0f;
        seq.Append(DOTween.To(x => RotateAround(x), 0, 15, CalcTime(2.5f)).SetEase(Ease.InCirc));
        seq.Append(transform.DOMove((Player.transform.position - transform.position).normalized, CalcTime(2.5f)).SetRelative(true));
        void RotateAround(float x)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(Player.transform.position, axis, x - now);
            now = x;
        }
        seq.Play();
    }
}
