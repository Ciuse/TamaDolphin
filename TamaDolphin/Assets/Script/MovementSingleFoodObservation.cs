using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSingleFoodObservation : MonoBehaviour
{

    public GameObject foodMultiple;
    public GameObject foodSingle;
    public GameObject bucket;
    

    public void MovementSingleFood()
    {

        if (foodMultiple != null && foodSingle !=null)
        {

            foodMultiple.GetComponent<MovementFood>().enabled = true;
            foodMultiple.GetComponent<MovementFood>().SetPositionFoodBucketTop();
            foodSingle.GetComponent<MovementFood>().enabled = true;
            foodSingle.GetComponent<MovementFood>().SetPositionFoodBucketTop();
           
        }

    }



    public void SingleFoodReturnBack()
    {
        if (foodMultiple != null && foodSingle != null)
        {
            foodMultiple.GetComponent<MovementFood>().enabled = true;
            foodMultiple.GetComponent<MovementFood>().SetPositionFoodBucketDown(bucket);
            foodSingle.GetComponent<MovementFood>().enabled = true;
            foodSingle.GetComponent<MovementFood>().SetPositionFoodBucketDown(bucket);

        }

    }
    
}
