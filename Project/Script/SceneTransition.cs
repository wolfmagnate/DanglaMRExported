using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private string sceneName;

    public void SetSceneName(string sceneName)
    {
        this.sceneName = sceneName;
    }

    private void TransitionTo()
    {
        SceneManager.LoadScene(sceneName);
    }
}