using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyBeamAttackShotEffect : MonoBehaviour
{
    public GameObject HitEffect;
    Vector3 start;
    Vector3 end;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(start, (end - start).normalized);
        RaycastHit hitInfo;
        if (Physics.SphereCast(ray, 0.1f, out hitInfo, (end - start).magnitude, LayerMask.GetMask(new[] { "Player" })))
        {
            var effect = Instantiate(HitEffect, hitInfo.collider.gameObject.transform.position, Quaternion.identity);
            effect.transform.localScale = 0.3f * Vector3.one;
            Destroy(effect, 1);
        }
    }

    /// <summary>
    /// énì_Ç∆èIì_Çìoò^Ç∑ÇÈ
    /// </summary>
    /// <param name="positions"></param>
    public void SetPositions(Vector3[] positions)
    {
        (start, end) = (positions[0], positions[1]);
    }
}
