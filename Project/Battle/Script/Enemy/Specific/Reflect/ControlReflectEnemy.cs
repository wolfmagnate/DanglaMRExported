using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlReflectEnemy : ControlEnemy
{
    public GameObject Shot;
    public GameObject Effect;
    ReflectEnemyStatus status;
    protected override void StartMethod()
    {
        status = GetComponent<ReflectEnemyStatus>();
    }

    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(3));
            var Normalshot = new ReflectEnemyShooter();
            Normalshot.CreateShot(transform.position, transform.rotation, CalcAttack(Attack), Speed: 0.3f, Distance: 4, Shot);
            Normalshot.SetDirection((Player.transform.position - transform.position).normalized);
            Normalshot.Go();
            bool HasShot = false;
            status.AddListenerToOnDamage(() => {
                if (HasShot) { return; }
                for (int i = 0;i < 8; i++)
                {
                    var shot = new ReflectEnemyShooter();
                    shot.CreateShot(transform.position, transform.rotation, CalcAttack(Attack), Speed: 0.5f, Distance: 4, Shot);
                    shot.SetDirection(Quaternion.Euler(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20)) * (Player.transform.position - transform.position).normalized);
                    shot.Go();
                }
                HasShot = true;
            });
            var effect = Instantiate(Effect, transform.position, Quaternion.identity);
            effect.transform.parent = transform;
            Destroy(effect, CalcTime(3f));
            yield return new WaitForSeconds(CalcTime(3f));
            status.RemoveListenerToOnDamate();
        }
    }

    protected override IEnumerator MoveCoroutine()
    {
        // 上下移動をしながら、回転移動をする
        while (true)
        {
            if ((Player.transform.position - transform.position).magnitude > 3)
            {
                JumpCircleFar();
            }
            else if ((Player.transform.position - transform.position).magnitude < 1)
            {
                JumpCircleNear();
            }
            else
            {
                JumpCircle();
            }
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(6));
        }
    }

    private void JumpCircle()
    {
        // ジャンプ先の座標決定
        Vector3 targetPosition = Quaternion.Euler(new Vector3(0, Random.Range(20, 40), 0)) * (transform.position - Player.transform.position) + Player.transform.position;
        transform.DOJump(targetPosition, 1, 2, CalcTime(4));
    }

    private void JumpCircleFar()
    {
        // ジャンプ先の座標決定
        float distance = (transform.position - Player.transform.position).magnitude;
        Vector3 targetPosition = (distance - 0.4f) * (Quaternion.Euler(new Vector3(0, Random.Range(20, 40), 0)) * (transform.position - Player.transform.position).normalized) + Player.transform.position;
        transform.DOJump(targetPosition, 2, 2, CalcTime(4));
    }

    private void JumpCircleNear()
    {
        // ジャンプ先の座標決定
        float distance = (transform.position - Player.transform.position).magnitude;
        Vector3 targetPosition = (distance + 0.4f) * (Quaternion.Euler(new Vector3(0, Random.Range(20, 40), 0)) * (transform.position - Player.transform.position).normalized) + Player.transform.position;
        transform.DOJump(targetPosition, 1, 2, CalcTime(4));
    }
}
