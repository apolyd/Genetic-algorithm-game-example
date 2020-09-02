using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterTankAI : MonoBehaviour
{
    public float Water;
    public Text WaterText;
    // Start is called before the first frame update
    void Start()
    {
        //WaterText.text = Water.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        WaterText.text = Water.ToString();
    }

    public void FillWaterAI()
    {
        Water += 50f;
    }
}
