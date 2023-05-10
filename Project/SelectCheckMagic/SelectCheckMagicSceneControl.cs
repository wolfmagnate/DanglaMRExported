using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCheckMagicSceneControl : SelectUsingMagicSceneControll
{
    void Start()
    {
        IsServerMagic = false;
        Refresh();
        OwnMagic = GameObject.Find("OwnMagic").GetComponent<RectTransform>();
        ServerMagic = GameObject.Find("ServerMagic").GetComponent<RectTransform>();
        slot = transform.Find("Slot/Text").gameObject.GetComponent<Text>();
    }

    private static void Refresh()
    {
        for (int i = 1; i <= 8; i++)
        {
            GameObject textI = GameObject.Find($"Magic{i}").transform.Find("Text").gameObject;
            if (LoadMagic.HasKey($"{i}"))
            {
                Magic magic = LoadMagic.Load($"{i}");
                textI.GetComponent<Text>().text = magic.MagicName;
                int a = i;
                textI.transform.parent.gameObject.GetComponent<Button>().onClick.AddListener(() => {
                    var magic = LoadMagic.Load($"{a}");
                    CHeckMagicFromMenuControl.DisplayMagic = magic;
                    MenuSESoundManager.Instance.PlayOK();
                    SceneManager.LoadScene("Project/CheckMagicFromMenu/CheckMagicFromMenu");
                });
            }
            else
            {
                textI.GetComponent<Text>().text = "空のスロット";
            }
        }
        for (int i = 9; i <= 16; i++)
        {
            GameObject textI = GameObject.Find($"Magic{i}").transform.Find("Text").gameObject;
            if (LoadMagic.HasKeyFromServer($"{i - 8}"))
            {
                Magic magic = LoadMagic.LoadFromServer($"{i - 8}");
                textI.GetComponent<Text>().text = magic.MagicName;
                int a = i;
                textI.transform.parent.gameObject.GetComponent<Button>().onClick.AddListener(() => {
                    var magic = LoadMagic.LoadFromServer($"{a - 8}");
                    CHeckMagicFromMenuControl.DisplayMagic = magic;
                    MenuSESoundManager.Instance.PlayOK();
                    SceneManager.LoadScene("Project/CheckMagicFromMenu/CheckMagicFromMenu");
                });
            }
            else
            {
                textI.GetComponent<Text>().text = "空のスロット";
            }
        }
    }

}