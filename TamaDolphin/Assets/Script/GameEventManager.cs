using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{

    public NetworkEventManager networkEventManager;
    public FeedbackManager feedbackManager;
    public InputState inputState;
    public string gamePhase;
    public string correctCardId;

    // Use this for initialization
    void Start()
    {
        gamePhase = "Start";
        correctCardId = "45b41e39";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCorrectCardId(string correctCardId)
    {
        this.correctCardId = correctCardId;
    }

    public void SetGamePhase(string gamePhase)
    {
        this.gamePhase = gamePhase;
    }

    public void SetInputStateRealSam(string cardIdRead)
    {
        Debug.Log(cardIdRead);

        if (correctCardId == cardIdRead )
        {
            inputState.SetRealSamInput(TypeOfInput.correct);
            Debug.Log("LA STRINGA é CORRETTA");
        }
        else
        {
            inputState.SetRealSamInput(TypeOfInput.wrong);
        }
    }

    public void SetInputStateTherapist(string buttonPressedId)
    {
        if (buttonPressedId== "1")
        {
            inputState.SetTherapistInput(TypeOfInput.correct);
            Debug.Log("therapist input settato con valore correct");
        }
        else
        {
            inputState.SetTherapistInput(TypeOfInput.wrong);
            Debug.Log("therapist input settato con valore wrong");
        }

    }
}
