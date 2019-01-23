using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Text;
using System.Collections.Generic;

public class HttpPostRequest : MonoBehaviour
{
    public bool sendPost=false;
    private string samIp;
    public List<string> bufferPost = new List<string>();
    public Coroutine sendingPost;
    private void Start()
    {
        SamInfo loadedData = DataSaver.LoadData<SamInfo>("samInfo");
        samIp = loadedData.samIp;
        sendingPost = null;
    }

    void Update()
    {
        if (Time.frameCount % 60 == 0)
        {
            if (bufferPost.Count > 0)
            {
                if (sendingPost == null)
                {
                    PostRequest(bufferPost[0]);
                    bufferPost.Remove(bufferPost[0]);
                }
            }
        }
    }
    public void PostRequest(string jsonHttpSetting)
    {
        sendingPost=StartCoroutine(SendPostToSam(jsonHttpSetting));
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


        UnityWebRequest www = new UnityWebRequest(samIp, "POST");  //TODO VEDERE SE VA DAVVERO IL SAM IP
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

        sendingPost = null;

    }

    public string Configuration(string requestType, string ipTarget, int portTarget)
    {
        string stringa= "{\"requestType\":" + "\"" + requestType + "\"" + "," + "\"ipTarget\":" + "\"" + ipTarget + "\"" + "," + "\"portTarget\":" + portTarget + "}";
        Debug.Log(stringa);
        return stringa;
    }

    public string SetLights(string requestType, string color1, string color2, string color3, string color4 )
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
