using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;
    //public int HowMany;
    public int timer;
    public int timerCheck;

    private void Update()
    {
        timer += 1;
        if(timer > timerCheck)
        {
            Instantiate(Prefab, this.transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
