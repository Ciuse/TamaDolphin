using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedbackManager : MonoBehaviour {


    public WorldFeedback worldFeedback;
    public GameObject dolphin_VR;
    public GameObject table;
    public GameObject bavaglio;
    public GameObject bin;
    public NetworkEventManager networkEventManager;
    public SpawnEngine spawnEngine;
    List<GameObject> feedbackCorrectList = new List<GameObject>();
    public bool checkForTableEndMovement;
    public Vector3 movedFrom;
    public GameObject foodMoved;
    public bool isFoodInMovement;
    public float moveUpFoodInBin = 0f;
    // Use this for initialization
    void Start () {
        isFoodInMovement = false;
        foodMoved = null;
        bavaglio.SetActive(false);
        checkForTableEndMovement = false;
        networkEventManager = GameObject.Find("NetworkEventManager").GetComponent<NetworkEventManager>();
    }

	// Update is called once per frame
	void Update () {

        if (Time.frameCount % 40 == 0 && checkForTableEndMovement == true)
        {
            if (GameObject.Find("Table")!=null && GameObject.Find("Table").GetComponent<MovementTable>().movingTable == false)
            {
                GameObject.Find("Table").GetComponent<MovementTable>().enabled = false;
                checkForTableEndMovement = false;

                spawnEngine.SpawnFoodBucketAndBin(); // Vengono fatti comparire i cestini con il cibo e il cestino per la spazzatura
            }
        }
        if (isFoodInMovement == true)
        {
            if (foodMoved.GetComponent<MovementFood>().enabled == false)
            {
                Debug.Log("IL CIBO NON é PIU IN MOVIMENTO");
                isFoodInMovement = false;
            }
        }
    }

    // ********** FEEDBACK FIND NEED **************

    public void ActivateSamFindNeed()
    {
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetLights("set", "#000000", "#000000", "#000000", "#cc0000")); //settare solo la luce della pancia a rosso e le altre intensità a 0
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetSounds("set", "music", 15, 20)); //inserire suono del brontolio

    }

    public void CorrectFeedbackFindNeed()
        {

        //TODO FARE I FEEDBACK PER IL SAM FISICO
        StartCoroutine(CorrectFeedbackFindNeedAsync());
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetLights("set", "#009933", "#009933", "#009933", "#009933")); //tutto verde
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetSounds("set", "music", 14, 20)); //suono gioia TODO

    }

    public IEnumerator CorrectFeedbackFindNeedAsync()
    {
        yield return new WaitForSeconds(2f);
        GameObject cloud = GameObject.Find("Cloud");
        dolphin_VR.GetComponent<CloudOccurs>().StopSuggerimenti();
        Destroy(cloud);
        yield return new WaitForSeconds(2f);
        GameObject fork = (GameObject)(Resources.Load("Fork"));
        GameObject knife = (GameObject)(Resources.Load("Knife"));
        Vector3 dolphinPosition = dolphin_VR.transform.position;
        Vector3 position1 = new Vector3(dolphinPosition.x - 7.0F, dolphinPosition.y, dolphinPosition.z);
        Vector3 position2 = new Vector3(dolphinPosition.x + 6.50F, dolphinPosition.y + 0.7F, dolphinPosition.z);
        feedbackCorrectList.Add(Instantiate(fork, position1, fork.GetComponent<Transform>().rotation) as GameObject);
        feedbackCorrectList.Add(Instantiate(knife, position2, knife.GetComponent<Transform>().rotation) as GameObject);
        bavaglio.SetActive(true);
        yield return new WaitForSeconds(3f);
        if (table.activeInHierarchy == false )
        {
            table.SetActive(true);
        }
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
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetSounds("set", "music", 13, 20)); //disappointment
    }

    public void QuestionMarkFeedbackFindNeed()
    {
        spawnEngine.SpawnQuestionMark(8);
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetLights("set", "#808080", "#808080", "#808080", "#808080"));
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetSounds("set", "music", 13, 20)); //disappointment
    }

    public void ResetFeedbackFindNeed()
    {
        spawnEngine.StopAllCoroutines();
        spawnEngine.DestroyObjectSpawned();
    }


    // ********** FEEDBACK FIND FOOD **************

    public void ActivateSamFindFood()
    {
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetLights("set", "#000000", "#000000", "#000000", "#808080")); //settare solo la luce della pancia a grigio e le altre intensità a 0
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetSounds("set", "music", 14, 20)); //inserire suono del cibo giusto (????)

    }

    public void SameCorrectFindFood()
    {
        if (foodMoved != null)
        {
            GameObject piatto = GameObject.Find("Piatto(Clone)");
            if (piatto != null)
            {
                foodMoved.GetComponent<MovementFood>().enabled = true;
                foodMoved.GetComponent<MovementFood>().SetMoveFromDolphinToDish(piatto.transform.position);
            }
        
        }


        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetLights("set", "#000000", "#000000", "#000000", "#808080")); //settare solo la luce della pancia a grigio e le altre intensità a 0
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetSounds("set", "music", 14, 20)); //inserire suono della felicità (????)

        //TODO -> attivare la scena

        //SceneManager.LoadScene("Fireworks");

        //networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetSounds("set", "music", "10", 20));


    }

    public void SameWrongFindFood()
    {

        spawnEngine.SpawnWrognMarkAtPosition(new Vector3(foodMoved.transform.position.x + 5f, foodMoved.transform.position.y, foodMoved.transform.position.z));


        if (foodMoved != null)
        {
            GameObject bin = GameObject.Find("Bin");
            if (bin != null)
            {
                GameObject targetTrash = GameObject.Find("Bin/TargetTrash");

                foodMoved.GetComponent<MovementFood>().enabled = true;
                foodMoved.GetComponent<MovementFood>().SetMoveFromDolphinToBin(targetTrash.transform.position + new Vector3 (0f, moveUpFoodInBin, 0f));
                moveUpFoodInBin = moveUpFoodInBin + 2.7f;
                foodMoved = null;
                movedFrom = Vector3.zero;
            }
        }

        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetLights("set", "#cc0000", "#cc0000", "#cc0000", "#cc0000"));
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetSounds("set", "music", 13, 20)); //inserire suono DELLO SCHIFO TODO


    }
    public void DifferentCorrectChangedFood() //TODO bho non cambia niente dal correct correct normale in teoria
    {

        SameCorrectFindFood();

    }

    public void DifferentWrongChangedFood()
    {
        SameWrongFindFood();
    }




    public void DifferentCorrectVRFindFood()
    {
        //TODO BHO

        spawnEngine.SpawnQuestionMarkAtPosition(new Vector3(foodMoved.transform.position.x +5f, foodMoved.transform.position.y, foodMoved.transform.position.z));
    }

    public void DifferentCorrectSamFindFood()
    {
        //TODO BHO

        spawnEngine.SpawnQuestionMarkAtPosition(new Vector3(foodMoved.transform.position.x + 5f, foodMoved.transform.position.y, foodMoved.transform.position.z));



    }

    public void DifferentWrongFindFood()
    {
        //TODO -> torna indietro e sam é MOOOOOOOLTO ARRABBIATO. BUUUU
        spawnEngine.SpawnQuestionMarkAtPosition(new Vector3(foodMoved.transform.position.x + 5f, foodMoved.transform.position.y, foodMoved.transform.position.z));

    }

    public void VisualFoodFeedbackChoice(string foodChoice) //nominare l oggetto del cibo da muovere come quello del valore chiave del dizionario associato all input della terapista nella classe InputState
    {


        GameObject food = GameObject.Find(foodChoice);
        if (food != null)
        {
            if (foodMoved == null)
            {
                foodMoved = food;
                movedFrom = new Vector3(food.transform.position.x, food.transform.position.y, food.transform.position.z); ;
                food.GetComponent<MovementFood>().enabled = true;
                food.GetComponent<MovementFood>().SetMoveToDolphin();
                isFoodInMovement = true;
            }
            else
            {
                //  -> TODO di sicuro non va messo qui.
                //rimetto a posto il cibo vecchio 
                foodMoved.GetComponent<MovementFood>().enabled = true;
                foodMoved.GetComponent<MovementFood>().SetMoveBackToBucket(movedFrom);

                //muovo il nuovo cibo
                foodMoved = food;
                movedFrom = new Vector3(food.transform.position.x, food.transform.position.y, food.transform.position.z); ;
                food.GetComponent<MovementFood>().enabled = true;
                food.GetComponent<MovementFood>().SetMoveToDolphin();
                isFoodInMovement = true;


            }
        }
    }
}
