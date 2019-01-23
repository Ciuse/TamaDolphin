using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTable : MonoBehaviour
{
    public GameObject targetTable;
    public Vector3 startPos;
    public Vector3 endPos;
    public bool movingTable;
    //Time to take from start to end
    public float lerpTime = 5;

    //this will update the lerp time
    public float currentLerpTime = 0;

    private bool piattoSpawned;

    private void Start()
    {
        movingTable = true;
        startPos = transform.position;
        endPos = targetTable.transform.position;
        piattoSpawned = false;
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

        if (currentLerpTime == lerpTime && piattoSpawned == false)
        {
            StartCoroutine("SpawnPiatto");
        }
    }

    private IEnumerator SpawnPiatto()
    {
        yield return new WaitForSeconds(1);
        GameObject piatto = (GameObject)(Resources.Load("Piatto"));
        Vector3 position3 = new Vector3(transform.position.x, transform.position.y + 1.8F, transform.position.z);
        Instantiate(piatto, position3, piatto.GetComponent<Transform>().rotation);
        movingTable = false;
        piattoSpawned = true;

    }
}



