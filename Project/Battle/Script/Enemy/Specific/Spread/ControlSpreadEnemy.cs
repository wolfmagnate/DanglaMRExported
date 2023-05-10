using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static LoopUtil;

public class ControlSpreadEnemy : ControlEnemy
{
    public GameObject Shot;

    protected override IEnumerator MoveCoroutine()
    {
        // 上下移動をしながら、回転移動をする
        while (true)
        {
            Circle();
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(5));
        }
    }

    private void Circle()
    {
        var seq = DOTween.Sequence();
        float now = 0.0f;
        seq.Append(DOTween.To(x => RotateAround(x), 0, (Random.Range(0,2) * 2 - 1) * 36, CalcTime(5)).SetEase(Ease.Linear));
        void RotateAround(float x)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(Player.transform.position, axis, x - now);
            // プレイヤーの方向へ移動
            if ((Player.transform.position - transform.position).magnitude > 3)
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
            yield return new WaitForSeconds(CalcTime(Random.Range(3, 7)));
            5.Times(() =>
            {
                var shooter = new SpreadEnemyShooter();
                shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 0.3f, Distance: 4, Shot);
                shooter.SetDirection(GetRandomVector(transform.forward));
                shooter.Go();
            });
        }
    }

    Vector3 GetRandomVector(Vector3 forward)
        => Quaternion.Euler(Random.Range(-40, 40), Random.Range(-40, 40), Random.Range(-40, 40)) * forward;

}

