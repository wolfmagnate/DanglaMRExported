using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class ControlEnemy : MonoBehaviour
{
    IEnumerator move;
    IEnumerator attack;
    public float Attack;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        move = MoveCoroutine();
        StartCoroutine(move);
        attack = AttackCoroutine();
        StartCoroutine(attack);
        StartMethod();
    }

    protected virtual void StartMethod() { }

    protected GameObject Player;
    protected virtual void Update()
    {
        transform.LookAt(Player.transform);
        UpdateMethod();
    }

    protected virtual void UpdateMethod() { }

    protected abstract IEnumerator MoveCoroutine();
    protected abstract IEnumerator AttackCoroutine();


    public void Freeze()
    {
        StopCoroutine(move);
        StopCoroutine(attack);
    }

    public void Unfreeze()
    {
        StartCoroutine(move);
        StartCoroutine(attack);
    }

    protected float paralyze = 1; 
    public void Paralyze()
    {
        paralyze = 0.5f;
    }

    public void Unparalyze()
    {
        paralyze = 1;
    }

    protected float burn = 1;
    public void Burn()
    {
        burn = 0.5f;
    }

    public void Unburn()
    {
        burn = 1;
    }

    protected virtual float CalcTime(float time)
    {
        return time / paralyze;
    }

    protected virtual float CalcAttack(float attack)
    {
        return attack * burn;
    }


    protected void AvoidGoingTooFarFromPlayer()
    {
        if ((Player.transform.position - transform.position).magnitude > 10)
        {
            transform.Translate((Player.transform.position - transform.position).normalized * ((Player.transform.position - transform.position).magnitude - 10));
        }
    }
}
