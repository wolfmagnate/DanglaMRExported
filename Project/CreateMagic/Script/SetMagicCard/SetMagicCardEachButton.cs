using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetMagicCardEachButton : MonoBehaviour
{
    public void OnPointerEnter()
    {
        model.GridMove(position);
    }

    public void OnDragBegin()
    {
        model.StartSelect(position);
    }

    public void OnDragEnd()
    {
        model.EndSelect();
    }

    DecideOrderModel model;
    SetMagicCards manager;
    Vector2Int position;
    public void SetModel(DecideOrderModel model)
    {
        this.model = model;
    }
    public void SetManager(SetMagicCards manager)
    {
        this.manager = manager;
    }
    public void SetPosition(Vector2Int position)
    {
        this.position = position;
    }

    Image positionPowerUp;
    Image thumbnail;
    Image EnterDown;
    Image EnterDownLeft;
    Image EnterDownRight;
    Image EnterUp;
    Image EnterUpRight;
    Image EnterUpLeft;
    Image EnterRight;
    Image EnterLeft;
    Image LeaveDown;
    Image LeaveDownLeft;
    Image LeaveDownRight;
    Image LeaveUp;
    Image LeaveUpRight;
    Image LeaveUpLeft;
    Image LeaveRight;
    Image LeaveLeft;
    private void Awake()
    {
        positionPowerUp = transform.Find("PositionPowerUp").gameObject.GetComponent<Image>();
        thumbnail = transform.Find("ThumbnailMask/Thumbnail").gameObject.GetComponent<Image>();
        EnterDown = transform.Find("DirectionPowerUpArrows/EnterDown").gameObject.GetComponent<Image>();
        EnterDownLeft = transform.Find("DirectionPowerUpArrows/EnterDownLeft").gameObject.GetComponent<Image>();
        EnterLeft = transform.Find("DirectionPowerUpArrows/EnterLeft").gameObject.GetComponent<Image>();
        EnterUpLeft = transform.Find("DirectionPowerUpArrows/EnterUpLeft").gameObject.GetComponent<Image>();
        EnterUp = transform.Find("DirectionPowerUpArrows/EnterUp").gameObject.GetComponent<Image>();
        EnterUpRight = transform.Find("DirectionPowerUpArrows/EnterUpRight").gameObject.GetComponent<Image>();
        EnterRight = transform.Find("DirectionPowerUpArrows/EnterRight").gameObject.GetComponent<Image>();
        EnterDownRight = transform.Find("DirectionPowerUpArrows/EnterDownRight").gameObject.GetComponent<Image>();
        LeaveDown = transform.Find("DirectionPowerUpArrows/LeaveDown").gameObject.GetComponent<Image>();
        LeaveDownLeft = transform.Find("DirectionPowerUpArrows/LeaveDownLeft").gameObject.GetComponent<Image>();
        LeaveLeft = transform.Find("DirectionPowerUpArrows/LeaveLeft").gameObject.GetComponent<Image>();
        LeaveUpLeft = transform.Find("DirectionPowerUpArrows/LeaveUpLeft").gameObject.GetComponent<Image>();
        LeaveUp = transform.Find("DirectionPowerUpArrows/LeaveUp").gameObject.GetComponent<Image>();
        LeaveUpRight = transform.Find("DirectionPowerUpArrows/LeaveUpRight").gameObject.GetComponent<Image>();
        LeaveRight = transform.Find("DirectionPowerUpArrows/LeaveRight").gameObject.GetComponent<Image>();
        LeaveDownRight = transform.Find("DirectionPowerUpArrows/LeaveDownRight").gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        SetPositionPowerUp();
        SetDirectionPowerUp();
        SetIcon();
    }

    void SetIcon()
    {
        var SelfIcon = model.MagicField[position.y, position.x]?.GetIcon();
        SelfIcon ??= manager.DefaultlIcon;
        thumbnail.sprite = SelfIcon;
    }

    void SetPositionPowerUp()
    {
        if (model.HasPositionPowerUp(position))
        {
            positionPowerUp.color = Color.white;
        }
        else
        {
            positionPowerUp.color = new Color(0,0,0,0);
        }
    }

    void SetDirectionPowerUp()
    {
        DeleteAllArrow();
        var enterDirections = model.GetEnterPowerUpDirections(position);
        var leaveDirections = model.GetLeavePowerUpDirections(position);
        foreach(var enter in enterDirections)
        {
            DisplayEnterArrow(enter);
        }
        foreach(var leave in leaveDirections)
        {
            DisplayLeaveArrow(leave);
        }
    }

    void DeleteAllArrow()
    {
        EnterDown.color = new Color(0, 0, 0, 0);
        EnterDownLeft.color = new Color(0, 0, 0, 0);
        EnterDownRight.color = new Color(0, 0, 0, 0);
        EnterUp.color = new Color(0, 0, 0, 0);
        EnterUpRight.color = new Color(0, 0, 0, 0);
        EnterUpLeft.color = new Color(0, 0, 0, 0);
        EnterRight.color = new Color(0, 0, 0, 0);
        EnterLeft.color = new Color(0, 0, 0, 0);
        LeaveDown.color = new Color(0, 0, 0, 0);
        LeaveDownLeft.color = new Color(0, 0, 0, 0);
        LeaveDownRight.color = new Color(0, 0, 0, 0);
        LeaveUp.color = new Color(0, 0, 0, 0);
        LeaveUpRight.color = new Color(0, 0, 0, 0);
        LeaveUpLeft.color = new Color(0, 0, 0, 0);
        LeaveRight.color = new Color(0, 0, 0, 0);
        LeaveLeft.color = new Color(0, 0, 0, 0);
    }

    void DisplayEnterArrow(CardDirection direction)
    {
        switch (direction)
        {
            case CardDirection.down:
                EnterDown.color = Color.white;
                break;
            case CardDirection.down_left:
                EnterDownLeft.color = Color.white;
                break;
            case CardDirection.left:
                EnterLeft.color = Color.white;
                break;
            case CardDirection.up_left:
                EnterUpLeft.color = Color.white;
                break;
            case CardDirection.up:
                EnterUp.color = Color.white;
                break;
            case CardDirection.up_right:
                EnterUpRight.color = Color.white;
                break;
            case CardDirection.right:
                EnterRight.color = Color.white;
                break;
            case CardDirection.down_right:
                EnterDownRight.color = Color.white;
                break;
        }
    }

    void DisplayLeaveArrow(CardDirection direction)
    {
        switch (direction)
        {
            case CardDirection.down:
                LeaveDown.color = Color.white;
                break;
            case CardDirection.down_left:
                LeaveDownLeft.color = Color.white;
                break;
            case CardDirection.left:
                LeaveLeft.color = Color.white;
                break;
            case CardDirection.up_left:
                LeaveUpLeft.color = Color.white;
                break;
            case CardDirection.up:
                LeaveUp.color = Color.white;
                break;
            case CardDirection.up_right:
                LeaveUpRight.color = Color.white;
                break;
            case CardDirection.right:
                LeaveRight.color = Color.white;
                break;
            case CardDirection.down_right:
                LeaveDownRight.color = Color.white;
                break;
        }
    }
}
