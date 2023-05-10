using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ControlSphereEnemy : ControlEnemy
{
    public GameObject Shot;

    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 1).SetEase(Ease.InBounce);
            yield return new WaitForSeconds(CalcTime(5));
            // ためエフェクト(体のサイズが膨れる+効果音)
            transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1).SetEase(Ease.InBounce);
            yield return new WaitForSeconds(1);
            // ダメージエリア作成
            var shooter = new SphereEnemyShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 0f, Distance: 3, Shot: Shot);
            shooter.SetDirection(transform.forward);
            shooter.Go();
            // 体がしぼむ
            transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 1).SetEase(Ease.InBounce);
        }
    }

    protected override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            if ((Player.transform.position - transform.position).magnitude > 2)
            {
                switch (Random.Range(0, 3))
                {
                    case 0:
                        BackAndForceFar();
                        break;
                    case 1:
                        CircleFar();
                        break;
                }
            }
            else
            {
                switch (Random.Range(0, 3))
                {
                    case 0:
                        BackAndForce();
                        break;
                    case 1:
                        Circle();
                        break;
                }
            }
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(5));
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
        seq.Append(DOTween.To(x => RotateAround(x), 0, Random.Range(-40, 40), CalcTime(5)));
        void RotateAround(float x)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(Player.transform.position, axis, x - now);
            now = x;
        }
        seq.Play();
    }

    private void BackAndForceFar()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.forward + (Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Append(transform.DOMove(-transform.forward + (Player.transform.position - transform.position).normalized * 0.5f, CalcTime(2.5f)).SetRelative(true));
        sequence.Play();
    }

    private void CircleFar()
    {
        var seq = DOTween.Sequence();
        float now = 0.0f;
        seq.Append(DOTween.To(x => RotateAround(x), 0, Random.Range(-40, 40), CalcTime(2.5f)));
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
