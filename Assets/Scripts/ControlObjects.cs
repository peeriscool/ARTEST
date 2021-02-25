using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Slider(Slider control)
    {
     if(control.value > 0.5f)
        {
            FindObjectOfType<PhoneDebuger>().SendMessage("Right slider");
            this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(1,0,0);
        }
        if (control.value < 0.5f)
        {
            FindObjectOfType<PhoneDebuger>().SendMessage("Left slider");
            this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(-1, 0, 0);
        }
    }
}
