using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoadMagic
{
    public static readonly string PlayerPrefsKeyOfID = "__MagicID__";

    public static Magic Load(string loadID)
    {
        return JsonUtility.FromJson<Magic>(PlayerPrefs.GetString(loadID));
    }

    public static bool HasKey(string ID)
    {
        return PlayerPrefs.HasKey(ID);
    }

    public static Magic LoadFromServer(string loadID)
    {
        return JsonUtility.FromJson<Magic>(PlayerPrefs.GetString(loadID + "__from__server__"));
    }

    public static bool HasKeyFromServer(string ID)
    {
        return PlayerPrefs.HasKey(ID + "__from__server__");
    }

}
