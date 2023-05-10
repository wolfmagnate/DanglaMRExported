using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CautionUIControl : MonoBehaviour
{
    Image caution;
    // Start is called before the first frame update
    void Start()
    {
        caution = transform.Find("Caution").GetComponent<Image>();
    }

    public void StartCaution()
    {
        caution.color = Color.yellow;
    }

    public void StopCaution()
    {
        caution.color = new Color(0, 0, 0, 0);
    }
}
