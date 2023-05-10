using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyBeamAttackShot : MonoBehaviour
{
    public float Attack;
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    int HasHit = 0;

    // Update is called once per frame
    void Update()
    {
        if (HasHit > 0) { return; }
        Vector3 start = lineRenderer.GetPosition(0);
        Vector3 end = lineRenderer.GetPosition(1);

        Ray ray = new Ray(start, (end - start).normalized);
        RaycastHit hitInfo;
        if(Physics.SphereCast(ray, 0.1f, out hitInfo, (end - start).magnitude, LayerMask.GetMask(new[] { "Player" })))
        {
            hitInfo.collider.gameObject.GetComponent<PlayerStatus>().Damage(Attack);
            HasHit = 10;
        }

        
    }
}
