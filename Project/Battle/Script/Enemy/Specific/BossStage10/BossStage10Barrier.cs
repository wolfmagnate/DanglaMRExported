using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage10Barrier : MonoBehaviour
{
    public bool IsArrive { get; private set; }
    PlayerStatus status;
    bool isReviveTime = false;
    public float MaxHP;
    Collider Mycollider;
    // Start is called before the first frame update
    void Start()
    {
        status = GetComponent<PlayerStatus>();
        Mycollider = GetComponent<Collider>();
        Shrink();
    }

    // Update is called once per frame
    void Update()
    {
        if(status.HP <= 0 && !isReviveTime)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        transform.Find("BarrierAura").localScale = Vector3.zero;
        transform.Find("BarrierAura").gameObject.GetComponent<AudioSource>().enabled = false;
        IsArrive = false;
        isReviveTime = true;
        Mycollider.enabled = false;
        yield return new WaitForSeconds(10);
        Mycollider.enabled = true;
        status.HP = MaxHP;
        transform.Find("BarrierAura").localScale = 0.33f * Vector3.one;
        transform.Find("BarrierAura").gameObject.GetComponent<AudioSource>().enabled = true;
        IsArrive = true;
        isReviveTime = false;
    }

    public void Expand()
    {
        status.HP = MaxHP;
        transform.Find("BarrierAura").localScale = 0.33f * Vector3.one;
        transform.Find("BarrierAura").gameObject.GetComponent<AudioSource>().enabled = true;
        Mycollider.enabled = true;
    }

    public void Shrink()
    {
        status.HP = MaxHP;
        transform.Find("BarrierAura").localScale = Vector3.zero;
        transform.Find("BarrierAura").gameObject.GetComponent<AudioSource>().enabled = false;
        Mycollider.enabled = false;
    }
}
