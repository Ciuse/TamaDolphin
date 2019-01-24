﻿using System.Collections;
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

        cards.Add("Hungry", "8f96dd00");
        cards.Add("Sleepy", "abababb");
        cards.Add("Tired", "abababb");
        cards.Add("Happy", "abababb");

        cards.Add("Fish", "9f4dc300");
        cards.Add("Fruit", "f3778ad5");
        cards.Add("Cake", "be6b1f39");
        cards.Add("Meat", "9044425d");

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

    public void SetInputTherapistFindNeed(string buttonPressedId)
    {
        therapistInputValue = KeyByValue(webInput, buttonPressedId);
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
    }

    public void SetInputTherapistFindFood(string buttonPressedId)
    {
        therapistInputValue = KeyByValue(webInput, buttonPressedId);
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
