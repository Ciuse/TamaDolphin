using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : MonoBehaviour {


    private TypeOfInput realSamInput;
    private TypeOfInput therapistInput;

	// Use this for initialization
	void Start () {
        realSamInput = TypeOfInput.undefined;
        therapistInput = TypeOfInput.undefined;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public TypeOfInput GetSamInput()
    {
        return realSamInput;
    }

    public TypeOfInput GetTherapistInput()
    {
        return therapistInput;
    }

    public void SetRealSamInput(TypeOfInput realSamInput)
    {
        this.realSamInput=realSamInput;
        Debug.Log("HO settato giusto"+realSamInput);
    }

    public void SetTherapistInput(TypeOfInput therapistInput)
    {
        this.therapistInput=therapistInput;
        Debug.Log("HO settato giusto" + therapistInput);
    }
}
