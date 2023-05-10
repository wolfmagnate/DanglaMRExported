using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpInformationBackButton : MonoBehaviour
{
    public string SceneName;
    public void Back()
    {
        MenuSESoundManager.Instance.PlayCancel();
        SceneManager.LoadScene(SceneName);
    }
}
