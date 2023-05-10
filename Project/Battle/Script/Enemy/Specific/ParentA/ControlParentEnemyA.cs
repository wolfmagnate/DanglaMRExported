using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class ControlParentEnemyA : ControlEnemy
{
    public GameObject Shot;
    public GameObject Child;

    protected override void Update()
    {
        transform.LookAt(GetNearestHelpPoint().transform.position);
    }

    private new void Start()
    {
        base.Start();
        gameObject.GetComponent<EnemyStatusController>().OnDie.AddListener(GenerateChild);
        
        void GenerateChild()
        {
            var child = GameObject.Instantiate(Child);
            child.transform.position = transform.position;
        }
    }

    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(Random.Range(3, 7)));
            var shooter = new ParentEnemyAShooter();
            shooter.CreateShot(transform.position, transform.rotation, Attack: CalcAttack(Attack), Speed: 0.9f, Distance: 3, Shot: Shot);
            shooter.SetDirection(transform.forward);
            shooter.Go();
        }
    }

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
        sequence.Append(transform.DOMove(transform.forward + MoveToHelpPoint(), CalcTime(2.5f)).SetRelative(true));
        sequence.Append(transform.DOMove(-transform.forward + MoveToHelpPoint(), CalcTime(2.5f)).SetRelative(true));
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
            transform.position = transform.position + MoveToHelpPoint() / 25;
            now = x;
        }
        seq.Play();
    }

    private void UpAndDown()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.up * 0.5f + MoveToHelpPoint(), CalcTime(2.5f)).SetRelative(true));
        sequence.Append(transform.DOMove(-transform.up * 0.5f + MoveToHelpPoint(), CalcTime(2.5f)).SetRelative(true));
        sequence.Play();
    }


    GameObject GetNearestHelpPoint()
    {
        var helpPoints = GameObject.FindGameObjectsWithTag("HelpPoint");
        return helpPoints.MinBy(x => (x.transform.position - transform.position).sqrMagnitude).First();
    }


    Vector3 MoveToHelpPoint()
    {
        GameObject nearestHelpPoint = GetNearestHelpPoint();
        if ((nearestHelpPoint.transform.position - transform.position).magnitude <= 2) { return Vector3.zero; }
        Vector3 moveDirection = (nearestHelpPoint.transform.position - transform.position).normalized;
        float Length = Mathf.Min((nearestHelpPoint.transform.position - transform.position).magnitude - 2, 0.33f);
        return moveDirection * Length;
    }
}
