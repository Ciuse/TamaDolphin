using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : MonoBehaviour {


    public TypeOfInput realSamInput;
    public TypeOfInput therapistInput;

	// Use this for initialization
	void Start () {
        realSamInput = TypeOfInput.undefined;
        therapistInput = TypeOfInput.undefined;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void SetRealSamInput(TypeOfInput realSamInput)
    {
        this.realSamInput=realSamInput;
        Debug.Log("HO settato "+realSamInput);
    }

    public void SetTherapistInput(TypeOfInput therapistInput)
    {
        this.therapistInput=therapistInput;
        Debug.Log("HO settato " + therapistInput);
    }
}
