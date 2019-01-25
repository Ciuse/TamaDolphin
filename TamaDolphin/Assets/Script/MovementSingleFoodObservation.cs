using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSingleFoodObservation : MonoBehaviour
{

    public GameObject food;
    public bool foodStandUp = false;
    public bool foodComeBack = false;

    public void MovementSingleFood()
    {

        if (food != null && foodStandUp==false)
        {

            food.GetComponent<MovementFood>().enabled = true;
            food.GetComponent<MovementFood>().SetPositionSingleFoodAtTop(food);
            foodStandUp = true;

        }

    }



    public void SingleFoodReturnBack()
    {
        if (food != null && foodComeBack==false)
        {
            food.GetComponent<MovementFood>().enabled = true;
            food.GetComponent<MovementFood>().ReturnBackSingleFood(food);
            foodComeBack = true;

        }

    }
}
