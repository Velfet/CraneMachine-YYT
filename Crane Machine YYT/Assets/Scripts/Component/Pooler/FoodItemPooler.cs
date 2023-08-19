using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItemPooler : BasePooler<FoodItem>
{
    private List<FoodItem> activeFoodItem;

    public FoodItem GetFoodItem()
    {
        return GetObject();
    }

    public void ReturnFoodItem(FoodItem returnedObject)
    {
        activeFoodItem = GetAllUsedObjects();

        if(activeFoodItem.Contains(returnedObject) == true)
        {
            ReturnObject(returnedObject);
        }
        else
        {
            Debug.LogWarning("Food Item : " + returnedObject.name + " not on the pooler list");
        }
    }

    public void ReturnAllFoodItem()
    {
        activeFoodItem = GetAllUsedObjects();

        while(activeFoodItem.Count > 0)
        {
            ReturnFoodItem(activeFoodItem[0]);
        }
    }
}
