using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFood : MonoBehaviour
{
    public GameObject targetFood;
    public Vector3 startPos;
    public Vector3 endPos;

    private Vector3 endMiddlePos;
    private Vector3 startMiddlePos;
    //Time to take from start to end
    public float lerpTime1 = 5;
    public float lerpTime2 = 10;

    //this will update the lerp time
    public float currentLerpTime1 = 0;
    public float currentLerpTime2 = 0;

    private void Start()
    {
        startPos = transform.position;
        endPos = targetFood.transform.position;

        endMiddlePos = startPos + new Vector3(0f, 8f, 0f);
        startMiddlePos = endMiddlePos;
    }

    private void Update()
    {
        currentLerpTime1 += Time.deltaTime;
        if (currentLerpTime1 >= lerpTime1)
        {
            currentLerpTime1 = lerpTime1;
        }
        else
        {
            float perc1 = currentLerpTime1 / lerpTime1;
            transform.position = Vector3.Lerp(startPos, endMiddlePos, perc1);
        }


        if (currentLerpTime1 == lerpTime1)
        {
            currentLerpTime2 += Time.deltaTime;
            if (currentLerpTime2 >= lerpTime2)
            {
                currentLerpTime2 = lerpTime2;
                Destroy(this);                  //TODO verificare se funziona e distrugge solo lo script
            }
            float perc2 = currentLerpTime2 / lerpTime2;
            transform.position = Vector3.Lerp(startMiddlePos, endPos, perc2);
        }
    }
}
