using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackShot : MonoBehaviour
{
    public abstract void SetDirection(Vector3 direction);

    public abstract void Init(float attack,float speed,int canHitTimes,float distance,float range,MagicAttribute attribute, List<BadStatus> badStatuses, List<float> possiblities, GameObject effect, GameObject hitEffect);
    public abstract void Go();

    public abstract void SetRandom();

    protected virtual void GenerateEffect()
    {
        Effect = Instantiate(Effect);
        Effect.transform.parent = transform;
        Effect.transform.localPosition = Vector3.zero;
        Effect.transform.localScale = new Vector3(1,1,1);
    }
    protected virtual void GenerateHitEffect()
    {
        HitEffect = Instantiate(HitEffect);
        HitEffect.transform.position = transform.position;
        HitEffect.transform.rotation = Quaternion.Euler(Vector3.zero);
        HitEffect.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
        Destroy(HitEffect, 3);
    }

    protected virtual void DestroyEffect()
    {
        Destroy(Effect);
        KillEffectGameObject(HitEffect);
    }

    protected void KillEffectGameObject(GameObject obj)
    {
        StartCoroutine(Kill(obj));
    }

    IEnumerator Kill(GameObject obj)
    {
        yield return new WaitForSeconds(10);
        Destroy(obj);
    }

    protected GameObject HitEffect;
    protected GameObject Effect;
    protected float Range;
}
