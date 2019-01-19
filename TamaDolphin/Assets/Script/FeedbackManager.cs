using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FeedbackManager : MonoBehaviour {


    public WorldFeedback worldFeedback;
    public GameObject dolphin_VR;
    public NetworkEventManager networkEventManager;
    public SpawnEngine spawnEngine;

	// Use this for initialization
	void Start () {
        networkEventManager = GameObject.Find("NetworkEventManager").GetComponent<NetworkEventManager>();
    }

	// Update is called once per frame
	void Update () {

    }

    // ********** FEEDBACK FIND NEED **************

    public void ActivateSamFindNeed ()
    {
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetSounds("set", "music", 10, 20)); //inserire suono del brontolio
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetLights("set", "#cc0000", "#cc0000", "#cc0000", "#cc0000", 1, 1, 1, 1)); //settare solo la luce della pancia a rosso e le altre intensità a 0
    }

    public void CorrectFeedbackFindNeed()
    {
        //spawn di bavaglio, tavolo, forchetta e coltello
    }

    public void WrongFeedbackFindNeed()
    {
        spawnEngine.SpawnWrongMark(4);
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetLights("set", "#cc0000", "#cc0000", "#cc0000", "#cc0000", 1, 1, 1, 1));

    }

    public void QuestionMarkFeedbackFindNeed()
    {
        spawnEngine.SpawnQuestionMark(4);
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetLights("set", "#669999", "#669999", "#669999", "#669999", 1, 1, 1, 1));

    }

    public void ResetFeedbackFindNeed()
    {
        spawnEngine.DestroyObjectSpawned();
    }


    // ********** FEEDBACK FIND FOOD **************

    public void ActivateSamFindFood()
    {
        //TODOOOOOO
    }

    public void SameCorrectFindFood()
    {
        SceneManager.LoadScene("Fireworks");
        //networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetSounds("set", "music", "10", 20));

        //TODO

    }

    public void SameWrongFindFood()
    {
        //TODO

    }

    public void DifferentCorrectVRFindFood()
    {
        //TODO

    }

    public void DifferentCorrectSamFindFood()
    {
        //TODO

    }

    public void DifferentWrongFindFood()
    {
        //TODO

    }
}
