using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class AspectAdopter : MonoBehaviour
{
    [SerializeField]
    private Vector2 aspectVector;
    [SerializeField]
    private Camera targetCamera;

    void Update()
    {
        var screenAspect = Screen.width / (float)Screen.height;
        var targetAspect = aspectVector.x / aspectVector.y;
        var magRate = targetAspect / screenAspect;

        var viewportRect = new Rect(0, 0, 1, 1);
        viewportRect.width = magRate;
        targetCamera.rect = viewportRect;

        if (magRate < 1)
        {
            viewportRect.width = magRate;
            viewportRect.x = 0.5f - viewportRect.width * 0.5f;
        }
        else
        {
            viewportRect.height = 1 / magRate;
            viewportRect.y = 0.5f - viewportRect.height * 0.5f;
        }

        targetCamera.rect = viewportRect;
    }

}
