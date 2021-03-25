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
    bool once = true;
   // event Movement.RobotDied robot;
    
    void Start()
    {
        score = GetComponent<Text>();
        sceneindex = SceneManager.GetActiveScene().buildIndex;
    }
    //public void Eventtrigger()
    //{
    //    EventArgs e = new EventArgs();
    //    Debug.Log("Roboto collided");
    //    robot(this, e);
    //}
    private void FixedUpdate()
    {
        if(once)
        {
            scoreToText(sceneindex);
            once = false;
        }
       
    }
    public void scoreToText(int i)
    {
        List<float> Points = pointsystem.getjson();
      // List<float> Points  = pointsystem.Getlevelscore(i);
        score.text = manager.calculatescore(Points);
    }
}
