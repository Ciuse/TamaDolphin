using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkEventManager : MonoBehaviour
{
    public HttpPutRequest realSamManager;
    public HttpPutRequest therapistManager;
    public GameEventManager gameEventManager;
    // public string jsonHttpSetting;

    void Start()
    {
        SetRealSamSetting();
    }

    public void SetRealSamSetting()
    {
        string jsonHttpSetting = "{\"requestType\":\"changeHttp\",\"ipTarget\":\"192.168.0.103\",\"portTarget\":8081}";

        realSamManager.PutRequest(jsonHttpSetting);
    }

    public void HandleSamCardRead(string cardIdRead)
    {
        gameEventManager.SetInputStateRealSam(cardIdRead);

    }

    public void HandleWebButtonPressed(string buttonPressedId)
    {
        gameEventManager.SetInputStateTherapist(buttonPressedId);

    }
}

