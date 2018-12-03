using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HttpPutRequest : MonoBehaviour
{
    private string url= "192.168.0.125";

    public void PutRequest(string jsonHttpSetting)
    {
        StartCoroutine(ChangeHttpSetting(jsonHttpSetting));
    }

    IEnumerator ChangeHttpSetting(string jsonHttpSetting)
    {
        string json =jsonHttpSetting;
        byte[] myData = System.Text.Encoding.UTF8.GetBytes(json);
        UnityWebRequest www = UnityWebRequest.Post(url, myData);
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();
        Debug.Log("Impostazioni fatte");

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