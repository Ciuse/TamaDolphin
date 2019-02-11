using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinInteraction : MonoBehaviour
{

    public GameObject cloud;
    public GameObject planeCloud;
    public GameObject planeCloud2;
    public GameObject table;
    public GameObject bavaglio;
    public bool inizioSuggerimento;
    public int i = 0;
    List<GameObject> needAdvicesList = new List<GameObject>();
    List<GameObject> advicesActivatedList = new List<GameObject>();


    public void Start()
    {
        cloud.SetActive(false);
        inizioSuggerimento = false;
        needAdvicesList.Add(planeCloud);
        needAdvicesList.Add(table);
        needAdvicesList.Add(planeCloud2);
        foreach (GameObject item in needAdvicesList)
        {
            item.SetActive(false);
        }
    }


    public void Suggerimenti()
    {
        StartCoroutine(SuggerimentiAsync());
    }

    public void StopSuggerimenti()
    {
        StopAllCoroutines();
    }

    public IEnumerator SuggerimentiAsync()
    {

        foreach (GameObject item in needAdvicesList)
        {

            foreach (GameObject advice in advicesActivatedList)
            {
                if (item.transform.parent != null && advice.transform.parent != null && item.transform.parent.tag == "Cloud" && advice.transform.parent.tag == "Cloud")
                {
                    advice.SetActive(false);
                    yield return new WaitForSeconds(1f);
                }
            }

            item.SetActive(true);
            if (item.name == "Table")
            {
                item.GetComponent<MovementTable>().enabled = false;
            }
            yield return new WaitForSeconds(5f);
            advicesActivatedList.Add(item);
        }
    }

    public void Appear()
    {
        if (cloud != null)
        {
            if (cloud.activeSelf == false)
            {
                StartCoroutine("CloudOccur");

            }
        }
    }


    public void Disappear()
    {

        if (cloud != null)
        {
            if (cloud.activeSelf == false)
            {
                StopCoroutine("CloudOccur");
            }
        }
    }


    private IEnumerator CloudOccur()
    {
        yield return new WaitForSeconds(4);

        cloud.SetActive(true);
        Suggerimenti();
    }

}

