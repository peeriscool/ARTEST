using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeScript : MonoBehaviour
{
    Vector2 startPos, endPos, Direction;
    float TouchTimestart, TouchTimeFinish, Timeinterval;
    bool reset = false;
    [Range(0.05f, 1f)]
    public float Throwforce = 0.3f;
    public GameObject startpos;

    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && reset == false)
        {  
            TouchTimestart = Time.time;
            startPos = Input.GetTouch(0).position;
            reset = true;
        }
        if(Input.touchCount> 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            TouchTimeFinish = Time.time;

            Timeinterval = TouchTimeFinish - TouchTimestart;

            endPos = Input.GetTouch(0).position;

            Direction = startPos - endPos;
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //TODO make vector 3 for direction 
            GetComponent<Rigidbody>().AddForce(-Direction/Timeinterval * Throwforce);

            StartCoroutine(resetbool());
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
           StartCoroutine(resetbool());
            
        }
    }
    IEnumerator resetbool()
    {
       // GameObject.Find("PhoneDebugger").GetComponent<PhoneDebuger>().SendMessage("Reset bool");
        yield return new WaitForSeconds(5f);
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        this.gameObject.transform.position = startpos.transform.position;
        reset = false;
        Debug.Log("respawn");
    }
}
