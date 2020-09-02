using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HygieneAI : MonoBehaviour
{
    public Text HygieneText;
    public float Hygiene;
    public GameObject[] creaturesCurrent;
    public float decay;
    public const float standardDecay = 5f;
    // Start is called before the first frame update
    void Start()
    {
        HygieneText.text = Hygiene.ToString();
        decay = standardDecay;
    }

    // Update is called once per frame
    void Update()
    {
        HygieneText.text = Hygiene.ToString();
        creaturesCurrent = GameObject.FindGameObjectsWithTag("Slime");
        decay -= Time.deltaTime;
        if(decay < 0)
        {
            Hygiene -= 10;
            decay = standardDecay;
        }

        if(Hygiene < 0)
        {
            Hygiene = 0;
        }
        
    }

    public void Clean()
    {
        Hygiene += 25f;
        if(Hygiene >100)
        {
            Hygiene = 100;
        }
    }
}
