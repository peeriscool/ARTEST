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
    void Start()
    {
        Music = FMODUnity.RuntimeManager.CreateInstance(music);
        Music.start();
        InitLevel(time);
    }
    void FixedUpdate()
    {
        if (!gameEnded) { time -= 0.03f; };
        Timertext.text = time.ToString();
        Scoretext.text = calculatescore(Score);
        if (time <= 0)
        {
            gameEnded = true;
            Timertext.text = "Times up!";
            Endgame();
        }
        if(gameEnded)
        {
          //  Score.Add(69f);
          //  Score.Add(420f);
          //  Score.Add(1.555555f);
          //  pointsystem.WriteToJson(Score);
        }
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
