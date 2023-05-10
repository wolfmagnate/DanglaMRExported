using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereEnemyShot : EnemyAttackShot
{
    public GameObject Effect;
    protected override void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerStatus>().Damage(Attack);
        var effect = GameObject.Instantiate(Effect, other.gameObject.transform.position + other.gameObject.transform.forward * 0.25f, Quaternion.identity);
        effect.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Destroy(effect, 0.5f);
    }

    protected void OnTriggerStay(Collider other)
    {
        OnTriggerEnter(other);
    }


    protected override IEnumerator Die()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
