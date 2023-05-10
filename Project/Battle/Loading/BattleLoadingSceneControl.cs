using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class BattleLoadingSceneControl : MonoBehaviour
{
    public void SetInformation(string nextSceneName, string adviceText)
    {
        this.adviceText = adviceText;
        nextScene = nextSceneName;
    }

    string adviceText;
    Image progress;
    string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        progress = transform.Find("ProgressBar").gameObject.GetComponent<Image>();
        transform.Find("Text").GetComponent<Text>().text = adviceText;
        StartCoroutine(ChangeSceneCoroutien());
    }

    IEnumerator ChangeSceneCoroutien()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextScene);
        asyncLoad.allowSceneActivation = false;

        do
        {
            MoveImageFill();
            yield return new WaitForSeconds(3);
        } while (asyncLoad.progress < 0.9f);
        asyncLoad.allowSceneActivation = true;
    }

    void MoveImageFill()
    {
        StartCoroutine(MoveImageFillCoroutine());
    }

    IEnumerator MoveImageFillCoroutine()
    {
        progress.DOFillAmount(1, 1.5f);
        yield return new WaitForSeconds(1.5f);
        Reverse();
        progress.DOFillAmount(0, 1.5f);
        yield return new WaitForSeconds(1.5f);
        Reverse();
    }

    void Reverse()
    {
        if (progress.fillClockwise)
        {
            progress.fillClockwise = false;
        }
        else
        {
            progress.fillClockwise = true;
        }
    }
}
