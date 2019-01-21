using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CestiniOccurs : MonoBehaviour
{
    public GameObject firstCestino;
    public GameObject secondCestino;
    public GameObject thirdCestino;
    public GameObject fourthCestino;
    public bool cestiniAttivati = false;

    


    private void CestiniOccur()
    {
       
        
        firstCestino.SetActive(true);
        secondCestino.SetActive(true);
        thirdCestino.SetActive(true);
        fourthCestino.SetActive(true);
        cestiniAttivati = true;
        Debug.Log("cestini attivati");
        


    }
}
