using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour {
    public NetworkEventManager network;

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name == "SamScene"){
            network = GameObject.Find("NetworkEventManager").GetComponent<NetworkEventManager>();
            network.gameEventManager = GameObject.Find("GameEventManager").GetComponent<GameEventManager>();
            network.therapistWebManager = GameObject.Find("TherapistManager").GetComponent<HttpPostRequest>();    
        }
    }

    // Update is called once per frame
    void Update () {

    }
}
