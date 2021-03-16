using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdMovement : MonoBehaviour
{
    public float maxWalkSpeed;
    public float minWalkSpeed;
    Vector3 playerVelocity;


    private Rigidbody rb;

    void Start()
    {
        playerVelocity = Vector3.zero;
        rb = this.gameObject.GetComponent<Rigidbody>();
       
    }

    void Update()
    {

        if (maxWalkSpeed > minWalkSpeed)
        {
            maxWalkSpeed = maxWalkSpeed - 0.09f;
        }

        if (maxWalkSpeed < minWalkSpeed)
        {

            maxWalkSpeed = maxWalkSpeed + 0.19f;
        }



        playerVelocity.x = Input.GetAxis("Horizontal") * maxWalkSpeed;

        rb.velocity = new Vector3(maxWalkSpeed, rb.velocity.y);
    }
}
