using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjectUpAndDown : MonoBehaviour {

    public float sandLevel = 0.0f;
    public float floatThreshold = 2.0f;
    public float sandDensity = 0.125f;
    public float downForce = 4.0f;

    float forceFactor;
    Vector3 floatForce;

	void FixedUpdate () {
        forceFactor = 1.0f - ((transform.position.y - sandLevel) / floatThreshold);
        if(forceFactor > 0.0f)
        {
            floatForce = -Physics.gravity * (forceFactor - GetComponent<Rigidbody>().velocity.y * sandDensity);
            floatForce += new Vector3(0.0f, downForce, 0.0f);
            GetComponent<Rigidbody>().AddForceAtPosition(floatForce, transform.position);
        }
	}
}
