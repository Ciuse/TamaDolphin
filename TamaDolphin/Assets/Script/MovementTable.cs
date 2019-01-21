using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTable : MonoBehaviour
{
    public GameObject targetTable;
    public Vector3 startPos;
    public Vector3 endPos;

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

        if(currentLerpTime==lerpTime)
        {
            GameObject piatto = (GameObject)(Resources.Load("Piatto"));
            Vector3 position3 = new Vector3(transform.position.x, transform.position.y + 1.8F, transform.position.z);
            Instantiate(piatto, position3, piatto.GetComponent<Transform>().rotation);
            Destroy(this);
        }
    }
}



