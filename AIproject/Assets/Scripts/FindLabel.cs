using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindLabel : MonoBehaviour
{
    public GameObject Mylabel;
    // Start is called before the first frame update
    void Start()
    {
        Mylabel = GameObject.FindGameObjectWithTag("SlimeLabel");
        gameObject.GetComponent<LabelPopUp>().nameLabel = Mylabel;
        Mylabel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
