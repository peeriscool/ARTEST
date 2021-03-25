using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
[RequireComponent (typeof(Text))]
public class ScoreVisalizer : MonoBehaviour
{
    public Gamemanager manager;
    Text score;
    int sceneindex;
    float points;
   // event Movement.RobotDied robot;
    
    void Start()
    {
        points = pointsystem.ReadToJson();
        score = GetComponent<Text>();
        sceneindex = SceneManager.GetActiveScene().buildIndex;
        score.text = points.ToString();
    }
    //public void Eventtrigger()
    //{
    //    EventArgs e = new EventArgs();
    //    Debug.Log("Roboto collided");
    //    robot(this, e);
    //}
    private void FixedUpdate()
    {
        scoreToText(sceneindex);
    }
    public void scoreToText(int i)
    {

       //List<float> Points  = pointsystem.Getlevelscore(i);
       // score.text = manager.calculatescore(Points);
    }
}
