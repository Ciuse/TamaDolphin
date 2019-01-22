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

        correctCardIdFindNeed = "hungry";
        correctWebIdFindNeed = "1";

        cards.Add("hungry", "a3cd81d5");
        cards.Add("sleepy", "abababb");
        cards.Add("tired", "abababb");
        cards.Add("happy", "abababb");

        cards.Add("Fish", "abababb");
        cards.Add("Fruit", "abababb");
        cards.Add("Cake", "abababb");
        cards.Add("Ham", "abababb");

        webInput.Add("wrong", "0");
        webInput.Add("correct", "1");

        webInput.Add("Fish", "2");
        webInput.Add("Ham", "3");
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

        if (correctCardIdFindNeed == cardKey)
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

        if (correctCardIdFindFood == cardKey)
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

    public void SetInputTherapistFindNeed(string buttonPressedId)
    {
        therapistInputValue = KeyByValue(webInput, buttonPressedId);
        Debug.Log("therapistInputValue input settato con valore:" + therapistInputValue);

        if (correctWebIdFindNeed == buttonPressedId)
        {
            therapistInput = TypeOfInput.correct;
            Debug.Log("therapist input settato con valore correct");
        }
        else
        {
            therapistInput = TypeOfInput.wrong;
            Debug.Log("therapist input settato con valore wrong");
        }
    }

    public void SetInputTherapistFindFood(string buttonPressedId)
    {
        therapistInputValue = KeyByValue(webInput, buttonPressedId);
        Debug.Log("therapistInputValue input settato con valore:" + therapistInputValue);

        if (correctWebIdFindFood == buttonPressedId)
        {
            therapistInput = TypeOfInput.correct;
            Debug.Log("therapist input settato con valore correct");
        }
        else
        {
            therapistInput = TypeOfInput.wrong;
            Debug.Log("therapist input settato con valore wrong");
        }
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
        isInputTheSame = false;
    }

    public void CheckIsInputTheSame()
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
