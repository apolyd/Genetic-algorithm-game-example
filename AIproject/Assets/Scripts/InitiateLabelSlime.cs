using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitiateLabelSlime : MonoBehaviour
{
    public Text food,thirst,temperature,light,hygiene,death;
    // Start is called before the first frame update
    void Start()
    {
        CreatureAI slime = gameObject.GetComponent<CreatureAI>();
        food.text = slime.foodDecay.ToString();
        thirst.text = slime.waterDecay.ToString();
        temperature.text = slime.temperatureDecay.ToString();
        light.text = slime.lightDecay.ToString();
        hygiene.text = slime.hygieneDecay.ToString();
        death.text = slime.deathDecayGene.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        CreatureAI slime = gameObject.GetComponent<CreatureAI>();
        food.text = slime.foodDecay.ToString();
        thirst.text = slime.waterDecay.ToString();
        temperature.text = slime.temperatureDecay.ToString();
        light.text = slime.lightDecay.ToString();
        hygiene.text = slime.hygieneDecay.ToString();
        death.text = slime.deathDecayGene.ToString();
    }
}
