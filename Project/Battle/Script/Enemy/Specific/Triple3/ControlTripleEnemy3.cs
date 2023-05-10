using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class ControlTripleEnemy3 : ControlEnemy
{
    public GameObject Shot;

    private GameObject Boss;

    public void SetBoss(GameObject boss)
    {
        Boss = boss;
        transform.parent = boss.transform;
    }

    protected override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            Circle();
            yield return new WaitForSeconds(2.5f);
        }
    }

    void Circle()
    {
        var seq = DOTween.Sequence();
        float now = 0.0f;
        seq.Append(DOTween.To(x => RotateAround(x), 0, -360, CalcTime(2.5f)).SetEase(Ease.Linear));
        void RotateAround(float x)
        {
            Vector3 axis = Boss.transform.forward;
            transform.RotateAround(Boss.transform.position, axis, x - now);
            now = x;
        }
        seq.Play();
    }


    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(Random.Range(3, 7)));
            var shooter = new TripleEnemy3Shooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 0.3f, Distance: 3, Shot);
            shooter.SetDirection(transform.forward);
            shooter.Go();
        }
    }

    protected override void Update()
    {
        transform.LookAt(GetNearestHelpPoint().transform);
    }

    GameObject GetNearestHelpPoint()
    {
        var helpPoints = GameObject.FindGameObjectsWithTag("HelpPoint");
        return helpPoints.MinBy(x => (x.transform.position - transform.position).sqrMagnitude).First();
    }
}
