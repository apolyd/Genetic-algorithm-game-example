using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodTankAI : MonoBehaviour
{
    public float Food;
    public Text FoodText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FoodText.text = Food.ToString();
    }

    public void FillFoodAI()
    {
        Food += 50f;
    }
}
