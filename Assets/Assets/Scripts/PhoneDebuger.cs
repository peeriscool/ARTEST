using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneDebuger : MonoBehaviour
{

    Text Logger;
    // Start is called before the first frame update
    void Start()
    {
        Logger = GetComponent<Text>();
        ClearLog();
    }

    // Update is called once per frame
    public void Pushmessage(string message)
    {
        Logger.text = message;
    }
    public void ClearLog()
    {
        Logger.text = "";
    }
}
