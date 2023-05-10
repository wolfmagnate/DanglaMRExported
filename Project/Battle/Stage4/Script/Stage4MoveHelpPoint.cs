using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stage4MoveHelpPoint : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            Vector3 rand = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)) * Vector3.one;
            if(transform.position.y < -3 && rand.y < 0)
            {
                rand = Quaternion.Euler(180, 0, 0) * rand;
            }
            if(transform.position.y > 3 && rand.y > 0)
            {
                rand = Quaternion.Euler(180, 0, 0) * rand;
            }
            if(transform.position.x > 10 && rand.x > 0)
            {
                rand = Quaternion.Euler(0, 180, 0) * rand;
            }
            if (transform.position.x < -10 && rand.x < 0)
            {
                rand = Quaternion.Euler(0, 180, 0) * rand;
            }
            if (transform.position.z > 10 && rand.z > 0)
            {
                rand = Quaternion.Euler(0, 180, 0) * rand;
            }
            if (transform.position.z < -10 && rand.z < 0)
            {
                rand = Quaternion.Euler(0, 180, 0) * rand;
            }
            transform.DOMove(transform.position + rand, 1f);
            yield return new WaitForSeconds(1);
        }
    }
}
