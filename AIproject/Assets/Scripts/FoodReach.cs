using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodReach : MonoBehaviour
{
    public GameObject FoodReserve;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slime"))
        {
            Debug.Log("Slime entered Food");
            if(FoodReserve.GetComponent<FoodTankAI>().Food > 100f - other.GetComponent<CreatureAI>().Hunger)
            {
                Debug.Log("Slime will try to eat");
                FoodReserve.GetComponent<FoodTankAI>().Food -= 100f - other.GetComponent<CreatureAI>().Hunger;
                other.GetComponent<CreatureAI>().Hunger = 100f;
                other.GetComponent<CreatureMovStates>().lockState = 0;
                other.GetComponent<CreatureMovStates>().state = CreatureMovStates.States.Wander;
            }
            else
            {
                Debug.Log("No more food for this slime.");
                other.GetComponent<CreatureMovStates>().lockState = 0;
                other.GetComponent<CreatureMovStates>().state = CreatureMovStates.States.Wander;
            }
        }
    }
}
