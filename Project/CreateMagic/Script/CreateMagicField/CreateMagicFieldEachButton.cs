using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CreateMagicFieldEachButton : MonoBehaviour
{
    Image numberSprite;
    Image numberBackground;
    Image icon;
    Vector2Int position;
    MagicFieldChainModel model;
    CreateMagicFieldManager manager;

    private void Awake()
    {
        numberSprite = transform.Find("SpriteNumber").gameObject.GetComponent<Image>();
        numberBackground = transform.Find("SpriteBackground").gameObject.GetComponent<Image>();
        icon = transform.Find("ThumbnailMask/Thumbnail").gameObject.GetComponent<Image>();
    }

    public void SetPosition(Vector2Int pos)
    {
        position = pos;
    }

    public void SetModel(MagicFieldChainModel model)
    {
        this.model = model;
    }

    public void SetManager(CreateMagicFieldManager manager)
    {
        this.manager = manager;
    }

    public void OnDragBegin()
    {
        model.SelectPosition(position);
    }

    public void OnDragEnd()
    {
        model.StopSelect();
    }

    public void OnPointerEnter()
    {
        if (model.IsSelectMode())
        {
            model.SelectPosition(position);
        }
    }

    public void ChangeIcon()
    {
        if (model.MagicField[position.y, position.x] == null)
        {
            icon.sprite = manager.DefaultIcon;
        }
        else
        {
            icon.sprite = model.MagicField[position.y, position.x].GetIcon();
        }
    }

    private void Update()
    {
        ChangeNumber();
        ChangeArrow();
        ChangeUsedArrow();
    }

    void ChangeNumber()
    {
        if(model == null) { return; }
        if (model.SelectPositions.Contains(position))
        {
            numberSprite.sprite = manager.GetChainNumberSprite(model.GetSelectedIndex(position) + 1);
            if (model.HasOrderPowerUp(position))
            {
                numberBackground.sprite = manager.PowerUpNumberBackground;
                numberSprite.color = manager.PowerUpNumberSpriteColor;
            }
            else
            {
                numberBackground.sprite = manager.NumberBackground;
                numberSprite.color = manager.NumberSpriteColor;
            }
            numberBackground.color = Color.white;
        }
        else
        {
            numberBackground.color = new Color(0, 0, 0, 0);
            numberSprite.color = new Color(0, 0, 0, 0);
        }
    }

    public void ChangeArrow()
    {
        if(model == null) { return; }
        if(model.MagicField[position.y, position.x] == null) { return; }
        var enterDirections = model.EnterPowerUps[position];
        for (int i = 0;i < enterDirections.Count; i++)
        {
            DisplayEnterArrow(enterDirections[i]);
        }
        var leaveDirections = model.LeavePowerUps[position];
        for (int i = 0; i < leaveDirections.Count; i++)
        {
            DisplayLeaveArrow(leaveDirections[i]);
        }
    }

    void DisplayEnterArrow(CardDirection direction)
    {
        DisplayEnterArrow(direction, manager.PowerUpArrow);
    }
    void DisplayLeaveArrow(CardDirection direction)
    {
        DisplayLeaveArrow(direction, manager.PowerUpArrow);
    }
    void DisplayUsedEnterArrow(CardDirection direction)
    {
        DisplayEnterArrow(direction, manager.UsedPowerUpArrow);
    }
    void DisplayUsedLeaveArrow(CardDirection direction)
    {
        DisplayLeaveArrow(direction, manager.UsedPowerUpArrow);
    }

    void DisplayEnterArrow(CardDirection direction, Sprite icon)
    {
        switch (direction)
        {
            case CardDirection.down:
                transform.Find("DirectionPowerUpArrows/EnterDown").gameObject.GetComponent<Image>().color = Color.white;
                transform.Find("DirectionPowerUpArrows/EnterDown").gameObject.GetComponent<Image>().sprite = icon;
                break;
            case CardDirection.down_left:
                transform.Find("DirectionPowerUpArrows/EnterDownLeft").gameObject.GetComponent<Image>().color = Color.white;
                transform.Find("DirectionPowerUpArrows/EnterDownLeft").gameObject.GetComponent<Image>().sprite = icon;
                break;
            case CardDirection.left:
                transform.Find("DirectionPowerUpArrows/EnterLeft").gameObject.GetComponent<Image>().color = Color.white;
                transform.Find("DirectionPowerUpArrows/EnterLeft").gameObject.GetComponent<Image>().sprite = icon;
                break;
            case CardDirection.up_left:
                transform.Find("DirectionPowerUpArrows/EnterUpLeft").gameObject.GetComponent<Image>().color = Color.white;
                transform.Find("DirectionPowerUpArrows/EnterUpLeft").gameObject.GetComponent<Image>().sprite = icon;
                break;
            case CardDirection.up:
                transform.Find("DirectionPowerUpArrows/EnterUp").gameObject.GetComponent<Image>().color = Color.white;
                transform.Find("DirectionPowerUpArrows/EnterUp").gameObject.GetComponent<Image>().sprite = icon;
                break;
            case CardDirection.up_right:
                transform.Find("DirectionPowerUpArrows/EnterUpRight").gameObject.GetComponent<Image>().color = Color.white;
                transform.Find("DirectionPowerUpArrows/EnterUpRight").gameObject.GetComponent<Image>().sprite = icon;
                break;
            case CardDirection.right:
                transform.Find("DirectionPowerUpArrows/EnterRight").gameObject.GetComponent<Image>().color = Color.white;
                transform.Find("DirectionPowerUpArrows/EnterRight").gameObject.GetComponent<Image>().sprite = icon;
                break;
            case CardDirection.down_right:
                transform.Find("DirectionPowerUpArrows/EnterDownRight").gameObject.GetComponent<Image>().color = Color.white;
                transform.Find("DirectionPowerUpArrows/EnterDownRight").gameObject.GetComponent<Image>().sprite = icon;
                break;
        }
    }

    void DisplayLeaveArrow(CardDirection direction, Sprite icon)
    {
        switch (direction)
        {
            case CardDirection.down:
                transform.Find("DirectionPowerUpArrows/LeaveDown").gameObject.GetComponent<Image>().color = Color.white;
                transform.Find("DirectionPowerUpArrows/LeaveDown").gameObject.GetComponent<Image>().sprite = icon;
                break;
            case CardDirection.down_left:
                transform.Find("DirectionPowerUpArrows/LeaveDownLeft").gameObject.GetComponent<Image>().color = Color.white;
                transform.Find("DirectionPowerUpArrows/LeaveDownLeft").gameObject.GetComponent<Image>().sprite = icon;
                break;
            case CardDirection.left:
                transform.Find("DirectionPowerUpArrows/LeaveLeft").gameObject.GetComponent<Image>().color = Color.white;
                transform.Find("DirectionPowerUpArrows/LeaveLeft").gameObject.GetComponent<Image>().sprite = icon;
                break;
            case CardDirection.up_left:
                transform.Find("DirectionPowerUpArrows/LeaveUpLeft").gameObject.GetComponent<Image>().color = Color.white;
                transform.Find("DirectionPowerUpArrows/LeaveUpLeft").gameObject.GetComponent<Image>().sprite = icon;
                break;
            case CardDirection.up:
                transform.Find("DirectionPowerUpArrows/LeaveUp").gameObject.GetComponent<Image>().color = Color.white;
                transform.Find("DirectionPowerUpArrows/LeaveUp").gameObject.GetComponent<Image>().sprite = icon;
                break;
            case CardDirection.up_right:
                transform.Find("DirectionPowerUpArrows/LeaveUpRight").gameObject.GetComponent<Image>().color = Color.white;
                transform.Find("DirectionPowerUpArrows/LeaveUpRight").gameObject.GetComponent<Image>().sprite = icon;
                break;
            case CardDirection.right:
                transform.Find("DirectionPowerUpArrows/LeaveRight").gameObject.GetComponent<Image>().color = Color.white;
                transform.Find("DirectionPowerUpArrows/LeaveRight").gameObject.GetComponent<Image>().sprite = icon;
                break;
            case CardDirection.down_right:
                transform.Find("DirectionPowerUpArrows/LeaveDownRight").gameObject.GetComponent<Image>().color = Color.white;
                transform.Find("DirectionPowerUpArrows/LeaveDownRight").gameObject.GetComponent<Image>().sprite = icon;
                break;
        }
    }

    void ChangeUsedArrow()
    {
        var enterDirec = model.GetUsedEnterDirection(position);
        var leaveDirec = model.GetUsedLeaveDirection(position);
        DisplayUsedEnterArrow(enterDirec);
        DisplayUsedLeaveArrow(leaveDirec);
    }

}
