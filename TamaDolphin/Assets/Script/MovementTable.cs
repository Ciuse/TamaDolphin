using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTable : MonoBehaviour
{
    public GameObject targetTable;
    public Vector3 startPos;
    public Vector3 endPos;
    public float distance;

    //Time to take from start to end
    public float lerpTime = 5;

    //this will update the lerp time
    public float currentLerpTime = 0;

    private void Start()
    {
        startPos = transform.position;
        endPos = targetTable.transform.position;
    }

    private void Update()
    {
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime >= lerpTime)
        {
            currentLerpTime = lerpTime;
        }
        float perc = currentLerpTime / lerpTime;
        transform.position = Vector3.Lerp(startPos, endPos, perc);
    }
}



