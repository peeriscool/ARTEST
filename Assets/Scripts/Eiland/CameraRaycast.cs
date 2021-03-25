using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    GameObject origin;
    public List<Canvas> levelselctions;
    // Start is called before the first frame update
    void Start()
    {
        origin = this.gameObject;
        for (int i = 0; i < levelselctions.Count; i++)
        {
            levelselctions[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(origin.transform.position.ToString());
       // Debug.DrawRay(origin.transform.position,Vector3.forward,Color.red);
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
            if(hit.transform.tag == "ArClickable" )
            {
                if(hit.transform.name == "Energybots_Wind")
                {
                    levelselctions[0].enabled = true;
                }
                if (hit.transform.name == "Energybots_solarpanel")
                {
                    levelselctions[2].enabled = true;
                }
                if(hit.transform.name == "Energybots_Coal")
                {
                    levelselctions[1].enabled = true;
                }
                //else
                //{ 
                //levelselctions[0].enabled = true;
                //}
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
           // Debug.Log("Did not Hit");
            for (int i = 0; i < levelselctions.Count; i++)
            {
                levelselctions[i].enabled = false;
            }
        }
    }
}
