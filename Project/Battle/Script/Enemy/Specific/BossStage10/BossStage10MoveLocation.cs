using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage10MoveLocation : MonoBehaviour
{
    public float Angle;
    GameObject Player;
    float DeltaAngle;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        DeltaAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // í‚ÉAPlayer‚©‚ç‹——£3m‚©‚ÂAngle+DeltaAngle“x‚¸‚ê‚½êŠ‚É‘¶Ý‚·‚é
        transform.position = Quaternion.Euler(0, Angle + DeltaAngle, 0) * Player.transform.forward * 3.5f + Player.transform.position;
        DeltaAngle += 0.1f;
        if(DeltaAngle > 360)
        {
            DeltaAngle -= 360;
        }
    }
}
