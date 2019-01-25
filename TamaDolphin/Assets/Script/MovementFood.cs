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
    public float lerpTime1;
    public float lerpTime2;

    //this will update the lerp time
    public float currentLerpTime1;
    public float currentLerpTime2;

    public bool positionSetted;

    private void Start()
    {

    }

    private void Update()
    {
        if (positionSetted == true)
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
                    positionSetted = false;
                    this.enabled = false;
                }
                float perc2 = currentLerpTime2 / lerpTime2;
                transform.position = Vector3.Lerp(startMiddlePos, endPos, perc2);
            }
        }

    }
    public void SetMoveToDolphin()
    {
        currentLerpTime1 = 0;
        currentLerpTime2 = 0;

        lerpTime1 = 5;
        lerpTime2 = 10;

        startPos = transform.position;

        endMiddlePos = startPos + new Vector3(0f, 8f, 0f);
        startMiddlePos = endMiddlePos;

        endPos = targetFood.transform.position;
        positionSetted = true;
    }

    public void SetMoveBackToBucket(Vector3 bucketPosition)
    {

        currentLerpTime1 = 0;
        currentLerpTime2 = 0;

        lerpTime1 = 10;
        lerpTime2 = 5;

        startPos = transform.position;

        endMiddlePos = bucketPosition + new Vector3(0f, 8f, 0f);
        startMiddlePos = endMiddlePos;

        endPos = bucketPosition;
        positionSetted = true;

    }

    public void SetMoveFromDolphinToDish(Vector3 dishPosition)
    {

        currentLerpTime1 = 0;
        currentLerpTime2 = 0;

        lerpTime1 = 10;
        lerpTime2 = 1;

        startPos = transform.position;

        endMiddlePos = dishPosition;
        startMiddlePos = endMiddlePos;

        endPos = dishPosition;
        positionSetted = true;

    }

    public void SetMoveFromDolphinToBin(Vector3 binPosition)
    {

        currentLerpTime1 = 0;
        currentLerpTime2 = 0;

        lerpTime1 = 10;
        lerpTime2 = 5;

        startPos = transform.position;

        endMiddlePos = binPosition + new Vector3(0f, 13f, 0f); ;
        startMiddlePos = endMiddlePos;

        endPos = binPosition;
        positionSetted = true;

    }

    public void SetPositionSingleFoodAtTop(GameObject food)
    {
       
        currentLerpTime1 = 0;
        lerpTime1 = 5;
        lerpTime2 = 1;
        startPos = food.transform.position;
        endMiddlePos = food.transform.position + new Vector3(0f, 1.4f, 0f) ;
        endPos = food.transform.position + new Vector3(0f, 1.4f, 0f);
        startMiddlePos = endMiddlePos;
        positionSetted = true;
       
    }

    public void ReturnBackSingleFood(GameObject food)
    {
        
        currentLerpTime1 = 0;
        lerpTime1 = 5;
        lerpTime2 = 1;
        startPos = food.transform.position;
        endMiddlePos = food.transform.position + new Vector3(0f, -1.4f, 0f);
        endPos = food.transform.position + new Vector3(0f, -1.4f, 0f);
        startMiddlePos = endMiddlePos;
        positionSetted = true;

    }

   
}
