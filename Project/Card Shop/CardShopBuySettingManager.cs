using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardShopBuySettingManager : MonoBehaviour
{
    Toggle Fire;
    Toggle Water;
    Toggle Tree;
    Toggle Light;
    Toggle Lightning;
    Toggle Ice;
    Toggle Darkness;
    Toggle Mountain;
    Toggle Wind;
    Toggle Metal;
    Toggle Nothing;

    Toggle Experimental;
    Toggle Freedom;
    Toggle Connection;
    Toggle Position;
    Toggle Number;
    Toggle Cheat;
    Toggle Order;
    Toggle Direction;

    Toggle Both;
    Toggle NotFound;
    Toggle Found;
    // Start is called before the first frame update
    void Start()
    {
        Fire = transform.Find("Attribute/Scroll View/Viewport/Content/Fire").gameObject.GetComponent<Toggle>();
        Water = transform.Find("Attribute/Scroll View/Viewport/Content/Water").gameObject.GetComponent<Toggle>();
        Tree = transform.Find("Attribute/Scroll View/Viewport/Content/Tree").gameObject.GetComponent<Toggle>();
        Light = transform.Find("Attribute/Scroll View/Viewport/Content/Light").gameObject.GetComponent<Toggle>();
        Lightning = transform.Find("Attribute/Scroll View/Viewport/Content/Lightning").gameObject.GetComponent<Toggle>();
        Ice = transform.Find("Attribute/Scroll View/Viewport/Content/Ice").gameObject.GetComponent<Toggle>();
        Darkness = transform.Find("Attribute/Scroll View/Viewport/Content/Darkness").gameObject.GetComponent<Toggle>();
        Mountain = transform.Find("Attribute/Scroll View/Viewport/Content/Mountain").gameObject.GetComponent<Toggle>();
        Wind = transform.Find("Attribute/Scroll View/Viewport/Content/Wind").gameObject.GetComponent<Toggle>();
        Metal = transform.Find("Attribute/Scroll View/Viewport/Content/Metal").gameObject.GetComponent<Toggle>();
        Nothing = transform.Find("Attribute/Scroll View/Viewport/Content/Nothing").gameObject.GetComponent<Toggle>();

        Experimental = transform.Find("Standard/Scroll View/Viewport/Content/Experimental").gameObject.GetComponent<Toggle>();
        Freedom = transform.Find("Standard/Scroll View/Viewport/Content/Freedom").gameObject.GetComponent<Toggle>();
        Connection = transform.Find("Standard/Scroll View/Viewport/Content/Connection").gameObject.GetComponent<Toggle>();
        Position = transform.Find("Standard/Scroll View/Viewport/Content/Position").gameObject.GetComponent<Toggle>();
        Number = transform.Find("Standard/Scroll View/Viewport/Content/Number").gameObject.GetComponent<Toggle>();
        Cheat = transform.Find("Standard/Scroll View/Viewport/Content/Cheat").gameObject.GetComponent<Toggle>();
        Order = transform.Find("Standard/Scroll View/Viewport/Content/Order").gameObject.GetComponent<Toggle>();
        Direction = transform.Find("Standard/Scroll View/Viewport/Content/Direction").gameObject.GetComponent<Toggle>();

        Both = transform.Find("Status/Both").gameObject.GetComponent<Toggle>();
        NotFound = transform.Find("Status/NotFound").gameObject.GetComponent<Toggle>();
        Found = transform.Find("Status/Found").gameObject.GetComponent<Toggle>();

        GetComponent<Canvas>().sortingOrder = -1;
    }

    public List<MagicAttribute> GetAttributes()
    {
        List<MagicAttribute> ans = new List<MagicAttribute>();
        if (Fire.isOn)
        {
            ans.Add(MagicAttribute.Fire);
        }
        if (Water.isOn)
        {
            ans.Add(MagicAttribute.Water);
        }
        if (Wind.isOn)
        {
            ans.Add(MagicAttribute.Wind);
        }
        if (Mountain.isOn)
        {
            ans.Add(MagicAttribute.Mountain);
        }
        if (Light.isOn)
        {
            ans.Add(MagicAttribute.Light);
        }
        if (Lightning.isOn)
        {
            ans.Add(MagicAttribute.Lightning);
        }
        if (Darkness.isOn)
        {
            ans.Add(MagicAttribute.Darkness);
        }
        if (Metal.isOn)
        {
            ans.Add(MagicAttribute.Metal);
        }
        if (Nothing.isOn)
        {
            ans.Add(MagicAttribute.Nothing);
        }
        if (Ice.isOn)
        {
            ans.Add(MagicAttribute.Ice);
        }
        if (Tree.isOn)
        {
            ans.Add(MagicAttribute.Tree);
        }
        return ans;
    }

    public SearchMode GetSearchMode()
    {
        if (Both.isOn)
        {
            return SearchMode.Both;
        }
        if (NotFound.isOn)
        {
            return SearchMode.NotFound;
        }
        if (Found.isOn)
        {
            return SearchMode.Found;
        }
        return SearchMode.Both;
    }

    public List<CardRace> GetCardRaces()
    {
        List<CardRace> ans = new List<CardRace>();
        if (Connection.isOn)
        {
            ans.Add(CardRace.connection);
        }
        if (Cheat.isOn)
        {
            ans.Add(CardRace.cheat);
        }
        if (Direction.isOn)
        {
            ans.Add(CardRace.direction);
        }
        if (Number.isOn)
        {
            ans.Add(CardRace.number);
        }
        if (Position.isOn)
        {
            ans.Add(CardRace.position);
        }
        if (Order.isOn)
        {
            ans.Add(CardRace.order);
        }
        if (Position.isOn)
        {
            ans.Add(CardRace.position);
        }
        if (Experimental.isOn)
        {
            ans.Add(CardRace.experimental);
        }
        if (Freedom.isOn)
        {
            ans.Add(CardRace.freedom);
        }
        return ans;
    }

    public void Open()
    {
        GetComponent<Canvas>().sortingOrder = 1;
    }

    public void Close()
    {
        GetComponent<Canvas>().sortingOrder = -1;
    }
}
