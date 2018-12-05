using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudOccurs : MonoBehaviour {

    public Transform Spawnpoint;
    public GameObject Cloud;

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
        Instantiate(Cloud, Spawnpoint.position, Spawnpoint.rotation);

    }
}
