using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControlBossStage10Factory : ControlEnemy
{
    public GameObject[] Summonee;
    public GameObject Effect;

    protected override IEnumerator AttackCoroutine()
    {
        for(int i = 0;i < 4;i++)
        {
            yield return new WaitForSeconds(CalcTime(7));
            Instantiate(Summonee.GetRandomElement(), transform.position, transform.rotation);
            var effect = Instantiate(Effect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
        }
        Destroy(gameObject);
    }

    protected override IEnumerator MoveCoroutine()
    {
        // ã‰ºˆÚ“®‚ð‚µ‚È‚ª‚çA‰ñ“]ˆÚ“®‚ð‚·‚é
        while (true)
        {
            Rotate();
            AvoidGoingTooFarFromPlayer();
            yield return new WaitForSeconds(CalcTime(4));
        }
    }

    void Rotate()
    {
        var seq = DOTween.Sequence();
        seq.Append(transform.DoRotateAround(10, CalcTime(1), Player.transform.position).SetRelative(true));
        if((Player.transform.position - transform.position).magnitude > 2)
        {
            seq.Append(transform.DOMove((Player.transform.position - transform.position).normalized, CalcTime(1)).SetRelative(true));
        }
        else
        {
            seq.Append(transform.DoRotateAround(10, CalcTime(1), Player.transform.position).SetRelative(true));
        }
        seq.Play();
    }
}
