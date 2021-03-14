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
    Vector3 startpos;
    private void Start()
    {
        startpos = this.gameObject.transform.position;
    }
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && reset == false)
        {
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            TouchTimestart = Time.time;
            startPos = Input.GetTouch(0).position;
        }
        if(Input.touchCount> 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            TouchTimeFinish = Time.time;

            Timeinterval = TouchTimeFinish - TouchTimestart;

            endPos = Input.GetTouch(0).position;

            Direction = startPos - endPos;

            GetComponent<Rigidbody>().AddForce(-Direction/Timeinterval * Throwforce);
            reset = true;
            resetbool();
        }
    }
    IEnumerator resetbool()
    {
        yield return new WaitForSeconds(4f);
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        this.gameObject.transform.position = startpos;
        reset = false;
    }
}
