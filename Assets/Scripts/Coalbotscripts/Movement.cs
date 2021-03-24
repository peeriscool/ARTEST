using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
public class Movement : MonoBehaviour
{
    // Update is called once per frame
    public float standardSpeed;
    public float clickSpeed;
    public float Speed;
    public int timer;
    public int TimerCheck;

    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public bool detectSwipeOnlyAfterRelease = false;
    public bool selected;
    public int clicked;
    public float SWIPE_THRESHOLD = 20f;
    private int pointtime = 0;
    private List<float> Points = new List<float>();
    public Animator anim;


    private void OnMouseDown()
    {
        clicked++;
        selected = true;
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        Speed = standardSpeed;
    }
    private void FixedUpdate()
    {
        pointtime++;
        if (pointtime > 60)
        {
            Points.Add(9);
            //earned a point
            // pointsystem.WriteToJson(Points);
        }
    }
    void Update()
    {
        if (clicked >= 2)
        {
            selected = false;
            Speed = clickSpeed;
            for (int i = 0; i < 1000; i++)
            {
                if (i == 999)
                {
                    clicked = 0;
                }
                // anim.Play("looking");
            }
        }
        if (Speed == clickSpeed)
        {
            timer += 1;
            if (timer >= TimerCheck)
            {
                Speed = standardSpeed;
                timer = 0;
            }
        }
        if (true)
        {
            transform.Translate(Speed, 0, 0);
        }

        if (selected)
        {

            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    fingerUp = touch.position;
                    fingerDown = touch.position;
                }

                //Detects Swipe while finger is still moving
                if (touch.phase == TouchPhase.Moved)
                {
                    if (!detectSwipeOnlyAfterRelease)
                    {
                        fingerDown = touch.position;
                        checkSwipe();
                    }
                }

                //Detects swipe after finger is released
                if (touch.phase == TouchPhase.Ended)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }
        }
    }

    void checkSwipe()
    {


        //Check if Vertical swipe
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            //Debug.Log("Vertical");
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
                OnSwipeUp();
            }
            else if (fingerDown.y - fingerUp.y < 0)//Down swipe
            {
                OnSwipeDown();
            }
            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            //Debug.Log("Horizontal");
            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {
                OnSwipeRight();
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
            {
                OnSwipeLeft();
            }
            fingerUp = fingerDown;
        }

        //No Movement at-all
        else
        {
            //Debug.Log("No Swipe!");
        }
    }

    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    //////////////////////////////////CALLBACK FUNCTIONS/////////////////////////////
    void OnSwipeUp()
    {
        selected = false;
        clicked = 0;
        Debug.Log("Swipe UP");
        this.gameObject.transform.eulerAngles = new Vector3(this.gameObject.transform.eulerAngles.x, 90, this.gameObject.transform.eulerAngles.z);
    }

    void OnSwipeDown()
    {
        selected = false;
        clicked = 0;
        Debug.Log("Swipe Down");
        this.gameObject.transform.eulerAngles = new Vector3(this.gameObject.transform.eulerAngles.x, -90, this.gameObject.transform.eulerAngles.z);
    }

    void OnSwipeLeft()
    {
        selected = false;
        clicked = 0;
        Debug.Log("Swipe Left");
        this.gameObject.transform.eulerAngles = new Vector3(this.gameObject.transform.eulerAngles.x, 0, this.gameObject.transform.eulerAngles.z);
    }

    void OnSwipeRight()
    {
        selected = false;
        clicked = 0;
        Debug.Log("Swipe Right");
        this.gameObject.transform.eulerAngles = new Vector3(this.gameObject.transform.eulerAngles.x, -180, this.gameObject.transform.eulerAngles.z);
    }

   // public delegate void RobotDied(object sender, EventArgs e);
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Robot")
        {
            pointsystem.SavePoints(Points);
            //ScoreVisalizer myscore = new ScoreVisalizer();
            //myscore.Eventtrigger +=  new RobotDied(myscore.Eventtrigger);
            // += new RobotDied();
           //this.RobotDied += new RobotDied(Eventtrigger);
            Gamemanager.Instance.TakeDamage();

            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Top")
        {
            this.gameObject.transform.eulerAngles = new Vector3(
                this.gameObject.transform.eulerAngles.x,
                this.gameObject.transform.eulerAngles.y + Random.Range(80, 220),
                this.gameObject.transform.eulerAngles.z
            );
        }
        else if (collision.gameObject.tag == "Bottom")
        {
            this.gameObject.transform.eulerAngles = new Vector3(
                this.gameObject.transform.eulerAngles.x,
                this.gameObject.transform.eulerAngles.y + Random.Range(80, 220),
                this.gameObject.transform.eulerAngles.z
            );
        }
        else if (collision.gameObject.tag == "Left")
        {
            this.gameObject.transform.eulerAngles = new Vector3(
                this.gameObject.transform.eulerAngles.x,
                this.gameObject.transform.eulerAngles.y + Random.Range(80, 220),
                this.gameObject.transform.eulerAngles.z
            );
        }
        else if (collision.gameObject.tag == "Right")
        {
            this.gameObject.transform.eulerAngles = new Vector3(
                this.gameObject.transform.eulerAngles.x,
                this.gameObject.transform.eulerAngles.y + Random.Range(80, 220),
                this.gameObject.transform.eulerAngles.z
            );
        }
    }
}
