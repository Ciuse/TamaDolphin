using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : MonoBehaviour {


    private TypeOfInput samInput;
    private TypeOfInput therapistInput;

	// Use this for initialization
	void Start () {
        samInput = 0;
        therapistInput = 0;
    }

    public TypeOfInput GetSamInput()
    {
        return samInput;
    }

    public TypeOfInput GetTherapistInput()
    {
        return therapistInput;
    }

    public void SetSamInput(TypeOfInput samInput)
    {
        this.samInput=samInput;
    }

    public void SetTherapistInput(TypeOfInput therapistInput)
    {
        this.therapistInput=therapistInput;
    }
}
