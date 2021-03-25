using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdGenerator : MonoBehaviour
{
    public GameObject spawnPos;
    public GameObject objectToSpawn;
    bool stopSpawning;
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
            spawnDelay = Random.Range(2, 6);
            if (stopSpawning)
            {
                CancelInvoke("SpawnObject");
            }
        }
        else
        {
            GameObject bird = Instantiate(objectToSpawn, spawnPos.transform.position, transform.rotation);
            bird.transform.position = new Vector3(transform.position.x + Random.Range(0, -10), transform.position.y, transform.position.z + Random.Range(0,-10));
            spawnDelay = Random.Range(2, 6);
            if (stopSpawning)
            {
                CancelInvoke("SpawnObject");
            }
        }
    }
}

//public GameObject spawnPos;
//public GameObject objectToSpawn;
//bool stopSpawning;
//public float spawnTime;
//public float spawnDelay;

//public bool isBird;

//// Start is called before the first frame update
//void Start()
//{
//    stopSpawning = false;
//}

//public void SpawnObject()
//{
//    if (isBird)
//    {
//        Instantiate(objectToSpawn, new Vector3(spawnPos.transform.position.x, spawnPos.transform.position.y, spawnPos.transform.position.z), transform.rotation);
//        spawnDelay = Random.Range(2, 6);
//    }
//    else
//    {
//        GameObject bird = Instantiate(objectToSpawn, spawnPos.transform.position, transform.rotation);
//        bird.transform.position = new Vector3(transform.position.x + Random.Range(-2, 5), transform.position.y, transform.position.z + Random.Range(-2, 5));
//        spawnDelay = Random.Range(2, 6);

//    }
//}
