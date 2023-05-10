using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZukanOrderCanvas : MonoBehaviour
{
    Toggle Descent;
    Toggle Ascent;
    Toggle Found;
    Toggle NotFound;
    Toggle Both;
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

    void Awake()
    {
        Descent = transform.Find("Order/Descent").gameObject.GetComponent<Toggle>();
        Ascent = transform.Find("Order/Ascent").gameObject.GetComponent<Toggle>();
        Ascent.isOn = true;
        Found = transform.Find("Status/Found").gameObject.GetComponent<Toggle>();
        NotFound = transform.Find("Status/NotFound").gameObject.GetComponent<Toggle>();
        Both = transform.Find("Status/Both").gameObject.GetComponent<Toggle>();
        Both.isOn = true;
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
    }

    public void Open()
    {
        MenuSESoundManager.Instance.PlayOK();
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

    public bool IsAscent()
    {
        return Ascent.isOn;
    }

    public SearchMode GetSearchMode()
    {
        if (Both.isOn)
        {
            return SearchMode.Both;
        }
        if (Found.isOn)
        {
            return SearchMode.Found;
        }
        if (NotFound.isOn)
        {
            return SearchMode.NotFound;
        }
        return SearchMode.Both;
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
}

public enum SearchMode
{
    Both, Found, NotFound
}