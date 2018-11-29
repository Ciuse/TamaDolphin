using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HttpPutRequest : MonoBehaviour
{
    public string url;
    public Object jsonHttpSetting;
    public void Request()
    {
        StartCoroutine(ChangeHttpSetting());
    }

    IEnumerator ChangeHttpSetting()
    {
        string json = JsonUtility.ToJson(jsonHttpSetting);
        byte[] myData = System.Text.Encoding.UTF8.GetBytes(json);
        UnityWebRequest www = UnityWebRequest.Put(url, myData);
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

            //DO Something

        }
    }
}