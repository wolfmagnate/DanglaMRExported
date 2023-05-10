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
    /// �g�p����V�[����null�ȊO�̃f�[�^�𑗂�B
    /// �L�[�̈�Ӑ��͕ۏ؂��ꂸ�A���ɃL�[�����݂���ꍇ�㏑������B
    /// </summary>
    /// <param name="destinationSceneName">�g�p����V�[����</param>
    /// <param name="key">�g�p����V�[���ɂ����Ĉ�ӂƂȂ�null�ȊO�̃A�N�Z�X�L�[</param>
    /// <param name="data">����f�[�^</param>
    public static void SendData(string destinationSceneName, string key, object data)
    {
        if (key == null || data == null)
            return;

        AddOrAppendData(CreateUniqueKey(destinationSceneName, key), data);
    }

    /// <summary>
    /// ����ꂽ�f�[�^���󂯎��B
    /// �L�[�����݂��Ȃ��ꍇ��null���Ԃ�B
    /// </summary>
    /// <param name="key">���M����ۂɎg�p�����L�[</param>
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