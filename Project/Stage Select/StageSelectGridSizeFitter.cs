using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectGridSizeFitter : MonoBehaviour
{
    GridLayoutGroup grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<GridLayoutGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        grid.cellSize = new Vector2(Screen.width, 918);
    }
}
