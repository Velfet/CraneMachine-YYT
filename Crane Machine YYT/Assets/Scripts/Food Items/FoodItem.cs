using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    [SerializeField] private int FoodScoreValue;
    [SerializeField] private FoodItemSpawner FoodItemSpawner;   //The Food Item Spawner that was most recently responsible for spawning the fruit

    public void SetUpFoodItem(Transform parentTransform, FoodItemSpawner foodItemSpawner)
    {
        //Set up food's position
        transform.position = parentTransform.position;
        //Randomize food's rotation
        float randomRot = UnityEngine.Random.Range(0f, 360f);
        transform.rotation = quaternion.EulerXYZ(0f, randomRot, 0f);
        //Set up food's spawner
        FoodItemSpawner = foodItemSpawner;

        gameObject.SetActive(true);
    }

    public void ReturnFoodItem()
    {
        //Return self to its food pooler throught the food spawner
        FoodItemSpawner.ReturnFoodItem(this);
    }

    public int GetFoodScoreValue()
    {
        return FoodScoreValue;
    }
}
