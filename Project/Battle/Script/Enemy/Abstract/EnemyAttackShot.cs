using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttackShot: MonoBehaviour
{

    protected virtual void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerStatus>().Damage(Attack);
        Destroy(gameObject);
    }

    protected Vector3 startPosition;

    public virtual void Go()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward * Speed;
        startPosition = gameObject.transform.position;
    }

    protected virtual IEnumerator Die()
    {
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }

    protected virtual void Start()
    {
        StartCoroutine(Die());
    }

    protected virtual void Update()
    {
        if((startPosition - transform.position).magnitude > Distance) { Destroy(gameObject); }
    }

    public float Attack;
    public float Speed;
    public float Distance;
}
