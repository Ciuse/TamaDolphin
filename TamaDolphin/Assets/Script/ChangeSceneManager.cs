using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneManager : MonoBehaviour {
    public NetworkEventManager network;

	// Use this for initialization
	void Start () {
        network = GameObject.Find("NetworkEventManager").GetComponent<NetworkEventManager>();
        network.gameEventManager = GameObject.Find("GameEventManager").GetComponent<GameEventManager>();
        network.therapistWebManager = GameObject.Find("TherapistManager").GetComponent<HttpPostRequest>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
