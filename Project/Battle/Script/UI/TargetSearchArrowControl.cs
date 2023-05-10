using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TargetSearchArrowControl : MonoBehaviour
{

    Image LeftArrow;
    Image RightArrow;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        LeftArrow = transform.Find("TargetLeft").gameObject.GetComponent<Image>();
        RightArrow = transform.Find("TargetRight").gameObject.GetComponent<Image>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!EnemyExists())
        {
            DeleteBothArrow();
            return;
        }
        var Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (Enemys.Any(x => IsInSight(x.transform.position)))
        {
            DeleteBothArrow();
            return;
        }
        foreach(var enemy in Enemys)
        {
            if (IsOutOfSightLeft(enemy.transform.position))
            {
                DisplayLeftArrow();
            }
            if (IsOutOfSightRight(enemy.transform.position))
            {
                DisplayRightArrow();
            }
        }
        if(!Enemys.Any(x => IsOutOfSightLeft(x.transform.position)))
        {
            DeleteLeftArrow();
        }
        if (!Enemys.Any(x => IsOutOfSightRight(x.transform.position)))
        {
            DeleteRightArrow();
        }
    }

    bool EnemyExists() => GameObject.FindGameObjectsWithTag("Enemy").Length != 0;
    
    void DeleteBothArrow()
    {
        DeleteLeftArrow();
        DeleteRightArrow();
    }

    void DeleteLeftArrow()
    {
        LeftArrow.color = new Color(1, 1, 1, 0);
    }

    void DeleteRightArrow()
    {
        RightArrow.color = new Color(1, 1, 1, 0);
    }

    void DisplayLeftArrow()
    {
        LeftArrow.color = new Color(1, 1, 1);
    }

    void DisplayRightArrow()
    {
        RightArrow.color = new Color(1, 1, 1);
    }

    bool IsInSight(Vector3 position)
    {
        float cosAngle = CalcCosAngle(position, Player.transform.forward);
        return cosAngle >= (Mathf.Sqrt(3) / 2);
    }

    private float CalcCosAngle(Vector3 position, Vector3 vector)
    {
        float dot = Vector3.Dot(position - Player.transform.position, vector);
        float absdirection = (position - Player.transform.position).magnitude;
        float absvector = vector.magnitude;
        float cosAngle = dot / (absdirection * absvector);
        return cosAngle;
    }

    bool IsOutOfSightLeft(Vector3 position)
    {
        float cosAngleWithForward = CalcCosAngle(position, Player.transform.forward);
        float cosAngleWithRight = CalcCosAngle(position, Player.transform.right);
        bool isOutOfSight = cosAngleWithForward < (Mathf.Sqrt(3) / 2);
        bool isLeft = cosAngleWithRight <= 0;
        return isOutOfSight && isLeft;
    }

    bool IsOutOfSightRight(Vector3 position)
    {
        float cosAngleWithForward = CalcCosAngle(position, Player.transform.forward);
        float cosAngleWithRight = CalcCosAngle(position, Player.transform.right);
        bool isOutOfSight = cosAngleWithForward < (Mathf.Sqrt(3) / 2);
        bool isRight = cosAngleWithRight >= 0;
        return isOutOfSight && isRight;
    }
}
