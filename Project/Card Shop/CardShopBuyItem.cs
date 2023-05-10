using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CardShopBuyItem : MonoBehaviour
{
    Toggle toggle;
    MagicCard item;
    Image icon;

    void Start()
    {
    }

    public bool IsSelected => toggle.isOn;

    public void SetItemData(MagicCard magicCard)
    {
        item = magicCard;
        icon = transform.Find("Thumbnail Mask/Thumbnail").gameObject.GetComponent<Image>();
        icon.sprite = item.GetIcon();
    }

    public int GetPrice => item.BuyPrice;

    public MagicCard GetCard => item;

    public void SetSelectedEvent(Action<int> selectedEvent)
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener((bool value) =>
        {
            if (value) { selectedEvent.Invoke(GetPrice); }
        });
    }

    public void SetUnselectedEvent(Action<int> unselectedEvent)
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener((bool value) =>
        {
            if (!value) { unselectedEvent.Invoke(GetPrice); }
        });
    }
}
