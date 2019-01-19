using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Text;

public class HttpPostRequest : MonoBehaviour
{
    public bool sendPost=false;

    public void PostRequest(string jsonHttpSetting)
    {
        StartCoroutine(SendPostToSam(jsonHttpSetting));
    }

    private IEnumerator SendPostToSam(string jsonHttpSetting)
    {

        //  string json = jsonHttpSetting;
        // string urlSam = "http://192.168.0.125";
        //UnityWebRequest www = UnityWebRequest.Post(urlSam, json);
        // www.SetRequestHeader("Content-Type", "application/json");
        //yield return www.SendWebRequest();
        //Debug.Log("Impostazioni fatte");

        //if (www.isNetworkError || www.isHttpError)
        //{
        //   Debug.Log(www.error);
        //}
        //else
        //{

        //  sendPost = true;

        //}
        UnityWebRequest www = new UnityWebRequest("http://192.168.31.216", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonHttpSetting);
        www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();

        if (www.error != null)
        {
            Debug.Log("Erro: " + www.error);
        }
        else
        {
            sendPost = true;
            Debug.Log("All OK");
            Debug.Log("Status Code: " + www.responseCode);
        }

    }

    public string Configuration(string requestType, string ipTarget, int portTarget)
    {
        string stringa= "{\"requestType\":" + "\"" + requestType + "\"" + "," + "\"ipTarget\":" + "\"" + ipTarget + "\"" + "," + "\"portTarget\":" + portTarget + "}";
        Debug.Log(stringa);
        return stringa;
    }

    public string SetLights(string requestType, string color1, string color2, string color3, string color4, int intensità1, int intensità2, int intensità3, int intensità4 )
    {
         string lights = "{\"requestType\":" + "\"" + requestType + "\"" + "," + "\"lightControllerSetter\":[{\"code\":" + "\"" + "parthead" + "\"" + "," + "\"color\":" + "\"" + color1 + "\"" + "},{\"code\":" + "\"" + "partleftfin" + "\"" + "," + "\"color\":" + "\"" + color2 + "\"" + "},{\"code\":" + "\"" + "partrightfin" + "\"" + "," + "\"color\":" + "\"" + color3 + "\"" + "},{\"code\":" + "\"" + "partbelly" + "\"" + "," + "\"color\":" + "\"" + color4 + "\"" + "}]}";
        Debug.Log(lights);
        return lights;
    }

    public string SetMotors(string requestType, string type, int id, string direction, int speed, int duration)
    {
        string motor = "{\"requestType\":" + "\"" + requestType + "\"" + "," + "\"motorControllerSetter\":[{\"type\":" + "\"" + type + "\"" + "," + "\"id\":" + id + "," +"\"direction\":" + "\"" + direction + "\"" + "," + "\"speed\":" + speed + "," + "\"duration\":" + duration + "}]}";
        Debug.Log(motor);
        return motor;
    }

    public string SetSounds(string requestType, string type, int track,  int volume)
    {
        string motor = "{\"requestType\":" + "\"" + requestType + "\"" + "," + "\"soundControllerSetter\":[{\"type\":" + "\"" + type + "\"" + "," + "\"track\":" + track + "," + "\"volume\":"  + volume +  "}]}";
        Debug.Log(motor);
        return motor;
    }
}
