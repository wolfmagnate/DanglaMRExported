using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioViewrConfigControl : MonoBehaviour
{
    Slider bgmSlider;
    Slider seSlider;

    private void Start()
    {
        bgmSlider = transform.Find("BGM").gameObject.GetComponent<Slider>();
        bgmSlider.value = SettingSceneControl.BGMVolume;
        seSlider = transform.Find("SE").gameObject.GetComponent<Slider>();
        seSlider.value = SettingSceneControl.SEVolume;
    }

    public void BGMVolume()
    {
        SettingSceneControl.BGMVolume = bgmSlider.value;
    }

    public void SEVolume()
    {
        SettingSceneControl.SEVolume = seSlider.value;
    }
}
