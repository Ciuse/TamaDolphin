using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkEventManager : MonoBehaviour
{
    public GameEventManager gameEventManager;
    public HttpPostRequest realSamManager;
    public HttpPostRequest therapistWebManager;
    // public string jsonHttpSetting;

    void Start()
    {

    }

    public void SetRealSamSetting(string request)
    {
        realSamManager.bufferPost.Add(request);

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

