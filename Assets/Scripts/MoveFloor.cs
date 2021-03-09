using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveFloor : MonoBehaviour
{ 
    GameObject Moveable;
    int Time = 1;
    void Start()
    {
        Moveable = this.gameObject;
    }

    // Update is called once per frame
    void fixedUpdate()
    {
     
        Moveable.GetComponent<Rigidbody>().AddForce(new Vector3(10,0,0), ForceMode.Acceleration);
        Moveable.transform.position += new Vector3(1,0,0);
       
    }
}
