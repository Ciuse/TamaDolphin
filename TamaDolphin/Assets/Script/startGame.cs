using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
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
        network.SetRealSamSetting(network.realSamManager.Configuration("changeHttp", Network.player.ipAddress, 8081));
  
    }

    public void Update()
    {
        if (network.realSamManager.sendPost)
        {
            buttonStart.SetActive(true);
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
        yield return new WaitForSeconds(5);
        Debug.Log("Wait is over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }

}