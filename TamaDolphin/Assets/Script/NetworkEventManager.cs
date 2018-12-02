using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkEventManager : MonoBehaviour
{
    public HttpPutRequest realSamManager;
    public HttpPutRequest therapistManager;
    public GameEventManager gameEventManager;
    public Object jsonHttpSetting;

    public void setRealSamSetting()
    {
        realSamManager.PutRequest(jsonHttpSetting);
    }
}

