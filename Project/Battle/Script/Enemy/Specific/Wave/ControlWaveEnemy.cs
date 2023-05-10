using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ControlWaveEnemy : ControlEnemy
{
    [SerializeField]
    public GameObject Shot;

    protected override IEnumerator MoveCoroutine()
    {
        float baseY = transform.position.y;
        // 公転ベクトルのy座標をsinで変えたらOK
        while (true)
        {
            Circle(baseY);
            if (transform.position.y < 0) { baseY = 1; }
            if (transform.position.y > 0) { baseY = -1; }
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(5));
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
            transform.RotateAround(Player.transform.position, axis, (x - now) / 60f);
            transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Cos(Mathf.Deg2Rad * x) * 0.01f + BaseY * 0.001f, transform.position.z);
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
            yield return new WaitForSeconds(CalcTime(4));
            var shooter = new WaveEnemyShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 0.3f, Distance: 4, Shot);
            shooter.SetDirection((transform.forward));
            shooter.Go();
        }
    }


}
