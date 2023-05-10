using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SelectUsingMagicSceneControll : MonoBehaviour
{

    protected RectTransform OwnMagic;
    protected RectTransform ServerMagic;
    protected Text slot;

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
            if (LoadMagic.HasKey($"{i}"))
            {
                Magic magici = LoadMagic.Load($"{i}");
                GameObject.Find($"Magic{i}").transform.Find("Text").GetComponent<Text>().text = magici.MagicName;
            }
            else
            {
                GameObject.Find($"Magic{i}").transform.Find("Text").GetComponent<Text>().text = "空のスロット";
            }
        }
        for (int i = 9; i <= 16; i++)
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

    public void OnMagic1()
    {
        if (!LoadMagic.HasKey("1"))
        {
            return;
        }
        ShootPlayer.usingMagic = LoadMagic.Load("1");
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Stage Select/Stage Select");
    }

    public void OnMagic2()
    {

        if (!LoadMagic.HasKey("2"))
        {
            return;
        }
        ShootPlayer.usingMagic = LoadMagic.Load("2");
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Stage Select/Stage Select");
    }

    public void OnMagic3()
    {

        if (!LoadMagic.HasKey("3"))
        {
            return;
        }
        ShootPlayer.usingMagic = LoadMagic.Load("3");
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Stage Select/Stage Select");
    }

    public void OnMagic4()
    {

        if (!LoadMagic.HasKey("4"))
        {
            return;
        }
        ShootPlayer.usingMagic = LoadMagic.Load("4");
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Stage Select/Stage Select");
    }

    public void OnMagic5()
    {

        if (!LoadMagic.HasKey("5"))
        {
            return;
        }
        ShootPlayer.usingMagic = LoadMagic.Load("5");
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Stage Select/Stage Select");
    }

    public void OnMagic6()
    {

        if (!LoadMagic.HasKey("6"))
        {
            return;
        }
        ShootPlayer.usingMagic = LoadMagic.Load("6");
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Stage Select/Stage Select");
    }
    public void OnMagic7()
    {

        if (!LoadMagic.HasKey("7"))
        {
            return;
        }
        ShootPlayer.usingMagic = LoadMagic.Load("7");
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Stage Select/Stage Select");
    }

    public void OnMagic8()
    {

        if (!LoadMagic.HasKey("8"))
        {
            return;
        }
        ShootPlayer.usingMagic = LoadMagic.Load("8");
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Stage Select/Stage Select");
    }


    public void OnMagic9()
    {
        if (!LoadMagic.HasKeyFromServer("1"))
        {
            return;
        }
        ShootPlayer.usingMagic = LoadMagic.LoadFromServer("1");
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Stage Select/Stage Select");
    }

    public void OnMagic10()
    {
        if (!LoadMagic.HasKeyFromServer("2"))
        {
            return;
        }
        ShootPlayer.usingMagic = LoadMagic.LoadFromServer("2");
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Stage Select/Stage Select");
    }

    public void OnMagic11()
    {
        if (!LoadMagic.HasKeyFromServer("3"))
        {
            return;
        }
        ShootPlayer.usingMagic = LoadMagic.LoadFromServer("3");
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Stage Select/Stage Select");
    }

    public void OnMagic12()
    {
        if (!LoadMagic.HasKeyFromServer("4"))
        {
            return;
        }
        ShootPlayer.usingMagic = LoadMagic.LoadFromServer("4");
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Stage Select/Stage Select");
    }


    public void OnMagic13()
    {
        if (!LoadMagic.HasKeyFromServer("5"))
        {
            return;
        }
        ShootPlayer.usingMagic = LoadMagic.LoadFromServer("5");
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Stage Select/Stage Select");
    }

    public void OnMagic14()
    {
        if (!LoadMagic.HasKeyFromServer("6"))
        {
            return;
        }
        ShootPlayer.usingMagic = LoadMagic.LoadFromServer("6");
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Stage Select/Stage Select");
    }


    public void OnMagic15()
    {
        if (!LoadMagic.HasKeyFromServer("7"))
        {
            return;
        }
        ShootPlayer.usingMagic = LoadMagic.LoadFromServer("7");
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Stage Select/Stage Select");
    }

    public void OnMagic16()
    {
        if (!LoadMagic.HasKeyFromServer("8"))
        {
            return;
        }
        ShootPlayer.usingMagic = LoadMagic.LoadFromServer("8");
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Stage Select/Stage Select");
    }
    public void Back()
    {
        MenuSESoundManager.Instance.PlayCancel();
        SceneManager.LoadScene("Project/Menu/Menu");
    }

    public void Previous()
    {
        if (IsAnimating) { return; }
        MenuSESoundManager.Instance.PlayClick();
        StartCoroutine(AnimationWaitCoroutine());
        if (IsServerMagic)
        {
            OwnMagic.localPosition = new Vector2(-1920, 0);
            OwnMagic.DOLocalMove(new Vector2(0, 0), 0.5f);
            ServerMagic.DOLocalMove(new Vector2(1920, 0), 0.5f);
        }
        else
        {
            ServerMagic.localPosition = new Vector2(-1920, 0);
            ServerMagic.DOLocalMove(new Vector2(0, 0), 0.5f);
            OwnMagic.DOLocalMove(new Vector2(1920, 0), 0.5f);
        }
        IsServerMagic = !IsServerMagic;
        SwitchText();
    }

    public void Next()
    {
        if (IsAnimating) { return; }
        MenuSESoundManager.Instance.PlayClick();
        StartCoroutine(AnimationWaitCoroutine());
        if (IsServerMagic)
        {
            ServerMagic.DOLocalMove(new Vector2(-1920, 0), 0.5f);
            OwnMagic.localPosition = new Vector2(1920, 0);
            OwnMagic.DOLocalMove(new Vector2(0, 0), 0.5f);
        }
        else
        {
            ServerMagic.localPosition = new Vector2(1920, 0);
            ServerMagic.DOLocalMove(new Vector2(0, 0), 0.5f);
            OwnMagic.DOLocalMove(new Vector2(-1920, 0), 0.5f);
        }
        IsServerMagic = !IsServerMagic;
        SwitchText();
    }

    protected bool IsServerMagic;
    protected bool IsAnimating;

    void SwitchText()
    {
        if (IsServerMagic)
        {
            slot.text = "外部の薬品武装から選択";
        }
        else
        {
            slot.text = "自作の薬品武装から選択";
        }
    }

    IEnumerator AnimationWaitCoroutine()
    {
        IsAnimating = true;
        yield return new WaitForSeconds(0.6f);
        IsAnimating = false;
    }
}
