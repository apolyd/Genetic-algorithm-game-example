using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBump : MonoBehaviour
{
    public int myNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        switch (gameObject.tag)
        {
            case "Tire":
                myNumber = 0;
                break;
            case "Tree1":
                myNumber = 1;
                break;
            case "Tree2":
                myNumber = 2;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slime"))
        {
            Debug.Log("Slime reached destination");
            if(other.GetComponent<CreatureMovStates>().state == CreatureMovStates.States.Wander && myNumber == other.GetComponent<CreatureMovStates>().toGo)
            {
                other.GetComponent<CreatureMovStates>().wanderFlag = 0;
            }
            //other.GetComponent<CreatureMovStates>().wanderFlag = 0;
        }
    }

    }
