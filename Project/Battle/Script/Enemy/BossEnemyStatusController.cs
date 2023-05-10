using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyStatusController : EnemyStatusController
{
    public override void AddBadStatus(BadStatus badStatus, float possibility)
    {
        if(Random.Range(0,10) != 0) { return; }
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
}
