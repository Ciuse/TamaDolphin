using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEventManager : MonoBehaviour
{

    public NetworkEventManager networkEventManager;
    public FeedbackManager feedbackManager;
    public InputState inputState;
    public GamePhase gamePhase;
    public bool inputSetted = false;
    public bool changedWrongFoodTherapist = false;
    public bool endGame =false;


    // Use this for initialization
    void Start()
    {
        networkEventManager = GameObject.Find("NetworkEventManager").GetComponent<NetworkEventManager>();
        gamePhase = GamePhase.startFindNeed;
        feedbackManager.dolphin_VR.GetComponent<DolphinAnimation>().StartMuoviBocca();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 20 == 0)
        {
            if (!inputSetted && !feedbackManager.isFoodInMovement && (inputState.realSamInput != TypeOfInput.undefined && inputState.therapistInput != TypeOfInput.undefined))
            {
                inputState.CheckIsInputTheSame();

                if (gamePhase == GamePhase.findNeed) {
                    FeedbackFindNeed();
                    inputSetted = true;
                }

                if (gamePhase == GamePhase.findFood)
                {
                    FeedbackFindFood();
                    inputSetted = true;
                }
            }

            if(endGame && !feedbackManager.isFoodInMovement)
            {
                SceneManager.LoadScene("Fireworks");
            }
        }
    }

    public void FeedbackFindNeed()
    {
        {
            if (inputState.realSamInput == TypeOfInput.correct && inputState.therapistInput == TypeOfInput.correct)
            {
                feedbackManager.CorrectFeedbackFindNeed();
                StartFindFoodGamePhase();
            }
            if ((inputState.realSamInput == TypeOfInput.correct && inputState.therapistInput == TypeOfInput.wrong) || (inputState.realSamInput == TypeOfInput.wrong && inputState.therapistInput == TypeOfInput.correct))
            {
                feedbackManager.QuestionMarkFeedbackFindNeed();
            }
            if (inputState.realSamInput == TypeOfInput.wrong && inputState.therapistInput == TypeOfInput.wrong)
            {
                feedbackManager.WrongFeedbackFindNeed();
            }
        }
    }

    public void FeedbackFindFood()
    {
        if (inputState.isInputTheSame && changedWrongFoodTherapist == false)
        {
            if (inputState.realSamInput == TypeOfInput.correct && inputState.therapistInput == TypeOfInput.correct) //stessi giusti
            {
                feedbackManager.SameCorrectFindFood();
                inputState.ResetInput(); // TODO quando si inseriranno nuove fase questo sarà il punto di partenza per la successiva.
                endGame = true;
            }
            if (inputState.realSamInput == TypeOfInput.wrong && inputState.therapistInput == TypeOfInput.wrong)  //stessi sbagliati
            {
                feedbackManager.SameWrongFindFood();
                inputState.ResetInput();
            }
        }

        else
        {
            if (inputState.isInputTheSame && changedWrongFoodTherapist == true)
            {

                if (inputState.realSamInput == TypeOfInput.correct && inputState.therapistInput == TypeOfInput.correct)  //stesso correct correct dopo che è stato cambiato l input della terapista
                {
                    feedbackManager.DifferentCorrectChangedFood();
                    inputState.ResetInput(); // TODO quando si inseriranno nuove fase questo sarà il punto di partenza per la successiva.
                    changedWrongFoodTherapist = false;
                    endGame = true;

                }


                if (inputState.realSamInput == TypeOfInput.wrong && inputState.therapistInput == TypeOfInput.wrong) //stesso wrong wrong dopo che è stato cambiato l input della terapista
                {
                    feedbackManager.DifferentWrongChangedFood();
                    inputState.ResetInput();
                    changedWrongFoodTherapist = false;
                }


            }
            else
            {
                if (inputState.realSamInput == TypeOfInput.wrong && inputState.therapistInput == TypeOfInput.wrong)  //diversi sbagliati
                {
                    feedbackManager.DifferentWrongFindFood();
                }
                if (inputState.realSamInput == TypeOfInput.correct && inputState.therapistInput == TypeOfInput.wrong)  //diversi sam giusto VR sbagliato
                {
                    feedbackManager.DifferentCorrectSamFindFood();
                }
                if (inputState.realSamInput == TypeOfInput.wrong && inputState.therapistInput == TypeOfInput.correct)  //diversi sam sbagliato VR giusto
                {
                    feedbackManager.DifferentCorrectVRFindFood();
                }
            }
        }
    }
    public void SetInputStateTherapist(string buttonPressedId)
    {
        if (gamePhase == GamePhase.startFindNeed) //Fase 1.0 -> leggo l'input della terapista
        {
            if (inputState.SetInputTherapistFindNeed(buttonPressedId))
            {
                feedbackManager.ActivateSamFindNeed(); //Fase 1.1 -> dopo che la terapista preme il bottone si "attiva" sam fisico
                gamePhase = GamePhase.findNeed;
                return;
            }
        }

        if (gamePhase == GamePhase.startFindFood && feedbackManager.findFoodObjectSpawned == true)  //Fase 2.0 -> leggo l'input della terapista, il cibo comunicato si muove verso il delfino
        {
            if (inputState.SetInputTherapistFindFood(buttonPressedId))
            {
                feedbackManager.spawnEngine.DestroyObjectSpawned();
                feedbackManager.VisualFoodFeedbackChoice(inputState.therapistInputValue); //Fase 2.1 -> TODO il delfino sam fisico si attiva
                gamePhase = GamePhase.findFood;
                return;
            }
        }

        if (gamePhase == GamePhase.findNeed) // Fase 1.3 -> la terapista può cambiare l'eventuale input sbagliato
        {
            if (inputState.SetInputTherapistFindNeed(buttonPressedId))
            {
                OverloadInput();
            }
        }

        if (gamePhase == GamePhase.findFood) // Fase 2.3 -> la terapista può cambiare l'eventuale input sbagliato --> TODO abbiamo deciso di lasciarlo così ma eventualmente si può evitare che la scelta del VR venga cambiata
        {
            if (inputState.SetInputTherapistFindFood(buttonPressedId))
            {
                feedbackManager.spawnEngine.DestroyObjectSpawned();
                feedbackManager.VisualFoodFeedbackChoice(inputState.therapistInputValue);
                changedWrongFoodTherapist = true;
                OverloadInput();
            }
        }
    }

    public void SetInputStateRealSam(string cardIdRead)
    {
        Debug.Log(cardIdRead);
        if (gamePhase == GamePhase.findNeed) //Fase 1.2 -> l'input della carta letta del sam fisico viene letto solo dopo che la terapista ha premuto il bottone
        {
            inputState.SetInputRealSamFindNeed(cardIdRead);
            OverloadInput();  // Permette di sovrascrivere l'input
        }

        if (gamePhase == GamePhase.findFood) //Fase 2.2 ->
        {
            inputState.SetInputRealSamFindFood(cardIdRead);
            OverloadInput();  // Permette di sovrvascrivere l'input
        }

    }

    public void OverloadInput()
    {
        feedbackManager.ResetFeedbackFindNeed();
        inputSetted = false;
    }

    public void StartFindFoodGamePhase()
    {
        inputSetted = false;
        inputState.ResetInput();
        gamePhase = GamePhase.startFindFood;
    }
}

