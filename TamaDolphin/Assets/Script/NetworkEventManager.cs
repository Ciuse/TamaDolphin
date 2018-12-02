using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkEventManager : MonoBehaviour
{
    public HttpPutRequest realSamManager;
    public HttpPutRequest therapistManager;
    public GameEventManager gameEventManager;
    public Object jsonHttpSetting;


    public void SetRealSamSetting()
    {
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

