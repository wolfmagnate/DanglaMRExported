using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEVolumeApplySetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = SettingSceneControl.SEVolume;
    }
}
