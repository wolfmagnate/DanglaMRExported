using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class SaveMagic
{
    public static void Save(Magic magic, string saveID)
    {
        // –{‘Ì‚Ì•Û‘¶
        string jsoned = JsonUtility.ToJson(magic);
        PlayerPrefs.SetString(saveID, jsoned);
    }


    public static void SaveFromServer(Magic magic, string saveID)
    {
        string jsoned = JsonUtility.ToJson(magic);
        PlayerPrefs.SetString(saveID + "__from__server__", jsoned);
    }
}
