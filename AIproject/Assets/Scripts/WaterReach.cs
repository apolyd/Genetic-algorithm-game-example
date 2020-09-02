using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterReach : MonoBehaviour
{
    public GameObject WaterReserve;
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
            Debug.Log("Slime entered Water");
            if (WaterReserve.GetComponent<WaterTankAI>().Water > 100f - other.GetComponent<CreatureAI>().Thirst)
            {
                Debug.Log("Slime will try to drink");
                WaterReserve.GetComponent<WaterTankAI>().Water -= 100f - other.GetComponent<CreatureAI>().Thirst;
                other.GetComponent<CreatureAI>().Thirst = 100f;
                other.GetComponent<CreatureMovStates>().lockState = 0;
                other.GetComponent<CreatureMovStates>().state = CreatureMovStates.States.Wander;
            }
            else
            {
                Debug.Log("No more water for this slime.");
                other.GetComponent<CreatureMovStates>().lockState = 0;
                other.GetComponent<CreatureMovStates>().state = CreatureMovStates.States.Wander;
            }
        }
    }
}
