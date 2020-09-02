using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlime : MonoBehaviour
{
    public GameObject Slime;
    public float spawnTimer;
    public int slimeCount;
    public const int slimes = 10;
    public const float time = 1f;

        
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = time;
        slimeCount = slimes;
    }

    // Update is called once per frame
    void Update()
    {
        if(slimeCount > 0)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                Instantiate(Slime, transform.position, transform.rotation);
                slimeCount--;
                spawnTimer = time;
            }
            
        }
        
    }
}
