using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SaveMagicSceneControll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1;i <= 8; i++)
        {
            int a = i;
            GameObject.Find($"Magic{i}").GetComponent<Button>().onClick.AddListener(() =>
            {
                var Panel = GameObject.Find("Canvas").transform.Find("Panel").gameObject;
                Panel.SetActive(true);
                Panel.GetComponent<RectTransform>().localScale = Vector3.zero;
                Panel.GetComponent<RectTransform>().DOScale(1, 0.3f);
                Panel.GetComponent<SaveMagicPanelControl>().SetMagicKey(a);
                Refresh();
            });
        }
        Refresh();
    }

    public static void Refresh()
    {
        for (int i = 1; i <= 8; i++)
        {
            if (LoadMagic.HasKey($"{i}"))
            {
                Magic magici = LoadMagic.Load($"{i}");
                GameObject.Find($"Magic{i}").transform.Find("Text").GetComponent<Text>().text = magici.MagicName;
            }
            else
            {
                GameObject.Find($"Magic{i}").transform.Find("Text").GetComponent<Text>().text = "ãÛÇÃÉXÉçÉbÉg";
            }
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Project/CheckMagic/CheckMagic");
    }
    public void ToTitle()
    {
        SceneManager.LoadScene("Project/SelectusingMagic/SelectUsingMagic");
    }
}
