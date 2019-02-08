﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameDolphin : MonoBehaviour
{
    public GameObject buttonStart;
    public bool postRequestReceived;
    public ServerHttp server;
    public NetworkEventManager network;
    public string myIp;

    public void Start()
    {
        SamInfo samInfo = new SamInfo();
        samInfo.samIp = "192.168.xxx.xxx";

        DataSaver.SaveData(samInfo, "samInfo");

        buttonStart.SetActive(false);//TODO rimettere a false

        var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                myIp = ip.ToString();
                break;
            }
        }

        network.SetRealSamSetting(network.realSamManager.Configuration("changeHttp", myIp, 2601)); //invio messaggio per settare il mio ip a sam
    }

    public void Update()
    {
        if (network.realSamManager.sendPost)
        {
            buttonStart.SetActive(true);
            network.realSamManager.sendPost = false;
            network.SetRealSamSetting(network.realSamManager.SetLights("set", "#000000", "#000000", "#000000", "#000000"));

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
        SceneManager.LoadScene("SamScene");

    }

 
}
