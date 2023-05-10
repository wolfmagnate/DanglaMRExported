using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStatusController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            OnDie.Invoke();
            Destroy(gameObject);
        }
        HP -= poisoned;
        UpdateMethod();
    }

    protected virtual void UpdateMethod() { }
    public float HP;
    public EnemyResistance resistance;
    public UnityEvent OnDie;

    public virtual void Damage(float attack, MagicAttribute attribute)
    {
        float amount = broken * attack * attribute switch
        {
            MagicAttribute.Darkness => resistance.Darkness, 
            MagicAttribute.Fire => resistance.Fire,
            MagicAttribute.Ice => resistance.Ice,
            MagicAttribute.Light => resistance.Light,
            MagicAttribute.Lightning => resistance.Lightning,
            MagicAttribute.Metal => resistance.Metal,
            MagicAttribute.Mountain => resistance.Mountain,
            MagicAttribute.Tree => resistance.Tree,
            MagicAttribute.Water => resistance.Water,
            MagicAttribute.Wind => resistance.Wind,
            _ => 0
        };
        HP -= amount;
        OnDamage.Invoke();
        OnDamageWithAmount.Invoke(amount);
    }
    protected UnityEvent OnDamage = new UnityEvent();
    protected UnityEvent<float> OnDamageWithAmount = new UnityEvent<float>();

    protected EffectResolve resolver;
    protected bool brokeing;
    protected bool burning;
    protected bool frozing;
    protected bool paralyzing;
    protected bool poisoning;
    public virtual void AddBadStatus(BadStatus badStatus, float possibility)
    {

        if (UnityEngine.Random.Range(0f, 1f) < possibility)
        {

            resolver = GameObject.FindGameObjectWithTag("EffectResolver").GetComponent<EffectResolve>();
            var effectPosition = transform.position + new Vector3(0, 1f, 0);
            GameObject generatedEffect = null;
            switch (badStatus)
            {
                case BadStatus.broken:
                    if (brokeing) { return; }
                    StartCoroutine(Broken());
                    generatedEffect = Instantiate(resolver.BrokenEffect, effectPosition, Quaternion.Euler(-90, 0, 0));
                    break;
                case BadStatus.burnt:
                    if (burning) { return; }
                    StartCoroutine(Burnt());
                    generatedEffect = Instantiate(resolver.BurntEffect, effectPosition, Quaternion.Euler(-90, 0, 0));
                    break;
                case BadStatus.frozen:
                    if (frozing) { return; }
                    StartCoroutine(Frozen());
                    generatedEffect = Instantiate(resolver.FrozenEffect, effectPosition, Quaternion.Euler(-90, 0, 0));
                    break;
                case BadStatus.paralyzed:
                    if (paralyzing) { return; }
                    StartCoroutine(Paralyzed());
                    generatedEffect = Instantiate(resolver.ParalyzedEffect, effectPosition, Quaternion.Euler(-90, 0, 0));
                    break;
                case BadStatus.poisoned:
                    if (poisoning) { return; }
                    StartCoroutine(Poisoned());
                    generatedEffect = Instantiate(resolver.PoisonedEffect, effectPosition, Quaternion.Euler(-90, 0, 0));
                    break;
            }
            generatedEffect.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            Destroy(generatedEffect, 5);
        }
    }

    protected float broken = 1;
    protected IEnumerator Broken()
    {
        brokeing = true;
        broken = 1.5f;
        var effectPosition = transform.position + new Vector3(0, 1f, 0);
        yield return new WaitForSeconds(2);
        var generatedEffect = Instantiate(resolver.BrokenEffect, effectPosition, Quaternion.Euler(-90, 0, 0));
        generatedEffect.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        Destroy(generatedEffect, 5);
        yield return new WaitForSeconds(3);
        broken = 1;
        brokeing = false;
    }

    protected IEnumerator Burnt()
    {
        burning = true;
        GetComponent<ControlEnemy>().Burn();
        var effectPosition = transform.position + new Vector3(0, 1f, 0);
        yield return new WaitForSeconds(2);
        var generatedEffect = Instantiate(resolver.BurntEffect, effectPosition, Quaternion.Euler(-90, 0, 0));
        generatedEffect.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        Destroy(generatedEffect, 5);
        yield return new WaitForSeconds(3);
        GetComponent<ControlEnemy>().Unburn();
        burning = false;
    }

    protected IEnumerator Frozen()
    {
        frozing = true;
        GetComponent<ControlEnemy>().Freeze();
        var effectPosition = transform.position + new Vector3(0, 1f, 0);
        yield return new WaitForSeconds(2);
        var generatedEffect = Instantiate(resolver.FrozenEffect, effectPosition, Quaternion.Euler(-90, 0, 0));
        generatedEffect.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        Destroy(generatedEffect, 5);
        yield return new WaitForSeconds(2);
        generatedEffect = Instantiate(resolver.FrozenEffect, effectPosition, Quaternion.Euler(-90, 0, 0));
        generatedEffect.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        Destroy(generatedEffect, 5);
        yield return new WaitForSeconds(2);
        generatedEffect = Instantiate(resolver.FrozenEffect, effectPosition, Quaternion.Euler(-90, 0, 0));
        generatedEffect.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        Destroy(generatedEffect, 5);
        yield return new WaitForSeconds(2);
        generatedEffect = Instantiate(resolver.FrozenEffect, effectPosition, Quaternion.Euler(-90, 0, 0));
        generatedEffect.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        Destroy(generatedEffect, 5);
        yield return new WaitForSeconds(2);
        GetComponent<ControlEnemy>().Unfreeze();
        frozing = false;
    }

    protected IEnumerator Paralyzed()
    {
        paralyzing = true;
        GetComponent<ControlEnemy>().Paralyze();
        var effectPosition = transform.position + new Vector3(0, 1f, 0);
        yield return new WaitForSeconds(2);
        var generatedEffect = Instantiate(resolver.ParalyzedEffect, effectPosition, Quaternion.Euler(-90, 0, 0));
        generatedEffect.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        Destroy(generatedEffect, 5);
        yield return new WaitForSeconds(2);
        generatedEffect = Instantiate(resolver.ParalyzedEffect, effectPosition, Quaternion.Euler(-90, 0, 0));
        generatedEffect.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        Destroy(generatedEffect, 5);
        yield return new WaitForSeconds(2);
        generatedEffect = Instantiate(resolver.ParalyzedEffect, effectPosition, Quaternion.Euler(-90, 0, 0));
        generatedEffect.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        Destroy(generatedEffect, 5);
        yield return new WaitForSeconds(2);
        generatedEffect = Instantiate(resolver.ParalyzedEffect, effectPosition, Quaternion.Euler(-90, 0, 0));
        generatedEffect.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        Destroy(generatedEffect, 5);
        yield return new WaitForSeconds(2);
        GetComponent<ControlEnemy>().Unparalyze();
        paralyzing = false;
    }

    float poisoned = 0;
    protected IEnumerator Poisoned()
    {
        poisoning = true;
        poisoned = 0.5f;
        var effectPosition = transform.position + new Vector3(0, 1f, 0);
        yield return new WaitForSeconds(2);
        var generatedEffect = Instantiate(resolver.PoisonedEffect, effectPosition, Quaternion.Euler(-90, 0, 0));
        generatedEffect.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        Destroy(generatedEffect, 5);
        yield return new WaitForSeconds(3);
        poisoned = 0;
        poisoning = false;
    }



    public bool OneTimeShotBadStatusTried { get; private set; } = false;

    public void OneTimeShotBadStatusTry()
    {
        StartCoroutine(OneTimeShotBadStatusTriedCoroutine());
    }

    IEnumerator OneTimeShotBadStatusTriedCoroutine()
    {
        OneTimeShotBadStatusTried = true;
        yield return new WaitForSeconds(1);
        OneTimeShotBadStatusTried = false;
    }
}
