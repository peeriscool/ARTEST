using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    bool levelplaced = false;
    public GameObject CameraOrigin;
    public GameObject LevelPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Shoot()
    {
        Vector3 center = new Vector3(0.5f, 0.5f, 0f);
        Camera.main.ViewportPointToRay(center);
        if (!levelplaced) //first time spawn plane
        {
            // Physics2D.Raycast(screenCenter,Vector2.zero);
            //Debug.DrawRay(center, Vector2.up, Color.red, 5f);
            GameObject locationindicator = GameObject.Instantiate(LevelPrefab);
            locationindicator.transform.localScale =  new Vector3(1f, 1f, 1f);
            locationindicator.transform.position = CameraOrigin.transform.position + new Vector3(0,-2,0);
           // locationindicator.AddComponent<BoxCollider>();
            Debug.Log("Placed");
            levelplaced = true;
        }
        else
        {
            Debug.DrawRay(CameraOrigin.transform.position, Vector2.one, Color.red, 5f);
            GameObject locationindicator = GameObject.CreatePrimitive(PrimitiveType.Cube);
            locationindicator.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            locationindicator.transform.position = CameraOrigin.transform.position;
            locationindicator.transform.rotation = CameraOrigin.transform.rotation;
            locationindicator.AddComponent<BoxCollider>();
            locationindicator.AddComponent<Rigidbody>().AddForce(locationindicator.transform.forward *2, ForceMode.VelocityChange);
            
            Debug.Log("Click");
        }
    }
}
