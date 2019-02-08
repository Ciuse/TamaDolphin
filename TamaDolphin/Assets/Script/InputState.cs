using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : MonoBehaviour {


    public TypeOfInput realSamInput;
    public TypeOfInput therapistInput;
    public bool isInputTheSame;  //booleane per indicare se le se scelte sono uguali o no (esempio: scelgono lo stesso cibo indipendentemente se giusto o sbagliato)

    public string realSamInputValue;
    public string therapistInputValue;


    public string correctCardIdFindNeed;
    public string correctCardIdFindFood;

    public string correctWebIdFindNeed;
    public string correctWebIdFindFood;

    public Dictionary<string, string> cards = new Dictionary<string, string>();

    public Dictionary<string, string> webInput = new Dictionary<string, string>();


    // Use this for initialization
    void Start () {
        realSamInput = TypeOfInput.undefined;
        therapistInput = TypeOfInput.undefined;

        correctCardIdFindNeed = "Hungry";
        correctWebIdFindNeed = "Correct";

        correctCardIdFindFood = "Fish";
        correctWebIdFindFood = "Fish";

        cards.Add("Hungry", "2f467000");
        cards.Add("Sleepy", "4fe44a06");
        cards.Add("Playful", "2f4ac700");
        cards.Add("Study", "2f399b00");

        cards.Add("Fish", "2f36cc00");
        cards.Add("Fruit", "2f4a8a00");
        cards.Add("Cake", "5f46a406");
        cards.Add("Meat", "4fcecd06");

        webInput.Add("Wrong", "0");
        webInput.Add("Correct", "1");

        webInput.Add("Fish", "2");
        webInput.Add("Meat", "3");
        webInput.Add("Fruit", "4");
        webInput.Add("Cake", "5");
    }


    // Update is called once per frame
    void Update()
    {

    }

    //*********** SAM CARD INPUT **************

    public void SetInputRealSamFindNeed(string cardValue)
    {
        string cardKey = KeyByValue(cards, cardValue); //DA TESTARE -> dovrebbe prendere il codice "a3cd81d5" e trasformarlo in "hungry"

        realSamInputValue = cardKey;
        Debug.Log("realSamInputValue input settato con valore:" + realSamInputValue);

        if (correctCardIdFindNeed == realSamInputValue)
        {
            realSamInput=TypeOfInput.correct;
            Debug.Log("carta letta con valore correct");
        }
        else
        {
            realSamInput=TypeOfInput.wrong;
            Debug.Log("carta letta con valore wrong");
        }
    }

    public void SetInputRealSamFindFood(string cardValue)
    {
        string cardKey = KeyByValue(cards, cardValue);
        realSamInputValue = cardKey;
        Debug.Log("realSamInputValue input settato con valore:" + realSamInputValue);

        if (correctCardIdFindFood == realSamInputValue)
        {
            realSamInput = TypeOfInput.correct;
            Debug.Log("carta letta con valore correct");
        }
        else
        {
            realSamInput = TypeOfInput.wrong;
            Debug.Log("carta letta con valore wrong");
        }
    }

    //************** THERAPIST INPUT ***************

    public bool SetInputTherapistFindNeed(string buttonPressedId)
    {
        string inputKey = KeyByValue(webInput, buttonPressedId);
        if (inputKey == "Wrong" || inputKey == "Correct")
        {
            therapistInputValue = inputKey;
            Debug.Log("therapistInputValue input settato con valore:" + therapistInputValue);

            if (correctWebIdFindNeed == therapistInputValue)
            {
                therapistInput = TypeOfInput.correct;
                Debug.Log("therapist input settato con valore correct");
            }
            else
            {
                therapistInput = TypeOfInput.wrong;
                Debug.Log("therapist input settato con valore wrong");
            }
            return true;
        }
        return false;
      
    }

    public bool SetInputTherapistFindFood(string buttonPressedId)
    {

        string inputKey = KeyByValue(webInput, buttonPressedId);
        if (inputKey == "Fish" || inputKey == "Meat" || inputKey == "Fruit" || inputKey == "Cake")
        {
            therapistInputValue = inputKey;
            Debug.Log("therapistInputValue input settato con valore:" + therapistInputValue);

            if (correctWebIdFindFood == therapistInputValue)
            {
                therapistInput = TypeOfInput.correct;
                Debug.Log("therapist input settato con valore correct");
            }
            else
            {
                therapistInput = TypeOfInput.wrong;
                Debug.Log("therapist input settato con valore wrong");
            }

            return true;
        }
        return false;
    }

    public static string KeyByValue(Dictionary<string, string> dict, string val)
    {
        string key = null;
        foreach (KeyValuePair<string, string> pair in dict)
        {
            if (pair.Value == val)
            {
                key = pair.Key;
                break;
            }
        }
        return key;
    }

    public void ResetInput()
    {
        Debug.Log("RESETTATO INPUT");
        realSamInput = TypeOfInput.undefined;
        therapistInput = TypeOfInput.undefined;
        therapistInputValue = "";
        realSamInputValue = "";
        isInputTheSame = false;
    }

    public void CheckIsInputTheSame()
    {
        if (!string.IsNullOrEmpty(realSamInputValue) && !string.IsNullOrEmpty(therapistInputValue))
        {
            if (realSamInputValue == therapistInputValue)
            {
                isInputTheSame = true;
                Debug.Log("SETTATO isInputTheSame :" + isInputTheSame);
            }
            else
            {
                isInputTheSame = false;
            }
        }
    }
}
