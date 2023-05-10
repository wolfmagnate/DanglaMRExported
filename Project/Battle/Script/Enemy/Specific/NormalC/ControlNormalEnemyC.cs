using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ControlNormalEnemyC : ControlEnemy
{
    public GameObject Shot;

    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(Random.Range(3, 7)));
            if ((Player.transform.position - transform.position).magnitude > 4) { continue; }
            var shooter = new NormalEnemyCShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 0.3f, Distance: 3, Shot: Shot);
            shooter.SetDirection(transform.forward);
            shooter.Go();
        }
    }

    protected override IEnumerator MoveCoroutine()
    {
        float baseY = transform.position.y;
        // 公転ベクトルのy座標をsinで変えたらOK
        while (true)
        {
            if((Player.transform.position - transform.position).magnitude > 2)
            {
                CircleFar(baseY);
                if (transform.position.y < 0) { baseY = 1; }
                if (transform.position.y > 0) { baseY = -1; }
                AvoidGoingTooFarFromPlayer();
                yield return new WaitForSeconds(CalcTime(5));
            }
            else
            {
                Circle(baseY);
                if (transform.position.y < 0) { baseY = 1; }
                if (transform.position.y > 0) { baseY = -1; }
                AvoidGoingTooFarFromPlayer();
                yield return new WaitForSeconds(CalcTime(5));
            }
        }
    }

    private void Circle(float BaseY)
    {
        var seq = DOTween.Sequence();
        float now = 0.0f;
        seq.Append(DOTween.To(x => RotateAround(x), 0, 360, CalcTime(5)).SetEase(Ease.Linear));
        void RotateAround(float x)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(Player.transform.position, axis, (x - now)/60f);
            transform.position = new Vector3(transform.position.x ,transform.position.y + Mathf.Cos(Mathf.Deg2Rad*x) * 0.01f + BaseY * 0.001f,transform.position.z);
            now = x;
        }
        seq.Play();
    }

    private void CircleFar(float BaseY)
    {
        var seq = DOTween.Sequence();
        float now = 0.0f;
        seq.Append(DOTween.To(x => RotateAround(x), 0, 360, CalcTime(2.5f)).SetEase(Ease.Linear));
        seq.Append(transform.DOMove((Player.transform.position - transform.position).normalized, CalcTime(2.5f)).SetRelative(true));
        void RotateAround(float x)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(Player.transform.position, axis, (x - now) / 60f);
            transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Cos(Mathf.Deg2Rad * x) * 0.01f + BaseY * 0.001f, transform.position.z);
            now = x;
        }
        seq.Play();
    }
}

