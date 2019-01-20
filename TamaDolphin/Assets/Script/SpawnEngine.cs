using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEngine : MonoBehaviour {

    public GameObject[] foodBaskets;

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
        int spawned = 0;
        GameObject questionMark = (GameObject)(Resources.Load("QuestionMark"));
        float spawnTime = Time.time;

        while (spawned < numToSpawn)
        {

            Vector3 position1 = new Vector3(Random.Range(-10.0F, -6F), Random.Range(0.0F, 10.0F), Random.Range(5F, 15.0F));
            Vector3 position2 = new Vector3(Random.Range(6.0F, 10.0F), Random.Range(0.0F, 10.0F), Random.Range(5F, 15.0F));

            questionMarkList.Add(Instantiate(questionMark, position1, questionMark.GetComponent<Transform>().rotation) as GameObject);
            questionMarkList.Add(Instantiate(questionMark, position2, questionMark.GetComponent<Transform>().rotation) as GameObject);

            spawned++;
        }
    }

        public void SpawnWrongMark(int numToSpawn)
        {
            int spawned = 0;
            GameObject questionMark = (GameObject)(Resources.Load("WrongMark"));
            float spawnTime = Time.time;

            while (spawned < numToSpawn)
            {

                Vector3 position1 = new Vector3(Random.Range(-10.0F, -6F), Random.Range(0.0F, 10.0F), Random.Range(5F, 15.0F));
                Vector3 position2 = new Vector3(Random.Range(6.0F, 10.0F), Random.Range(0.0F, 10.0F), Random.Range(5F, 15.0F));

                wrongMarkList.Add(Instantiate(questionMark, position1, questionMark.GetComponent<Transform>().rotation) as GameObject);
                wrongMarkList.Add(Instantiate(questionMark, position2, questionMark.GetComponent<Transform>().rotation) as GameObject);

                spawned++;
            }
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

    public void SpawnFoodBucket()
    {
        //TODO
    }
}
