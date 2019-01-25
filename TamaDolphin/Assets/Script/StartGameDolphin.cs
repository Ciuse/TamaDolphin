using System.Collections;
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

        buttonStart.SetActive(true);//TODO rimettere a false

        var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                myIp = ip.ToString();
                break;
            }
        }

        network.SetRealSamSetting(network.realSamManager.Configuration("changeHttp", myIp, 8081)); //TODO CONTROLLARE SE VA IL NUOVO IP
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
