using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupNewSlime : MonoBehaviour
{
    public GameObject parentDetails; 
    void OnTriggerEnter(Collider other)
    {
        System.Random rnd = new System.Random(); //mutation
        System.Random rndParent = new System.Random(); //parent genes
        int randMutationMax = 101; // 1% chance to mutate
        int randParentMax = 3; //50% parent chance to get the gene
        if (rnd.Next(1, randMutationMax) == 1) //food passing genes
        {
            other.GetComponent<CreatureAI>().foodDecay = Random.Range(1.0f, 10.0f);
            other.GetComponent<CreatureAI>().foodGene = other.GetComponent<CreatureAI>().foodDecay;   //mutation
        }
        else
        {
            if(rndParent.Next(1,randParentMax) == 1)  //choose parent 1
            {
                other.GetComponent<CreatureAI>().foodDecay = parentDetails.GetComponent<CreateNewSlime>().Parent1[0];
                other.GetComponent<CreatureAI>().foodGene = other.GetComponent<CreatureAI>().foodDecay;
            }
            else                                    //choose parent 2
            {
                other.GetComponent<CreatureAI>().foodDecay = parentDetails.GetComponent<CreateNewSlime>().Parent2[0];
                other.GetComponent<CreatureAI>().foodGene = other.GetComponent<CreatureAI>().foodDecay;
            }
            
        }
        //*******************************************************************************************************************//
        if (rnd.Next(1, randMutationMax) == 1) //water passing genes
        {
            other.GetComponent<CreatureAI>().waterDecay = Random.Range(1.0f, 10.0f);
            other.GetComponent<CreatureAI>().waterGene = other.GetComponent<CreatureAI>().waterDecay;   //mutation
        }
        else
        {
            if (rndParent.Next(1, randParentMax) == 1)  //choose parent 1
            {
                other.GetComponent<CreatureAI>().waterDecay = parentDetails.GetComponent<CreateNewSlime>().Parent1[1];
                other.GetComponent<CreatureAI>().waterGene = other.GetComponent<CreatureAI>().waterDecay;
            }
            else                                    //choose parent 2
            {
                other.GetComponent<CreatureAI>().waterDecay = parentDetails.GetComponent<CreateNewSlime>().Parent2[1];
                other.GetComponent<CreatureAI>().waterGene = other.GetComponent<CreatureAI>().waterDecay;
            }

        }
        //*******************************************************************************************************************//
        if (rnd.Next(1, randMutationMax) == 1) //temperature passing genes
        {
            other.GetComponent<CreatureAI>().temperatureDecay = Random.Range(20.0f, 50.0f);
            other.GetComponent<CreatureAI>().temperatureGene = other.GetComponent<CreatureAI>().temperatureDecay;   //mutation
        }
        else
        {
            if (rndParent.Next(1, randParentMax) == 1)  //choose parent 1
            {
                other.GetComponent<CreatureAI>().temperatureDecay = parentDetails.GetComponent<CreateNewSlime>().Parent1[2];
                other.GetComponent<CreatureAI>().temperatureGene = other.GetComponent<CreatureAI>().temperatureDecay;
            }
            else                                    //choose parent 2
            {
                other.GetComponent<CreatureAI>().temperatureDecay = parentDetails.GetComponent<CreateNewSlime>().Parent2[2];
                other.GetComponent<CreatureAI>().temperatureGene = other.GetComponent<CreatureAI>().temperatureDecay;
            }

        }
        //*******************************************************************************************************************//
        if (rnd.Next(1, randMutationMax) == 1) //Light passing genes
        {
            other.GetComponent<CreatureAI>().lightDecay = Random.Range(0.1f, 1f);
            other.GetComponent<CreatureAI>().lightGene = other.GetComponent<CreatureAI>().lightDecay;   //mutation
        }
        else
        {
            if (rndParent.Next(1, randParentMax) == 1)  //choose parent 1
            {
                other.GetComponent<CreatureAI>().lightDecay = parentDetails.GetComponent<CreateNewSlime>().Parent1[3];
                other.GetComponent<CreatureAI>().lightGene = other.GetComponent<CreatureAI>().lightDecay;
            }
            else                                    //choose parent 2
            {
                other.GetComponent<CreatureAI>().lightDecay = parentDetails.GetComponent<CreateNewSlime>().Parent2[3];
                other.GetComponent<CreatureAI>().lightGene = other.GetComponent<CreatureAI>().lightDecay;
            }

        }
        //*******************************************************************************************************************//
        if (rnd.Next(1, randMutationMax) == 1) //Hygiene passing genes
        {
            other.GetComponent<CreatureAI>().hygieneDecay = Random.Range(10.0f, 60.0f);
            other.GetComponent<CreatureAI>().hygieneGene = other.GetComponent<CreatureAI>().hygieneDecay;   //mutation
        }
        else
        {
            if (rndParent.Next(1, randParentMax) == 1)  //choose parent 1
            {
                other.GetComponent<CreatureAI>().hygieneDecay = parentDetails.GetComponent<CreateNewSlime>().Parent1[4];
                other.GetComponent<CreatureAI>().hygieneGene = other.GetComponent<CreatureAI>().hygieneDecay;
            }
            else                                    //choose parent 2
            {
                other.GetComponent<CreatureAI>().hygieneDecay = parentDetails.GetComponent<CreateNewSlime>().Parent2[4];
                other.GetComponent<CreatureAI>().hygieneGene = other.GetComponent<CreatureAI>().hygieneDecay;
            }

        }
        //*******************************************************************************************************************//
        if (rnd.Next(1, randMutationMax) == 1) //Death passing genes
        {
            other.GetComponent<CreatureAI>().deathDecay = Random.Range(60.0f, 180.0f);
            other.GetComponent<CreatureAI>().deathDecayGene = other.GetComponent<CreatureAI>().deathDecay;   //mutation
        }
        else
        {
            if (rndParent.Next(1, randParentMax) == 1)  //choose parent 1
            {
                other.GetComponent<CreatureAI>().deathDecay = parentDetails.GetComponent<CreateNewSlime>().Parent1[5];
                other.GetComponent<CreatureAI>().deathDecayGene = other.GetComponent<CreatureAI>().deathDecay;
            }
            else                                    //choose parent 2
            {
                other.GetComponent<CreatureAI>().deathDecay = parentDetails.GetComponent<CreateNewSlime>().Parent2[5];
                other.GetComponent<CreatureAI>().deathDecayGene = other.GetComponent<CreatureAI>().deathDecay;
            }

        }
        //*******************************************************************************************************************//

    }
}
