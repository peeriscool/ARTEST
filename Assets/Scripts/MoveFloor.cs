using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveFloor : MonoBehaviour
{ 
    GameObject Moveable;
    int Time = 1;
    Vector3 resetpos = new Vector3(-200,0,0);
    void Start()
    {
        Moveable = this.gameObject;
    }

    private void FixedUpdate()
    {
        //Moveable.GetComponent<Rigidbody>().AddForce(new Vector3(10, 0, 0), ForceMode.Acceleration);
        Moveable.transform.position -= new Vector3(0.1f, 0, 0);
        if(Moveable.transform.position.x < resetpos.x)
        {
            Moveable.transform.position = new Vector3(-166.7f, 0.6f, -0.7f);
        }
    }
}
