using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDetector : MonoBehaviour
{
    [SerializeField] private CraneMovement Crane;
    [SerializeField] private string FoodItems_Tag;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == FoodItems_Tag)
        {
            GameObject foodObject = collider.gameObject;
            //Add food object to the list if it is not yet in the list
            Crane.AddFoodObject(foodObject);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == FoodItems_Tag)
        {
            GameObject foodObject = collider.gameObject;
            //Remove food object from the list if it is in the list
            Crane.RemoveFoodObject(foodObject);
        }
    }
}
