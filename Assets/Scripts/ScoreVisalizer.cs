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
   // public List<float> points;
    public string jsonpath;
    bool once = true;
    // event Movement.RobotDied robot;
    void Start()
    {
        init();
        activepoints();
    }
    public void activepoints()
    {
        score.text = Pointsystemtrytwo.calculatescore(Pointsystemtrytwo.Levelscores);
    }
    private void FixedUpdate()
    {
        activepoints();
    }
    private void init()
    {
        score = GetComponent<Text>();
        sceneindex = SceneManager.GetActiveScene().buildIndex;
        //scoreToText(sceneindex);
        List<float> Points = Pointsystemtrytwo.getjson(jsonpath);
        Debug.Log(Pointsystemtrytwo.calculatescore(Points));
       // score.text = manager.calculatescore(Points);

    }
    public void scoreToText(int i)
    {
        List<float> Points = Pointsystemtrytwo.getjson(jsonpath);
        // List<float> Points  = pointsystem.Getlevelscore(i);
        score.text = Pointsystemtrytwo.calculatescore(Points);
       
    }
   
}
