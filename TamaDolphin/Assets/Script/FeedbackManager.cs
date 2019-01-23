using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedbackManager : MonoBehaviour {


    public WorldFeedback worldFeedback;
    public GameObject dolphin_VR;
    public GameObject table;
    public GameObject bavaglio;
    public NetworkEventManager networkEventManager;
    public SpawnEngine spawnEngine;
    List<GameObject> feedbackCorrectList = new List<GameObject>();
    private bool checkForTableEndMovement;
    // Use this for initialization
    void Start () {
        bavaglio.SetActive(false);
        checkForTableEndMovement = false;
        networkEventManager = GameObject.Find("NetworkEventManager").GetComponent<NetworkEventManager>();
    }

	// Update is called once per frame
	void Update () {

        if (Time.frameCount % 40 == 0 && checkForTableEndMovement == true)
        {
            if (GameObject.Find("Table").GetComponent<MovementTable>().movingTable == false)
            {
                GameObject.Find("Table").GetComponent<MovementTable>().enabled = false;
                checkForTableEndMovement = false;

                spawnEngine.SpawnFoodBucket();
            }
        }
    }

    // ********** FEEDBACK FIND NEED **************

    public void ActivateSamFindNeed()
    {
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetLights("set", "#000000", "#000000", "#000000", "#000000")); //settare solo la luce della pancia a rosso e le altre intensità a 0
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetSounds("set", "music", 10, 20)); //inserire suono del brontolio

    }

    public void CorrectFeedbackFindNeed()
        {

         //TODO FARE I FEEDBACK PER IL SAM FISICO
           StartCoroutine(CorrectFeedbackFindNeedAsync());

        }

    public IEnumerator CorrectFeedbackFindNeedAsync()
    {

        yield return new WaitForSeconds(2);
        GameObject cloud = GameObject.Find("Cloud");
        dolphin_VR.GetComponent<CloudOccurs>().StopSuggerimenti();
        Destroy(cloud);
        yield return new WaitForSeconds(2);
        GameObject fork = (GameObject)(Resources.Load("Fork"));
        GameObject knife = (GameObject)(Resources.Load("Knife"));
        Vector3 dolphinPosition = dolphin_VR.transform.position;
        Vector3 position1 = new Vector3(dolphinPosition.x - 7.0F, dolphinPosition.y, dolphinPosition.z);
        Vector3 position2 = new Vector3(dolphinPosition.x + 6.50F, dolphinPosition.y + 0.7F, dolphinPosition.z);
        feedbackCorrectList.Add(Instantiate(fork, position1, fork.GetComponent<Transform>().rotation) as GameObject);
        feedbackCorrectList.Add(Instantiate(knife, position2, knife.GetComponent<Transform>().rotation) as GameObject);
        bavaglio.SetActive(true);
        yield return new WaitForSeconds(3);
        table.GetComponent<MovementTable>().enabled = true;
        checkForTableEndMovement = true;
       // StartCoroutine(CorrectFeedbackFindNeedAsyncSecond());


    }




    //public IEnumerator CorrectFeedbackFindNeedAsyncSecond()
    //{

    //    new WaitForSeconds(2);

    //    yield return null;

    //}

    public void WrongFeedbackFindNeed()
    {
        spawnEngine.SpawnWrongMark(8);
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetLights("set", "#cc0000", "#cc0000", "#cc0000", "#cc0000"));

    }

    public void QuestionMarkFeedbackFindNeed()
    {
        spawnEngine.SpawnQuestionMark(8);
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetLights("set", "#669999", "#669999", "#669999", "#669999"));

    }

    public void ResetFeedbackFindNeed()
    {
        spawnEngine.DestroyObjectSpawned();
    }


    // ********** FEEDBACK FIND FOOD **************

    public void ActivateSamFindFood()
    {
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetSounds("set", "music", 10, 20)); //inserire suono del cibo giusto (????)
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetLights("set", "#8c8c8c", "#8c8c8c", "#8c8c8c", "#8c8c8c")); //settare solo la luce della pancia a grigio e le altre intensità a 0

    }

    public void SameCorrectFindFood()
    {
        SceneManager.LoadScene("Fireworks");
        //networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetSounds("set", "music", "10", 20));

        //TODO -> finisce nel piatto

    }

    public void SameWrongFindFood()
    {
        //TODO -> finisce nel cestino :(

    }

    public void DifferentCorrectVRFindFood()
    {
        //TODO BHO

    }

    public void DifferentCorrectSamFindFood()
    {
        //TODO BHO

    }

    public void DifferentWrongFindFood()
    {
        //TODO -> torna indietro e sam é MOOOOOOOLTO ARRABBIATO. BUUUU

    }

    public void VisualFoodFeedbackChoice(string foodChoice) //nominare l oggetto del cibo da muovere come quello del valore chiave del dizionario associato all input della terapista nella classe InputState
    {
        GameObject food = GameObject.Find(foodChoice);

        food.GetComponent<MovementFood>().enabled = true;
    }
}
