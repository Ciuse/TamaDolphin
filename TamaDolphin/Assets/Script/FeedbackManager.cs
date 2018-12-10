using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackManager : MonoBehaviour {


    public WorldFeedback worldFeedback;
    public GameObject dolphin_VR;
    public NetworkEventManager networkEventManager;
	// Use this for initialization
	void Start () {
        networkEventManager = GameObject.Find("NetworkEventManager").GetComponent<NetworkEventManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
