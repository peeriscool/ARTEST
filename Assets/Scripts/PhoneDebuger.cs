using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneDebuger : MonoBehaviour
{
    int Time = 0;
    Text Logger;
    // Start is called before the first frame update
    void Start()
    {
        Logger = GetComponent<Text>();
      //  ClearLog();
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

    private void FixedUpdate()
    {
        Time++;
        if(Time > 60)
        {
            Pushmessage(GameObject.Find("AR Camera").transform.position.ToString() );
            Time = 0;
            Debug.Log("Location");
        }
    }
}
