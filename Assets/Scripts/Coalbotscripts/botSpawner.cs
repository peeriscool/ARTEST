using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botSpawner : MonoBehaviour
{

    public GameObject objectToSpawn;
    public GameObject[] spawnPos;
    public bool stopSpawning;
    public float spawnTime;
    public float spawnDelay;

    public bool isEnemy;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        stopSpawning = false;
    }

    public void SpawnObject()
    {
        if (isEnemy)
        {
            int spawnLoc = Random.Range(0, spawnPos.Length);
            Instantiate(objectToSpawn, spawnPos[spawnLoc].transform.position, transform.rotation);
            spawnDelay = Random.Range(2, 10);
            if (stopSpawning)
            {
                CancelInvoke("SpawnObject");
            }
        }
    }
}
