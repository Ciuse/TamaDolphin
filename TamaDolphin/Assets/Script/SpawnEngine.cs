using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEngine : MonoBehaviour {

    public GameObject[] foodBaskets;

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

            Instantiate(questionMark, position1, questionMark.GetComponent<Transform>().rotation);
            Instantiate(questionMark, position2, questionMark.GetComponent<Transform>().rotation);

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

                Instantiate(questionMark, position1, questionMark.GetComponent<Transform>().rotation);
                Instantiate(questionMark, position2, questionMark.GetComponent<Transform>().rotation);

                spawned++;
            }
        }
}
