using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class Gamemanager : MonoBehaviour
{
    bool gameEnded = false;
    bool EndGame = false;
    public static List<float> Score = new List<float>();
    public float time;
    Text Timertext;
    Text Scoretext;

    [EventRef] public string music;
    FMOD.Studio.EventInstance Music;
   
    public GameObject replaycanvas;

    public GameObject[] hearts;
    public int life;

    bool immune;
    public static Gamemanager Instance
    {
        get;
        private set;
    }

    void Start()
    {
        immune = false;
        Music = FMODUnity.RuntimeManager.CreateInstance(music);
        Music.start();
        InitLevel(time);
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
    public void TakeDamage()
    {
        if (immune)
        {
            return;
        }
        immune = true;

        life--;
        if (life < 1 && life > 0)
        {
            Destroy(hearts[0].gameObject);
            //hearts[2].gameObject.GetComponent<Image>().enabled = false;
            gameEnded = true;
            Endgame();
            //Destroy(hearts[0].gameObject);
        }
        else if (life < 2 && life >= 1)
        {
            Destroy(hearts[1].gameObject);
            // hearts[1].gameObject.GetComponent<Image>().enabled = false;
            //Destroy(hearts[1].gameObject);
        }
        else if (life < 3 && life >= 2)
        {
            Destroy(hearts[2].gameObject);
            // hearts[0].gameObject.GetComponent<Image>().enabled = false;
            //Destroy(hearts[2].gameObject);
        }

        StartCoroutine(TakeDamageC());
    }

    IEnumerator TakeDamageC()
    {
        yield return new WaitForSeconds(0.2f);
        immune = false;
    }
    void InitLevel(float levelTime)
    {
        time = levelTime;
        //spawn canvas with time
        #region
        GameObject myGO;
        GameObject myText;
        GameObject myScore;
        Canvas myCanvas;
        Text text;
        Text ScoreT;
        RectTransform rectTransform;

        // Canvas
        myGO = new GameObject();
        myGO.name = "GameCanvas";
        myGO.AddComponent<Canvas>();

        myCanvas = myGO.GetComponent<Canvas>();
        myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        myGO.AddComponent<CanvasScaler>();
        myGO.AddComponent<GraphicRaycaster>();

        // Text
        myText = new GameObject();
        
        myText.transform.parent = myGO.transform;
        myText.name = "wibble";
        

        text = myText.AddComponent<Text>();
        text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        text.text = time.ToString();
        text.fontSize = 100;
        
        // Text position
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-200, 900, 0);
        rectTransform.sizeDelta = new Vector2(600, 200);

        myScore = new GameObject();

        myScore.transform.parent = myGO.transform;
        myScore.name = "wubs";
        ScoreT = myScore.AddComponent<Text>();
        ScoreT.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        ScoreT.text = time.ToString();
        ScoreT.fontSize = 70;

        // Text position
        rectTransform = ScoreT.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-250, 700, 0);
        rectTransform.sizeDelta = new Vector2(400, 200);

        Timertext = text;
        Scoretext = ScoreT;
        #endregion
    }


    string calculatescore(List<float> list)
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
            pointsystem.WriteToJson(Score);
            EndGame = true;
        }
    }

    //if playagain>>  Music.setParameterByName("Coal_Game", 0f);
}
