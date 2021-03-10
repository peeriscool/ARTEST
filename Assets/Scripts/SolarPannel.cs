using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPannel : MonoBehaviour
{
    int Time = 0;
    int spawns = 0;
    public GameObject Panel;
    List<GameObject> Panels = new List<GameObject>();
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        Time++;
        if (Time > 120)
        {
            GameObject Instance =  GameObject.Instantiate(Panel);
            Panels.Add(Instance);
            Instance.transform.position = new Vector3(Random.value*3,0, Random.value*3);
            Time = 0;
            spawns += 1;
            Debug.Log("Location is: " + Instance.transform.position.ToString());
            Instance.AddComponent<BoxCollider>();
            SolarObject Solarscript = Instance.AddComponent<SolarObject>();

        }
       
    }
}
// PlayerScript requires the GameObject to have a Rigidbody component
[RequireComponent(typeof(BoxCollider))]
public class SolarObject : MonoBehaviour
{
    BoxCollider bx;
    int liveTime = 5;
   
    void Start()
    {
        bx = GetComponent<BoxCollider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        Destroy(this.gameObject, 1f);
    }
}
