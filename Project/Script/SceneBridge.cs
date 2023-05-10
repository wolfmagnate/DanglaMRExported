using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneBridge
{
    #region
    private static Dictionary<string, object> Data { get; } = new Dictionary<string, object>();

    private static string CreateUniqueKey(string destinationSceneName, string plainKey)
    {
        return $"{destinationSceneName}_{plainKey}";
    }

    private static void AddOrAppendData(string key, object data)
    {
        if (!Data.ContainsKey(key))
        {
            Data.Add(key, data);
        }
        else
        {
            Data.Remove(key);
            Data.Add(key, data);
        }
    }
    #endregion

    /// <summary>
    /// 使用するシーンにnull以外のデータを送る。
    /// キーの一意制は保証されず、既にキーが存在する場合上書きする。
    /// </summary>
    /// <param name="destinationSceneName">使用するシーン名</param>
    /// <param name="key">使用するシーンにおいて一意となるnull以外のアクセスキー</param>
    /// <param name="data">送るデータ</param>
    public static void SendData(string destinationSceneName, string key, object data)
    {
        if (key == null || data == null)
            return;

        AddOrAppendData(CreateUniqueKey(destinationSceneName, key), data);
    }

    /// <summary>
    /// 送られたデータを受け取る。
    /// キーが存在しない場合はnullが返る。
    /// </summary>
    /// <param name="key">送信する際に使用したキー</param>
    /// <returns></returns>
    public static object ReceiveData(string key)
    {
        var uniqueKey = CreateUniqueKey(SceneManager.GetActiveScene().name, key);

        if (Data.ContainsKey(uniqueKey))
        {
            return Data[uniqueKey];
        }
        else
        {
            return null;
        }
    }
}