using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class Gamemanager : MonoBehaviour
{
    bool gameEnded = false;
    bool EndGame = false;
    bool startgame = false;
    public static List<float> Score = new List<float>();
    Text Scoretext;

    [EventRef] public string music;
    FMOD.Studio.EventInstance Music;
   
    public GameObject replaycanvas;

    public GameObject[] hearts;
    public int life;
    public Image HP;

    bool immune;
    public static Gamemanager Instance
    {
        get;
        private set;
    }

    void Start()
    {
        Debug.Log(Pointsystemtrytwo.calculatescore(Pointsystemtrytwo.Levelscores));
        immune = false;
        StartCoroutine(WaitAndPrint(5));
        Music = FMODUnity.RuntimeManager.CreateInstance(music);
        Music.start();
    }

    void Awake()
    {
        Instance = this;
    }

    /* void FixedUpdate()
     {
         if (!gameEnded) { time -= 0.03f; };
         Timertext.text = time.ToString();
         Scoretext.text = calculatescore(Score);
         if (time <= 0)
         {
            *//* gameEnded = true;
             Timertext.text = "Times up!";
             Endgame();*//*
         }
         if(gameEnded)
         {
           //  Score.Add(69f);
           //  Score.Add(420f);
           //  Score.Add(1.555555f);
           //  pointsystem.WriteToJson(Score);
         }
     }*/
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (!startgame)
        {
            Debug.Log(waitTime);
            yield return new WaitForSeconds(waitTime);
            Destroy(GameObject.Find("tutorialCanvas"));
            print("WaitAndPrint " + Time.time);
            startgame = true;
        }
    }
    public void TakeDamage()
    {
        if (immune)
        {
            return;
        }
        immune = true;

        life--;
        if (life < 1)//heb 1 leven
        {
            //Destroy(hearts[0].gameObject);
            hearts[2].gameObject.GetComponent<Image>().sprite = HP.sprite;
             List <float> buffer = Pointsystemtrytwo.GetAllscore();
            Pointsystemtrytwo.WriteToJson(buffer);
            gameEnded = true;
           foreach(GameObject boi in GameObject.FindGameObjectsWithTag("Robot"))
            {
                Destroy(boi);
            }
            Pointsystemtrytwo.WriteToJson();
            Endgame();
        }
        else if (life < 2 )
        {
            // Destroy(hearts[1].gameObject);
            hearts[1].gameObject.GetComponent<Image>().sprite = HP.sprite;
        }
        else if (life < 3 )
        {
           //Destroy(hearts[2].gameObject);
            //hearts[0].gameObject.GetComponent<Image>().enabled = false;
            hearts[0].gameObject.GetComponent<Image>().sprite = HP.sprite;
        }

        StartCoroutine(TakeDamageC());
    }

    IEnumerator TakeDamageC()
    {
        yield return new WaitForSeconds(0.2f);
        immune = false;
    }


    public string calculatescore(List<float> list)
    {
        float score = 0;
        foreach(float i in list)
        {
            score += i;
        }
        return score.ToString();
    }
    void Endgame()
    {
        if(!EndGame)
        {
            replaycanvas.SetActive(true);
            Music.setParameterByName("Coal_Game", 1f);
            //BUG: somehow disables the buttons on the replay canvas!!!?
            //GameObject control = GameObject.Find("Canvas");
            //foreach(Transform a in control.transform)
            //{
            //    a.gameObject.SetActive(false);
            //}
            Pointsystemtrytwo.WriteToJson(Score);
            EndGame = true;
        }
    }

    //if playagain>>  Music.setParameterByName("Coal_Game", 0f);
}
