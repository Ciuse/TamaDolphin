using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BavaglioOccur : MonoBehaviour
{
    public GameObject bavaglio;

   

    public void BavaglioOccurs()
    {
        if (bavaglio.activeSelf == false)
        {
            bavaglio.SetActive(true);
            Debug.Log("bavaglio attivata");
        }
    }
}
