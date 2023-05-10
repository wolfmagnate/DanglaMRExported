using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpInformationEnterButton : MonoBehaviour
{
    public string SceneName;
    public void Back()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene(SceneName);
    }
}

