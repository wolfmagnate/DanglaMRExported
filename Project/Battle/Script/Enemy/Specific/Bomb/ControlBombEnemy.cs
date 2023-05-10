using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class ControlBombEnemy : ControlEnemy
{
    public GameObject Shot;
    protected override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            Circle();
            yield return new WaitForSeconds(CalcTime(2));
            AvoidGoingTooFarFromPlayer();
        }
    }
    private void Circle()
    {
        var seq = DOTween.Sequence();
        float now = 0.0f;
        seq.Append(DOTween.To(x => RotateAround(x), 0, Random.Range(-10, 10), CalcTime(1)).SetEase(Ease.OutBounce).OnComplete(()=> { now = 0; }));
        seq.Append(transform.DOMove(MoveToHelpPoint(),CalcTime(1)).SetRelative(true).SetEase(Ease.OutBounce));
        
        void RotateAround(float x)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(Player.transform.position, axis, x - now);
            now = x;
        }
        seq.Play();
    }

    GameObject GetNearestHelpPoint()
    {
        var helpPoints = GameObject.FindGameObjectsWithTag("HelpPoint");
        return helpPoints.MinBy(x => (x.transform.position - transform.position).sqrMagnitude).First();
    }


    Vector3 MoveToHelpPoint()
    {

        GameObject nearestHelpPoint = GetNearestHelpPoint();
        if ((nearestHelpPoint.transform.position - transform.position).magnitude <= 3) { return Vector3.zero; }
        Vector3 moveDirection = (nearestHelpPoint.transform.position - transform.position).normalized;
        float Length = Mathf.Min((nearestHelpPoint.transform.position - transform.position).magnitude - 3, 0.33f);
        return moveDirection * Length;
    }

    EnemyStatusController status;
    protected override IEnumerator AttackCoroutine()
    {
        StartCoroutine(BombCoroutine());
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(Random.Range(3, 7)));
            var shooter = new BombEnemyShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack) * 2, Speed: 0.3f, Distance: 3, Shot);
            shooter.SetDirection((GetNearestHelpPoint().transform.position - transform.position).normalized);
            shooter.Go();
        }
    }

    IEnumerator BombCoroutine()
    {
        status = GetComponent<EnemyStatusController>();
        float prevHP = status.HP;
        float maxHP = status.HP;
        while (true)
        {
            // HP‚Ì‘Œ¸‚É‚æ‚è©•ª‚Ì‘å‚«‚³‚ğ•Ï‰»‚³‚¹‚é
            float diff = status.HP - prevHP;
            if (diff < 0)
            {
                // diff‚ªHP‚Ì50%‚Å·•ª‚ª1‚ğ’´‚¦‚é‚æ‚¤‚Éİ’è‚·‚é
                transform.localScale += -diff / maxHP * 2 * Vector3.one;
            }

            if (transform.localScale.x > 1)
            {
                transform.localScale -= 0.03f * Vector3.one;
            }

            if (transform.localScale.x > 2f)
            {
                StartCoroutine(Explode());
            }

            prevHP = status.HP;
            yield return null;
        }
    }

    public GameObject Effect;
    IEnumerator Explode()
    {
        Destroy(Instantiate(Effect), 3);
        3.Times(() => {
            var shooter = new BombEnemyShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 2f, Distance: 3, Shot: Shot);
            shooter.SetDirection(GetRandomVector(transform.forward));
            shooter.Go();
        });
        yield return new WaitForSeconds(0.3f);
        3.Times(() => {
            var shooter = new BombEnemyShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 2f, Distance: 3, Shot: Shot);
            shooter.SetDirection(GetRandomVector(transform.forward));
            shooter.Go();
        });
        yield return new WaitForSeconds(0.3f);
        3.Times(() => {
            var shooter = new BombEnemyShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 2f, Distance: 3, Shot: Shot);
            shooter.SetDirection(GetRandomVector(transform.forward));
            shooter.Go();
        });
        GameObject.Destroy(gameObject);
    }


    Vector3 GetRandomVector(Vector3 forward)
        => Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180)) * forward;
}
