using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdGenerator : MonoBehaviour
{
    public GameObject spawnPos;
    public GameObject objectToSpawn;
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
            Instantiate(objectToSpawn, new Vector3(spawnPos.transform.position.x , spawnPos.transform.position.y, spawnPos.transform.position.z ), transform.rotation);
            spawnDelay = Random.Range(2, 10);
            if (stopSpawning)
            {
                CancelInvoke("SpawnObject");
            }
        }
        else
        {
            Instantiate(objectToSpawn, new Vector3(spawnPos.transform.position.x + Random.Range(-2, 3), spawnPos.transform.position.y, spawnPos.transform.position.z + Random.Range(-2, 3)), transform.rotation);
            spawnDelay = Random.Range(2, 10);
            if (stopSpawning)
            {
                CancelInvoke("SpawnObject");
            }
        }
    }
}
