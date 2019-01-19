using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudOccurs : MonoBehaviour {

    public GameObject cloud;
    public GameObject planeCloud;
    public GameObject textMeshPro;
    public GameObject table;
    List<GameObject> needAdvicesList = new List<GameObject>();

    public void Start()
    {
        cloud.SetActive(false);
        planeCloud.SetActive(false);
        textMeshPro.SetActive(false);
       

    }

    public void Appear()
    {
        StartCoroutine("CloudOccur");
    }
    public void Disappear()
    {
        StopCoroutine("CloudOccur");
    }


    private IEnumerator CloudOccur()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Wait is over");
        cloud.SetActive(true);
        planeCloud.SetActive(true);
        
        
    }

   
}
