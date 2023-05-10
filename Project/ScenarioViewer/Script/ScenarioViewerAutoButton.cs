using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioViewerAutoButton : MonoBehaviour
{
    public Sprite Normal;
    public Sprite Pressed;
    bool pressedFlag;
    ScenarioViewerControl control;
    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Canvas").GetComponent<ScenarioViewerControl>();
        pressedFlag = false;
    }

    public void SwitchButton()
    {
        if (pressedFlag)
        {
            GetComponent<Image>().sprite = Normal;
            pressedFlag = false;
            control.AutoMode = false;
        }
        else
        {
            GetComponent<Image>().sprite = Pressed;
            pressedFlag = true;
            control.AutoMode = true;
        }
    }
}
