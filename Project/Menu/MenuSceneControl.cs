using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneControl : MonoBehaviour
{
    public void ToUsingMagicSelect()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/SelectusingMagic/SelectUsingMagic");
    }

    public void ToItemShop()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/PowerUpItemShop/PowerUpItemShop");
    }

    public void ToZukan()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Zukan/Zukan");
    }

    public void ToCardStorage()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/CardInventory/CardInventory");
    }

    public void ToCreateMagic()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/SelectCards/SelectCards");
    }

    public void ToLab()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Lab Research Selection/Lab Research Selection");
    }

    public void ToCheckMagic()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/SelectCheckMagic/SelectCheckMagic");
    }

    public void ToSaveMagic()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/SendMagic/SendMagic");
    }

    public void ToLoadMagicFromServer()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/LoadMagicFromServer/LoadMagicFromServer");
    }
    public void ToSettings()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Setting/Setting");
    }

    public void ToCardShop()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Card Shop/CardShopHub");
    }

    public void ToScenario()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/ScenarioSelect/ScenarioSelect");
    }

    public void ToCredit()
    {
        MenuSESoundManager.Instance.PlayOK();
        SceneManager.LoadScene("Project/Credit/CreditScene");
    }
}
