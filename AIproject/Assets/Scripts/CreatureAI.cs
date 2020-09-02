using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreatureAI : MonoBehaviour
{
    public GameObject lightSource;
    public GameObject hygieneRoom;
    public GameObject temperatureSource;
    public float Hunger;
    public float Thirst;
    public float Temperature;
    public float Light;
    public float Hygiene;
  //  public float Happiness;
    public float foodDecay,foodGene;
    public float waterDecay, waterGene;
    public float temperatureDecay, temperatureGene;
    public float lightDecay, lightGene;
    public float hygieneDecay, hygieneGene;
    public GameObject instance;
    //**global decay factor **//
    public float globalDecayFactor = 10f;
    //********new variables
    public float lightDecayCooldown = 60f; //if the slime stays 20 seconds CONTINUESLY in wrong light conditions it will die  
    public float HygieneDecayCooldown = 60f;//if the slime stays 20 seconds CONTINUESLY in wrong hygiene conditions it will die  
    public float deathDecay, deathDecayGene;
    //********decay factors would be random.
  
    


    //private GameObject[] respawns;
    // Start is called before the first frame update
    void Start()
    {
        //instance = (GameObject)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Slime.prefab", typeof(GameObject));
        
        lightSource = GameObject.FindGameObjectWithTag("Light");
        temperatureSource = GameObject.FindGameObjectWithTag("TemperatureSlider");
        //setup
        Hunger = 100f;
        Thirst = 100f;
        Temperature = 25f;
        Light = lightSource.GetComponent<Light>().intensity;
        Hygiene = hygieneRoom.GetComponent<HygieneAI>().Hygiene;
        foodDecay = Random.Range(1.0f, 10.0f);
        waterDecay = Random.Range(1.0f, 10.0f);
        temperatureDecay = Random.Range(20.0f, 50.0f);
        lightDecay = Random.Range(0.1f, 1f);
        hygieneDecay = Random.Range(10.0f, 60.0f);
        deathDecay = Random.Range(60.0f, 180.0f);
        foodGene = foodDecay;
        waterGene = waterDecay;
        temperatureGene = temperatureDecay;
        lightGene = lightDecay;
        hygieneGene = hygieneDecay;
        deathDecayGene = deathDecay;

    }

    // Update is called once per frame
    void Update()
    {
        Light = lightSource.GetComponent<Light>().intensity;   //update light
        Hygiene = hygieneRoom.GetComponent<HygieneAI>().Hygiene;       //update hygiene

        globalDecayFactor -= Time.deltaTime;     //this is when we check and do calculations about the stats of the slime
        deathDecay -= Time.deltaTime;           //lifespan of a slime

        if (deathDecay < 0 || Hunger <= 0 || Thirst <= 0)  // if any of these happens the slime dies instantly
        {
            Destroy(gameObject);
        }

        if (Mathf.Abs(Light - lightDecay) > 0.2f)// if we have wrong light conditions
        {
            lightDecayCooldown -= Time.deltaTime;

            if (lightDecayCooldown <= 0)
            {
                Destroy(gameObject);  //destroy the object if it stayed 20 seconds in wrong light conditions
            }
        }
        else
        {
            lightDecayCooldown = 60f;  // reset the cooldown of the 20 seconds of being in wrong light conditions
        }

        //check the hygiene if the slime is below a certain value (gygieneDecay) for 20 seconds it dies
        if (Hygiene < hygieneDecay)
        {
            HygieneDecayCooldown -= Time.deltaTime;
            if (HygieneDecayCooldown <= 0)
            {
                Destroy(gameObject);  //destroy the object
            }

        }
        else
        {
            HygieneDecayCooldown = 60f;   // reset the cooldown
        }

        if (globalDecayFactor <= 0f)  //everything happens inside this if statement we check every "gene" of the slime
        {
            Hunger -= foodDecay;  //update hunger based on the food decay factor of each slime
            Thirst -= waterDecay; //update thirst based on the water decay factor of each slime

            //update the temperature and determine if the slime can survive under these circumstances
            if (Temperature < temperatureSource.GetComponent<TemperatureAI>().Temperature) //change the creatures temperature whether the environment's temperature is higher or lower
            {
                Temperature += 1.5f;              //temperature changes in intervals of 1.5 Celcius
                
            }
            else
            {
                Temperature -= 1.5f;
                
            }

            if(Mathf.Abs(Temperature - temperatureDecay) > 25f)  //The temperature must be between some range -+20 otherwise the creature dies
            {
                Destroy(gameObject);
            }

            //check the light value and determine if the slime can survive under these circumstances

            

            globalDecayFactor = 10f;

        }


        




       // Anim.SetBool("Walking", true);
    }
}
