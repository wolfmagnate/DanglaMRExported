using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMagicFromServerSceneControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 8; i++)
        {
            int a = i;
            GameObject.Find($"Magic{i}").GetComponent<Button>().onClick.AddListener(() =>
            {
                MenuSESoundManager.Instance.PlayOK();
                var Panel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
                Panel.SetActive(true);
                Panel.GetComponent<RectTransform>().localScale = Vector3.zero;
                Panel.GetComponent<RectTransform>().DOScale(1, 0.3f);
                Panel.GetComponent<LoadFromServerPanelControl>().SetMagicKey(a);
            });
        }
        Refresh();
    }

    public static void Refresh()
    {
        for (int i = 1; i <= 8; i++)
        {
            if (LoadMagic.HasKeyFromServer($"{i}"))
            {
                Magic magici = LoadMagic.LoadFromServer($"{i}");
                GameObject.Find($"Magic{i}").transform.Find("Text").GetComponent<Text>().text = magici.MagicName;
            }
            else
            {
                GameObject.Find($"Magic{i}").transform.Find("Text").GetComponent<Text>().text = "空のスロット";
            }
        }
    }

    public void Back()
    {
        MenuSESoundManager.Instance.PlayCancel();
        SceneManager.LoadScene("Project/Menu/Menu");
    }
}
