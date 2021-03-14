using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenForAudioCommand : MonoBehaviour
{

    public Rigidbody rb;
    public float slowdown;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float db = MicInput.MicLoudnessinDecibels;
       

        if (db < 1 && db > -10f)
        {
            rb.AddForce(new Vector3(1.5f, 0, 0), ForceMode.Impulse);

        }
        else
        {
            rb.velocity = rb.velocity * slowdown * Time.deltaTime;
        }

        //Debug.Log("Volume is " + MicInput.MicLoudness.ToString("##.####") + ", decibels is :" + db.ToString());
    }
}
