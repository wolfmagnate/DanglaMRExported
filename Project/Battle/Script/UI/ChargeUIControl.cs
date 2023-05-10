using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeUIControl : MonoBehaviour
{
    Image circle;
    Image circleBase;
    // Start is called before the first frame update
    void Start()
    {
        circle = transform.Find("Charge/ChargeMain").gameObject.GetComponent<Image>();
        circleBase= transform.Find("Charge").gameObject.GetComponent<Image>();
    }

    public void ChangeChargeAmount(float ratio)
    {
        if(ratio == 0) { circle.color = new Color(0, 0, 0, 0); circleBase.color = new Color(0, 0, 0, 0); }
        if(ratio != 0) { circle.color = Color.white; circleBase.color = Color.white; }
        circle.fillAmount = ratio;
    }
}
