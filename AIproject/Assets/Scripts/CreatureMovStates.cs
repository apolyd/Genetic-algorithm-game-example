using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatureMovStates : MonoBehaviour
{
    public GameObject[] Waypoint;  //some points of interest for the slime to go
    public GameObject FoodReserve, WaterReserve, Creature;
    public NavMeshAgent agent;
    public Animator anim;
    public int wanderFlag = 0;
    public int toGo = 0;
    private int lastWaypoint = 0;

    public enum States  //enumeration of the states to use for the slime
    {
        Wander = 0,
        Hungry = 1,
        Thirsty = 2,
       
    }

    public int lockState = 0; // lock a state and try to complete it otherwise there is going to be a race problem
    public States state; //declare
    
    // Start is called before the first frame update
    void Start()
    {
        FoodReserve = GameObject.FindGameObjectWithTag("FoodTank");
        WaterReserve = GameObject.FindGameObjectWithTag("WaterTank");
        state = States.Wander;  // define the default state of each slime spawn as wander
        wanderFlag = 1;
        toGo = Random.Range(0, 3);
        lastWaypoint = toGo;
        anim.SetBool("Walking", true);
    }

    // Update is called once per frame
    void Update()
    {
        //every update check the hunger and thirst. If these are satisfied the slime just wanders
        if(Creature.GetComponent<CreatureAI>().Hunger < 50f && lockState != 1 && FoodReserve.GetComponent<FoodTankAI>().Food - (100f - gameObject.GetComponent<CreatureAI>().Hunger) > 0f)//check hunger here
        {
            state = States.Hungry;
            lockState = 1;
        }

        if(Creature.GetComponent<CreatureAI>().Thirst < 50f && lockState !=1 && WaterReserve.GetComponent<WaterTankAI>().Water - (100f - gameObject.GetComponent<CreatureAI>().Thirst) > 0f) //check water here
        {
            state = States.Thirsty;
            lockState = 1;
        }

        switch (state)
        {
            case States.Wander:
                if(wanderFlag == 0)
                {
                    wanderFlag = 1;
                    toGo = Random.Range(0, 3);
                    if (lastWaypoint == toGo)
                    {
                        if (toGo == 2)
                        {
                            toGo = 0;
                            lastWaypoint = toGo;
                        }
                        else
                        {
                            toGo += 1;
                            lastWaypoint = toGo;
                        }
                    }
                    lastWaypoint = toGo;
                }
               
               
                agent.SetDestination(Waypoint[toGo].transform.position);
                break;
            case States.Hungry:
                agent.SetDestination(Waypoint[3].transform.position);
                break;
            case States.Thirsty:
                agent.SetDestination(Waypoint[4].transform.position);
                break;

        }
    }
}
