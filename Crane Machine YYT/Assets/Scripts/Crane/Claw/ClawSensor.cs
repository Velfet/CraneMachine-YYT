using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawSensor : MonoBehaviour
{
    [SerializeField] private CraneMovement CraneMovement;
    [SerializeField] private string FoodItems_Tag;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == FoodItems_Tag)
        {
            //Debug.LogWarning("Claw has touched food item");
            CraneMovement.CraneExtendFinishedMidway();
        }
    }
}
