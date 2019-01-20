﻿

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    
    public GameObject buttonStart;
    public bool postRequestReceived;
    public ServerHttp server;
    public NetworkEventManager network;

    public void Start()
    {
        SamInfo samInfo = new SamInfo();
        samInfo.samIp = "192.168.xxx.xxx";

        DataSaver.SaveData(samInfo, "samInfo");

        buttonStart.SetActive(true);//TODO rimettere a false

        network.SetRealSamSetting(network.realSamManager.Configuration("changeHttp", IPManager.GetLocalIPAddress(), 8081)); //TODO CONTROLLARE SE VA IL NUOVO IP
    }

    public void Update()
    {
        if (network.realSamManager.sendPost)
        {
            buttonStart.SetActive(true); 
            network.realSamManager.sendPost = false;
        }
    }

    public void PointerEnterStart()
    {
        StartCoroutine("PlayGame");
    }
    public void PointerExitNotStart()
    {
        StopCoroutine("PlayGame");
    }

    private IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Wait is over");
        SceneManager.LoadScene("SamScene");
       
    }

}

