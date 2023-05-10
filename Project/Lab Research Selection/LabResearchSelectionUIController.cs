using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LabResearchSelectionUIController : MonoBehaviour
{
    public void ToMenu()
    {
        MenuSESoundManager.Instance.PlayCancel();
        SceneManager.LoadScene("Project/Menu/Menu");
    }
}
