using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPannel : MonoBehaviour
{
    int Time = 0;
    public GameObject Panel;
    List<GameObject> Panels;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Time++;
        if (Time > 120)
        {
            GameObject.Instantiate(Panel);
            Panels.Add(Panel);
            Panel.transform.position = new Vector3(Random.value*3,0, Random.value*3);
            Time = 0;
            Debug.Log("Location");
        }
       
    }
}
// PlayerScript requires the GameObject to have a Rigidbody component
[RequireComponent(typeof(BoxCollider))]
public class SolarObject : MonoBehaviour
{
    BoxCollider bx;

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
       
    }
}
