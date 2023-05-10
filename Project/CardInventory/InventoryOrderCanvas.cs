using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryOrderCanvas : MonoBehaviour
{
    Toggle Fire;
    Toggle Water;
    Toggle Ice;
    Toggle Tree;
    Toggle Mountain;
    Toggle Metal;
    Toggle Lightning;
    Toggle Light;
    Toggle Darkness;
    Toggle Wind;
    Toggle Nothing;

    Toggle Experimental;
    Toggle Freedom;
    Toggle Connection;
    Toggle Position;
    Toggle Number;
    Toggle Cheat;
    Toggle Order;
    Toggle Direction;

    void Awake()
    {
        Fire = transform.Find("Attribute/Scroll View/Viewport/Content/Fire").gameObject.GetComponent<Toggle>();
        Fire.isOn = true;
        Water = transform.Find("Attribute/Scroll View/Viewport/Content/Water").gameObject.GetComponent<Toggle>();
        Water.isOn = true;
        Ice = transform.Find("Attribute/Scroll View/Viewport/Content/Ice").gameObject.GetComponent<Toggle>();
        Ice.isOn = true;
        Tree = transform.Find("Attribute/Scroll View/Viewport/Content/Tree").gameObject.GetComponent<Toggle>();
        Tree.isOn = true;
        Mountain = transform.Find("Attribute/Scroll View/Viewport/Content/Mountain").gameObject.GetComponent<Toggle>();
        Mountain.isOn = true;
        Light = transform.Find("Attribute/Scroll View/Viewport/Content/Light").gameObject.GetComponent<Toggle>();
        Light.isOn = true;
        Lightning = transform.Find("Attribute/Scroll View/Viewport/Content/Lightning").gameObject.GetComponent<Toggle>();
        Lightning.isOn = true;
        Darkness = transform.Find("Attribute/Scroll View/Viewport/Content/Darkness").gameObject.GetComponent<Toggle>();
        Darkness.isOn = true;
        Wind = transform.Find("Attribute/Scroll View/Viewport/Content/Wind").gameObject.GetComponent<Toggle>();
        Wind.isOn = true;
        Metal = transform.Find("Attribute/Scroll View/Viewport/Content/Metal").gameObject.GetComponent<Toggle>();
        Metal.isOn = true;
        Nothing = transform.Find("Attribute/Scroll View/Viewport/Content/Nothing").gameObject.GetComponent<Toggle>();
        Nothing.isOn = true;

        Experimental = transform.Find("Standard/Scroll View/Viewport/Content/Experimental").gameObject.GetComponent<Toggle>();
        Freedom = transform.Find("Standard/Scroll View/Viewport/Content/Experimental").gameObject.GetComponent<Toggle>();
        Connection = transform.Find("Standard/Scroll View/Viewport/Content/Connection").gameObject.GetComponent<Toggle>();
        Position = transform.Find("Standard/Scroll View/Viewport/Content/Position").gameObject.GetComponent<Toggle>();
        Number = transform.Find("Standard/Scroll View/Viewport/Content/Number").gameObject.GetComponent<Toggle>();
        Cheat = transform.Find("Standard/Scroll View/Viewport/Content/Cheat").gameObject.GetComponent<Toggle>();
        Order = transform.Find("Standard/Scroll View/Viewport/Content/Order").gameObject.GetComponent<Toggle>();
        Direction = transform.Find("Standard/Scroll View/Viewport/Content/Direction").gameObject.GetComponent<Toggle>();
    }

    public void Open()
    {
        GetComponent<Canvas>().sortingOrder = 1;
    }

    public void Close()
    {
        MenuSESoundManager.Instance.PlayCancel();
        GetComponent<Canvas>().sortingOrder = -1;
    }

    private void Start()
    {
        GetComponent<Canvas>().sortingOrder = -1;
    }

    public List<MagicAttribute> GetDisplayAttributes()
    {
        List<MagicAttribute> attributes = new List<MagicAttribute>();
        if (Fire.isOn)
        {
            attributes.Add(MagicAttribute.Fire);
        }
        if (Water.isOn)
        {
            attributes.Add(MagicAttribute.Water);
        }
        if (Tree.isOn)
        {
            attributes.Add(MagicAttribute.Tree);
        }
        if (Ice.isOn)
        {
            attributes.Add(MagicAttribute.Ice);
        }
        if (Mountain.isOn)
        {
            attributes.Add(MagicAttribute.Mountain);
        }
        if (Light.isOn)
        {
            attributes.Add(MagicAttribute.Light);
        }
        if (Lightning.isOn)
        {
            attributes.Add(MagicAttribute.Lightning);
        }
        if (Darkness.isOn)
        {
            attributes.Add(MagicAttribute.Darkness);
        }
        if (Metal.isOn)
        {
            attributes.Add(MagicAttribute.Metal);
        }
        if (Wind.isOn)
        {
            attributes.Add(MagicAttribute.Wind);
        }
        if (Nothing.isOn)
        {
            attributes.Add(MagicAttribute.Nothing);
        }
        return attributes;
    }

    public List<CardRace> GetCardRaces()
    {
        var retVal = new List<CardRace>();
        if (Freedom.isOn)
        {
            retVal.Add(CardRace.freedom);
        }
        if (Cheat.isOn)
        {
            retVal.Add(CardRace.cheat);
        }
        if (Connection.isOn)
        {
            retVal.Add(CardRace.connection);
        }
        if (Direction.isOn)
        {
            retVal.Add(CardRace.direction);
        }
        if (Experimental.isOn)
        {
            retVal.Add(CardRace.experimental);
        }
        if (Order.isOn)
        {
            retVal.Add(CardRace.order);
        }
        if (Number.isOn)
        {
            retVal.Add(CardRace.number);
        }
        if (Position.isOn)
        {
            retVal.Add(CardRace.position);
        }
        return retVal;
    }
}
