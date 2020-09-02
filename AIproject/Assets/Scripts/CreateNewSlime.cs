using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewSlime : MonoBehaviour
{
    public GameObject Slime;
    public GameObject SelectionManager;
    public float[] Parent1 = new float[6], Parent2 = new float[6];
    public float Cooldown = 60f;
    public bool PlayerClicked = false;
    // Start is called before the first frame update
    void Start()
    {
      ///  InstantiateSlime();


    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerClicked == true)
        {
            Cooldown -= Time.deltaTime;
        }

        if(Cooldown <= 0)
        {
            PlayerClicked = false;
            Cooldown = 60f;
        }

        if (SelectionManager.GetComponent<SelectionManager>().parent1Selected == true && SelectionManager.GetComponent<SelectionManager>().parent2Selected == true && PlayerClicked == false)
        {
            InstantiateSlime();
            //reset parentselected flags and parent gene arrays!
            SelectionManager.GetComponent<SelectionManager>().parent1Selected = false;
            SelectionManager.GetComponent<SelectionManager>().parent2Selected = false;
            //dont spam slimes
            PlayerClicked = true;
        }
    }

    public void addParent(float hunger, float water, float temperature, float light, float hygiene, float death, int parentNumber) //save the parents genes here
    {
        if(parentNumber == 1)
        {
            Parent1[0] = hunger;
            Parent1[1] = water;
            Parent1[2] = temperature;
            Parent1[3] = light;
            Parent1[4] = hygiene;
            Parent1[5] = death;
        }

        if (parentNumber == 2)
        {
            Parent2[0] = hunger;
            Parent2[1] = water;
            Parent2[2] = temperature;
            Parent2[3] = light;
            Parent2[4] = hygiene;
            Parent2[5] = death;
        }
    }
    
    public void InstantiateSlime() //create the slime
    {
        Instantiate(Slime, transform.position, transform.rotation);
        
    }

    
}
