using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBot : MonoBehaviour
{
    public GameObject Prefab;
    public int HowMany;
    public int timer;
    public int timerCheck;
    bool stopSpawning = true;

    public int clicked;
    public bool selected;

    GameObject Bot;

    public SceneManagerScript SceneManager;
    private void OnMouseDown()
    {
        clicked++;
        selected = true;
        Debug.Log(clicked);
    }
    private void FixedUpdate()
    {
        timer++;
        if (timer > 480)
        {
            if (stopSpawning == true)
            {
                Bot = Instantiate(Prefab, this.transform.position, Quaternion.identity);
                Bot.transform.position = new Vector3(Random.Range(0, 4), Random.Range(-1, 1), Random.Range(0, 4));
            }
            stopSpawning = false;

            if (Input.GetMouseButtonDown(0))
            {
                Renderer rendier = Bot.GetComponent<Renderer>();
                if (rendier.isVisible)
                {
                    SceneManager.LoadScene(3);
                }
            }
        }
       
    }
}
