using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControlSummonEnemy : ControlEnemy
{
    public GameObject[] Summonee;
    public GameObject Effect;

    protected override IEnumerator AttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(CalcTime(Random.Range(6,9)));
            Instantiate(Summonee.GetRandomElement(), transform.position, transform.rotation);
            var effect = Instantiate(Effect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
        }
    }

    protected override IEnumerator MoveCoroutine()
    {
        // ã‰ºˆÚ“®‚ð‚µ‚È‚ª‚çA‰ñ“]ˆÚ“®‚ð‚·‚é
        while (true)
        {
            Rotate();
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(2));
        }
    }


    GameObject GetNearestHelpPoint()
    {
        var helpPoints = GameObject.FindGameObjectsWithTag("HelpPoint");
        return helpPoints.MinBy(x => (x.transform.position - transform.position).sqrMagnitude).First();
    }

    void Rotate()
    {
        var seq = DOTween.Sequence();
        seq.Append(transform.DoRotateAround(10, CalcTime(1), GetNearestHelpPoint().transform.position).SetRelative(true));
        seq.Append(transform.DOMove((GetNearestHelpPoint().transform.position - transform.position).normalized, CalcTime(1)).SetRelative(true));
        seq.Play();
    }
}
