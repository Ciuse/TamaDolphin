using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        networkEventManager = GameObject.Find("NetworkEventManager").GetComponent<NetworkEventManager>();
        gamePhase = "Start";
        correctCardId = "45b41e39";
    }

    // Update is called once per frame
    void Update()
    {
      if(inputState.realSamInput!= TypeOfInput.undefined && inputState.therapistInput != TypeOfInput.undefined)
        {
            InputManager();
        }
    }

    public void InputManager()
    {
        if (inputState.realSamInput == TypeOfInput.correct && inputState.therapistInput == TypeOfInput.correct)
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        networkEventManager.SetRealSamSetting(networkEventManager.realSamManager.SetSounds("set", "music", "10", 20));
        }
        if ((inputState.realSamInput == TypeOfInput.correct && inputState.therapistInput == TypeOfInput.wrong)|| (inputState.realSamInput == TypeOfInput.wrong  &&  inputState.therapistInput == TypeOfInput.correct))
        {

        }
        if (inputState.realSamInput == TypeOfInput.wrong && inputState.therapistInput == TypeOfInput.wrong)
        {

        }
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
