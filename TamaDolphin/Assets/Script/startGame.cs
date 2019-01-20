using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    
    public GameObject buttonStart;
    public bool postRequestReceived;
    public ServerHttp server;
    public NetworkEventManager network;



    public void Startg()
    {
        buttonStart.SetActive(false);
    }

    public void Updateg()
    {
        if (server.clickButton)
        {
            buttonStart.SetActive(true);
        }
    }

    public void Start()
    {
        buttonStart.SetActive(false);
        network.SetRealSamSetting(network.realSamManager.Configuration("changeHttp", "a", 8081)); //TODO SISTEMARE L IP
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