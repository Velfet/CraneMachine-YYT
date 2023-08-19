using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItemSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> FoodSpawnPosition;

    private FoodItemPooler FoodItemPooler;

    private void Awake()
    {
        FoodItemPooler = GameStatusManager.GetInstance().GetFoodItemPooler();
    }

    private void Start()
    {
        SpawnFoodItems();
    }

    private void SpawnFoodItems()
    {
        //Spawn as many foods as there are Food Spawn Position(s)
        for(int i = 0; i < FoodSpawnPosition.Count; i++)
        {
            FoodItem foodItem = FoodItemPooler.GetFoodItem();
            foodItem.SetUpFoodItem(FoodSpawnPosition[i], this);
        }
    }

    public void ReturnFoodItem(FoodItem returnedFoodItem)
    {
        //Return the food item to the food pooler
        FoodItemPooler.ReturnFoodItem(returnedFoodItem);
    }

    public void RespawnFoodItems()
    {
        //Return all food items
        FoodItemPooler.ReturnAllFoodItem();
        //Spawn food items
        SpawnFoodItems();
    }
}
