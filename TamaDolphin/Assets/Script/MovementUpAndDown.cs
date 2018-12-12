using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementUpAndDown : MonoBehaviour {

    public Transform[] target;
    public float speed = 0.5f;

    private int current;
	
	// Update is called once per frame
	void Update () {
        //move until you reach the current object/waypoint
        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        //object/waypoint reached,move to the next object
        else current = (current + 1) % target.Length;
	}
}
