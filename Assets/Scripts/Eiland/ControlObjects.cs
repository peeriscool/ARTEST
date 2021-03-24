using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlObjects : MonoBehaviour
{
    public GameObject Movable;
    public bool X_axis;
    public bool Y_axis;
    // Start is called before the first frame update
    PhoneDebuger log;
    void Start()
    {
        log = FindObjectOfType<PhoneDebuger>();
    }

    // Update is called once per frame
    public void Slider(Slider control) //add max and min value
    {
     if(control.value > 0.5f && X_axis)
        {
        //    log.Pushmessage("Right slider");
            Movable.transform.position = Movable.transform.position + new Vector3(control.value / 10,0,0);
           // control.value = 0.5f;
        }
        if (control.value < 0.5f && X_axis)
        {
         //   log.Pushmessage("Left slider");
            Movable.transform.position = Movable.transform.position + new Vector3(-control.value / 10, 0, 0);
           // control.value = 0.5f;
        }
        if (control.value > 0.5f && Y_axis)
        {
            //    log.Pushmessage("Right slider");
            Movable.transform.position = Movable.transform.position + new Vector3(0,0,control.value / 10 );
           // control.value = 0.5f;
        }
        if (control.value < 0.5f && Y_axis)
        {
            //   log.Pushmessage("Left slider");
            Movable.transform.position = Movable.transform.position + new Vector3(0,0,-control.value / 10);
            //control.value = 0.5f;
        }
    }

    public void RotateSlider(Slider control)
    {
        if (control.value > 0.5f)
        {
           // log.Pushmessage("Right slider");
            Movable.transform.Rotate(0,2,0,Space.Self);
            control.value = 0.5f;
        }
        if (control.value < 0.5f)
        {
          //  log.Pushmessage("Left slider");
            Movable.transform.Rotate(0, -2, 0, Space.Self);
            control.value = 0.5f;
        }
    }
}
