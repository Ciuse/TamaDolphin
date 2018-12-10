using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;


public class HttpPostRequest : MonoBehaviour
{
    public bool sendPost=false;

    public void PostRequest(string jsonHttpSetting)
    {
        StartCoroutine(SendPostToSam(jsonHttpSetting));
    }

    private IEnumerator SendPostToSam(string jsonHttpSetting)
    {
        
        string json = jsonHttpSetting;
        string url = "http://192.168.0.125";
        UnityWebRequest www = UnityWebRequest.Post(url, json);
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();
        Debug.Log("Impostazioni fatte");

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

            sendPost = true;

        }

    }

    public string Configuration(string requestType, string ipTarget, int portTarget)
    {
        string stringa= "{\"requestType\":" + "\"" + requestType + "\"" + "," + "\"ipTarget\":" + "\"" + ipTarget + "\"" + "," + "\"portTarget\":" + portTarget + "}";
        Debug.Log(stringa);
        return stringa;
    }

    public string SetLights(string requestType, string code1, string color1, string code2, string color2, string code3, string color3, string code4, string color4)
    {
        return "{\"requestType\":" + requestType + "," + "\"lightControllerSetter\":[{\"code\":" + code1 + "," + "\"color\":" + color1 + "},{\"code\":" + code2 + "," + "\"color\":" + color2 + "},{\"code\":" + code3 + "," + "\"color\":" + color3 + "},{\"code\":" + code4 + "," + "\"color\":" + color4 + "}]}";
    }

    public string SetMotors(string requestType, string type, string id, string direction, string speed, string duration)
    {
        return "{\"requestType\":" + requestType + "," + "\"motorControllerSetter\":[{\"type\":" + type + "," + "\"id\":" + id + "," +"\"direction\":" + direction + "," + "\"speed\":" + speed + "," + "\"duration\":" + duration + "}]}";
    }
}
