using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public static class CallAPI
{
    public static readonly string URL = "160.251.16.133";
    public static readonly int Port = 57575;

    public static void SendMagic(Magic magic, UnityAction<string> OnFailed, UnityAction<string> OnSuccess)
    {
        CoroutineHandler.StartStaticCoroutine(Send(magic, OnFailed, OnSuccess));
    }

    public static void GetMagicByID(string id, UnityAction<string> OnFailed, UnityAction<string> OnSuccess)
    {
        CoroutineHandler.StartStaticCoroutine(SearchByID(id, OnFailed, OnSuccess));
    }

    private static IEnumerator Send(Magic magic, UnityAction<string> OnFailed, UnityAction<string> OnSuccess)
    {
        string jsonstring = JsonUtility.ToJson(magic);
        byte[] rawData = Encoding.UTF8.GetBytes(jsonstring);
        UnityWebRequest webRequest = new UnityWebRequest($"http://{URL}:{Port}/medicine", "POST");
        //jsonを設定
        webRequest.uploadHandler = new UploadHandlerRaw(rawData);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        //ヘッダーにタイプを設定
        webRequest.SetRequestHeader("Content-Type", "application/json");
        yield return webRequest.SendWebRequest();
        switch (webRequest.result)
        {
            case UnityWebRequest.Result.Success:
                string id = webRequest.downloadHandler.text;
                OnSuccess.Invoke(id);
                break;
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
            case UnityWebRequest.Result.ProtocolError:
                OnFailed(webRequest.error);
                break;
        }
    }

    private static IEnumerator SearchByID(string id, UnityAction<string> OnFailed, UnityAction<string> OnSuccess)
    {
        if (! Regex.IsMatch(id, "[a-z0-9]{24}")) { Debug.Log("不正なID"); yield break; }
        
        UnityWebRequest webRequest = new UnityWebRequest($"http://{URL}:{Port}/medicine/{id}", "GET");
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        yield return webRequest.SendWebRequest();
        switch (webRequest.result)
        {
            case UnityWebRequest.Result.Success:
                string jsontext = webRequest.downloadHandler.text;
                OnSuccess.Invoke(jsontext);
                break;
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
            case UnityWebRequest.Result.ProtocolError:
                OnFailed(webRequest.error);
                break;
        }
    }
}
