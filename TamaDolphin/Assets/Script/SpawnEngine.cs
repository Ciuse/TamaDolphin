using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEngine : MonoBehaviour {

    public GameObject[] foodBaskets;
    public GameObject bin;

    List<GameObject> questionMarkList = new List<GameObject>();

    List<GameObject> wrongMarkList = new List<GameObject>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void SpawnQuestionMark(int numToSpawn)
    {
        StopAllCoroutines();
        StartCoroutine(SlowSpawnQuestionMark(numToSpawn));
    }

    public void SpawnWrongMark(int numToSpawn)
    {
        StopAllCoroutines();
        StartCoroutine(SlowSpawnWrongMark(numToSpawn));
    }

    public void DestroyObjectSpawned()
    {
        foreach (GameObject item in questionMarkList)
        {
            Destroy(item);
        }

        foreach (GameObject item in wrongMarkList)
        {
            Destroy(item);
        }
    }

    public void SpawnFoodBucketAndBin()
    { 
        
        foreach (GameObject cestino in foodBaskets)
        {
            cestino.SetActive(true);
        }

        bin.SetActive(true);
    }


    private IEnumerator SlowSpawnQuestionMark(int numToSpawn)
    {
        int spawned = 0;
        GameObject questionMark = (GameObject)(Resources.Load("QuestionMark"));
        float spawnTime = Time.time;

        while (spawned < numToSpawn)
        {

            Vector3 position1 = new Vector3(Random.Range(-10.0F, -6F), Random.Range(0.0F, 10.0F), Random.Range(0F, -10F));
            Vector3 position2 = new Vector3(Random.Range(6.0F, 10.0F), Random.Range(0.0F, 10.0F), Random.Range(0F, -10F));

            questionMarkList.Add(Instantiate(questionMark, position1, questionMark.GetComponent<Transform>().rotation) as GameObject);
            questionMarkList.Add(Instantiate(questionMark, position2, questionMark.GetComponent<Transform>().rotation) as GameObject);

            spawned++;

            yield return new WaitForSeconds(2);
            if (spawned != numToSpawn)
            {
                DestroyObjectSpawned();
            }

        }
    }

    private IEnumerator SlowSpawnWrongMark(int numToSpawn)
    {

        int spawned = 0;
        GameObject questionMark = (GameObject)(Resources.Load("WrongMark"));
        float spawnTime = Time.time;

        while (spawned < numToSpawn)
        {

            Vector3 position1 = new Vector3(Random.Range(-10.0F, -6F), Random.Range(0.0F, 10.0F), Random.Range(0F, -10F));
            Vector3 position2 = new Vector3(Random.Range(6.0F, 10.0F), Random.Range(0.0F, 10.0F), Random.Range(0F, -10F));

            wrongMarkList.Add(Instantiate(questionMark, position1, questionMark.GetComponent<Transform>().rotation) as GameObject);
            wrongMarkList.Add(Instantiate(questionMark, position2, questionMark.GetComponent<Transform>().rotation) as GameObject);

            spawned++;

            yield return new WaitForSeconds(2);
            if (spawned != numToSpawn)
            {
                DestroyObjectSpawned();
            }

        }
    }
}
