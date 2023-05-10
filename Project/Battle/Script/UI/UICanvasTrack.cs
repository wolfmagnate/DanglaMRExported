using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasTrack : MonoBehaviour
{
    Transform target;
    bool tracking = false;
    float distance;
    public void StartTrack(Transform target)
    {
        this.target = target;
        distance = (transform.position - target.position).magnitude;
        tracking = true;
    }

    private void Update()
    {
        if (tracking)
        {
            transform.position = target.position + target.forward * distance;
            transform.LookAt(transform.position - (target.position - transform.position));
        }
    }
}
