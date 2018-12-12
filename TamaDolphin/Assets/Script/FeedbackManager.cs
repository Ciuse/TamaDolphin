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

    public void CorrectFeedbackFame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetSounds("set", "music", "10", 20));
    }

    public void WrongFeedbackFame()
    {

    }

    public void QuestionMarkFeedbackFame()
    {
        spawnEngine.SpawnQuestionMark(5);
    }
}
