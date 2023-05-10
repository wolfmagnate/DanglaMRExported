using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCardsSettingsManager : MonoBehaviour
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

    Toggle Straight;
    Toggle Gatling;
    Toggle Spread;
    Toggle Wave;
    Toggle Sphere;
    Toggle Ray;

    public void Open()
    {
        GetComponent<Canvas>().sortingOrder = 1;
    }

    public void Close()
    {
        GetComponent<Canvas>().sortingOrder = -1;
    }

    void Start()
    {
        Fire = transform.Find("Attribute/Scroll View/Viewport/Content/Fire").gameObject.GetComponent<Toggle>();
        Water = transform.Find("Attribute/Scroll View/Viewport/Content/Water").gameObject.GetComponent<Toggle>();
        Tree = transform.Find("Attribute/Scroll View/Viewport/Content/Tree").gameObject.GetComponent<Toggle>();
        Light = transform.Find("Attribute/Scroll View/Viewport/Content/Light").gameObject.GetComponent<Toggle>();
        Lightning = transform.Find("Attribute/Scroll View/Viewport/Content/Lightning").gameObject.GetComponent<Toggle>();
        Darkness = transform.Find("Attribute/Scroll View/Viewport/Content/Darkness").gameObject.GetComponent<Toggle>();
        Ice = transform.Find("Attribute/Scroll View/Viewport/Content/Ice").gameObject.GetComponent<Toggle>();
        Mountain = transform.Find("Attribute/Scroll View/Viewport/Content/Mountain").gameObject.GetComponent<Toggle>();
        Wind = transform.Find("Attribute/Scroll View/Viewport/Content/Wind").gameObject.GetComponent<Toggle>();
        Metal = transform.Find("Attribute/Scroll View/Viewport/Content/Metal").gameObject.GetComponent<Toggle>();
        Nothing = transform.Find("Attribute/Scroll View/Viewport/Content/Nothing").gameObject.GetComponent<Toggle>();

        Experimental = transform.Find("Standard/Scroll View/Viewport/Content/Experimental").gameObject.GetComponent<Toggle>();
        Freedom = transform.Find("Standard/Scroll View/Viewport/Content/Experimental").gameObject.GetComponent<Toggle>();
        Connection = transform.Find("Standard/Scroll View/Viewport/Content/Connection").gameObject.GetComponent<Toggle>();
        Position = transform.Find("Standard/Scroll View/Viewport/Content/Position").gameObject.GetComponent<Toggle>();
        Number = transform.Find("Standard/Scroll View/Viewport/Content/Number").gameObject.GetComponent<Toggle>();
        Cheat = transform.Find("Standard/Scroll View/Viewport/Content/Cheat").gameObject.GetComponent<Toggle>();
        Order = transform.Find("Standard/Scroll View/Viewport/Content/Order").gameObject.GetComponent<Toggle>();
        Direction = transform.Find("Standard/Scroll View/Viewport/Content/Direction").gameObject.GetComponent<Toggle>();

        Straight = transform.Find("MoveType/Scroll View/Viewport/Content/Straight").gameObject.GetComponent<Toggle>();
        Gatling = transform.Find("MoveType/Scroll View/Viewport/Content/Gatling").gameObject.GetComponent<Toggle>();
        Spread = transform.Find("MoveType/Scroll View/Viewport/Content/Spread").gameObject.GetComponent<Toggle>();
        Wave = transform.Find("MoveType/Scroll View/Viewport/Content/Wave").gameObject.GetComponent<Toggle>();
        Sphere = transform.Find("MoveType/Scroll View/Viewport/Content/Sphere").gameObject.GetComponent<Toggle>();
        Ray = transform.Find("MoveType/Scroll View/Viewport/Content/Ray").gameObject.GetComponent<Toggle>();

        Close();
    }

    public List<MagicAttribute> GetAttributes()
    {
        var ans = new List<MagicAttribute>();
        if (Fire.isOn)
        {
            ans.Add(MagicAttribute.Fire);
        }
        if (Darkness.isOn)
        {
            ans.Add(MagicAttribute.Darkness);
        }
        if (Metal.isOn)
        {
            ans.Add(MagicAttribute.Metal);
        }
        if (Water.isOn)
        {
            ans.Add(MagicAttribute.Water);
        }
        if (Wind.isOn)
        {
            ans.Add(MagicAttribute.Wind);
        }
        if (Light.isOn)
        {
            ans.Add(MagicAttribute.Light);
        }
        if (Lightning.isOn)
        {
            ans.Add(MagicAttribute.Lightning);
        }
        if (Ice.isOn)
        {
            ans.Add(MagicAttribute.Ice);
        }
        if (Mountain.isOn)
        {
            ans.Add(MagicAttribute.Mountain);
        }
        if (Tree.isOn)
        {
            ans.Add(MagicAttribute.Tree);
        }
        if (Nothing.isOn)
        {
            ans.Add(MagicAttribute.Nothing);
        }
        return ans;
    }

    public List<MoveType> GetMoveTypes()
    {
        var ans = new List<MoveType>();
        if (Straight.isOn)
        {
            ans.Add(MoveType.straight);
        }
        if (Gatling.isOn)
        {
            ans.Add(MoveType.gatling);
        }
        if (Spread.isOn)
        {
            ans.Add(MoveType.spread);
        }
        if (Sphere.isOn)
        {
            ans.Add(MoveType.sphere);
        }
        if (Ray.isOn)
        {
            ans.Add(MoveType.ray);
        }
        if (Wave.isOn)
        {
            ans.Add(MoveType.wave);
        }
        return ans;
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
