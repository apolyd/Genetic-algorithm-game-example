using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightAI : MonoBehaviour
{
    public float Light;
    public Text LightText;
    public Slider mySlider;
    public GameObject LightSource;
    // Start is called before the first frame update
    void Start()
    {
        mySlider.value = Light;
    }

    // Update is called once per frame
    void Update()
    {
        LightSource.GetComponent<Light>().intensity = mySlider.value;
        LightText.text = (mySlider.value * 100).ToString();
    }
}
