using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckVictoryConditions : MonoBehaviour
{
    public int SlimesAlive;
    public float initTime;
    public Text SlimesText;
    // Start is called before the first frame update
    void Start()
    {
        SlimesAlive = 0;
        initTime = 12f;
    }

    // Update is called once per frame
    void Update()
    {
        if(initTime < 1f)
        {//wait for the slimes to spawn and then count their number to keep track of them
            GameObject[] slimes = GameObject.FindGameObjectsWithTag("Slime");
            SlimesAlive = slimes.Length;
            SlimesText.text = SlimesAlive.ToString();
        }

        if(initTime > 0)
        {
            initTime -= Time.deltaTime;
        }
        
        if(SlimesAlive >= 40 && initTime <=0) //victory screen
        {
            Debug.Log("Victory");
            SceneManager.LoadScene(1);
        }

        if (SlimesAlive <= 1 && initTime <= 0)  //defeat screen
        {
            Debug.Log("Loss");
            SceneManager.LoadScene(2);
        }
    }
}
