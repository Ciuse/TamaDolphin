using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSingleFoodObservation : MonoBehaviour
{

    public GameObject foodBucket;
    public GameObject foodSingle;

    public void MovementSingleFood()
    {

        if (foodBucket != null && foodSingle !=null)
        {

            foodBucket.GetComponent<MovementFood>().enabled = true;
            foodBucket.GetComponent<MovementFood>().SetPositionFoodBucketTop(foodBucket);
            foodSingle.GetComponent<MovementFood>().enabled = true;
            foodSingle.GetComponent<MovementFood>().SetPositionFoodBucketTop(foodBucket);
        }

    }



    public void SingleFoodReturnBack()
    {
        if (foodBucket != null && foodSingle != null)
        {
            foodBucket.GetComponent<MovementFood>().enabled = true;
            foodBucket.GetComponent<MovementFood>().SetPositionFoodBucketDown(foodBucket);
            foodSingle.GetComponent<MovementFood>().enabled = true;
            foodSingle.GetComponent<MovementFood>().SetPositionFoodBucketDown(foodBucket);

        }

    }
    
}
