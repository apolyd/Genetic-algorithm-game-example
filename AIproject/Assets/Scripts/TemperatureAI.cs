using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureAI : MonoBehaviour
{
    public Text TemperatureText;
    public float Temperature;
    public Slider mySlider;
    // Start is called before the first frame update
    void Start()
    {
        mySlider.value = Temperature/100f;
    }

    // Update is called once per frame
    void Update()
    {
        Temperature = mySlider.value * 100;
        TemperatureText.text = (mySlider.value * 100).ToString();
    }
}
