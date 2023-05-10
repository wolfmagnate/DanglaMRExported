using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMVolumeApplySettings : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().volume = SettingSceneControl.BGMVolume;
    }
}
