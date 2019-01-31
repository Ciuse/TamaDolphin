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

    public bool positionSetted =false ;

    public bool foodMovedToDolphin=false ;

    public bool destroyBucket = false;

    public GameObject parentToDestroy;

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
                    if(destroyBucket == true && transform.parent != null)
                    {
                        parentToDestroy = transform.parent.gameObject;
                        transform.parent = null;
                        Destroy(parentToDestroy);
                        gameObject.name = gameObject.name + "Bin";
                    }
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
        foodMovedToDolphin = true;
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

        lerpTime1 = 8;
        lerpTime2 = 1;

        startPos = transform.position;

        endMiddlePos = dishPosition + new Vector3(0f, 1.2f, 0f);
        startMiddlePos = endMiddlePos;

        endPos = dishPosition;
        positionSetted = true;

    }
   
    public void SetMoveFromDolphinToBin(Vector3 binPosition)
    {

        currentLerpTime1 = 0;
        currentLerpTime2 = 0;

        lerpTime1 = 9;
        lerpTime2 = 5;

        startPos = transform.position;

        endMiddlePos = binPosition + new Vector3(0f, 11f, 0f); ;
        startMiddlePos = endMiddlePos;

        endPos = binPosition;
        positionSetted = true;
        destroyBucket = true;
    }

    public void SetPositionFoodBucketTop()
    {
      

        if (foodMovedToDolphin == false)
        {
            currentLerpTime1 = 0;
            lerpTime1 = 3;
            lerpTime2 = 1;
            startPos = transform.position;
            endMiddlePos = startPos + new Vector3(0f, 1.8f, 0f);
            endPos = startPos+ new Vector3(0f, 1.8f, 0f);
            startMiddlePos = endMiddlePos;
            positionSetted = true;

        }
    }

    public void SetPositionFoodBucketDown(GameObject foodBucket)
    {
        

        if (foodMovedToDolphin == false)
        {
            currentLerpTime1 = 0;
            lerpTime1 = 3;
            lerpTime2 = 1;
            startPos = transform.position;
            Vector3 finalPos = new Vector3(transform.position.x, foodBucket.transform.position.y - 0.2f, transform.position.z);
            endMiddlePos = finalPos; 
            endPos = finalPos;
            startMiddlePos = endMiddlePos;
            positionSetted = true;
        }
    }
}

