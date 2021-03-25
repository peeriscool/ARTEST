using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdGenerator : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject spawnPos;
    public bool stopSpawning;
    public float spawnTime;
    public float spawnDelay;

    public bool isBird;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        stopSpawning = false;
    }

    public void SpawnObject()
    {
        if (isBird)
        {
            Instantiate(objectToSpawn, spawnPos.transform.position, transform.rotation);
            spawnDelay = Random.Range(2, 10);
            if (stopSpawning)
            {
                CancelInvoke("SpawnObject");
            }
        }
        else
        {
            Instantiate(objectToSpawn, new Vector2(spawnPos.transform.position.x, -0.8f), transform.rotation);
            spawnDelay = Random.Range(2, 10);
            if (stopSpawning)
            {
                CancelInvoke("SpawnObject");
            }
        }
    }
}
