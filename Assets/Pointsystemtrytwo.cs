using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public static class Pointsystemtrytwo
{ 
    public static List<float> Levelscores = new List<float>(); //save list of floats for each level
    private static int leveltime; //sync level duration

    public static int Leveltime { get { return leveltime; } set { leveltime = value; } }

    public static void SavePoints(float point)
    {
        Debug.Log("fresh points ma dude" + Pointsystemtrytwo.calculatescore(Pointsystemtrytwo.Levelscores));
        Levelscores.Add(point);

        // WriteToJson(points);
    }
    public static List<float> GetAllscore()
    {
        return Levelscores;
    }
    //public static List<float> Getlevelscore(int sceneindex)
    //{
    //    return Levelscores[sceneindex];
    //}

    public static void WriteToJson(List<float> score, string pathname)
    {
        container leveldata = new container();
        leveldata.data = new List<float>();
        foreach (float i in score)
        {
            // Debug.Log(i);
            leveldata.data.Add(i);
        }
        string jsonfile = JsonUtility.ToJson(leveldata);
        Debug.Log(leveldata);
        Debug.Log(Application.persistentDataPath);
        System.IO.File.WriteAllText(Application.persistentDataPath + pathname, jsonfile);
    }
    public static void WriteToJson(string pathname)
    {
        container leveldata = new container();
        leveldata.data = new List<float>();
        foreach (float i in Levelscores)
        {
            // Debug.Log(i);
            leveldata.data.Add(i);
        }
        string jsonfile = JsonUtility.ToJson(leveldata);
        Debug.Log(leveldata);
        Debug.Log(Application.persistentDataPath);
        System.IO.File.WriteAllText(Application.persistentDataPath + pathname, jsonfile);
    }
    public static List<float> getjson(string pathname)
    {

        if (File.Exists(Application.persistentDataPath + pathname))
        {
            container a = JsonUtility.FromJson<container>(System.IO.File.ReadAllText(Application.persistentDataPath + pathname));

            List<float> score = new List<float>();
            //foreach (float i in a.data) { score += i; }
            for (int i = 0; i < a.data.Count; i++)
            {
                //     Debug.Log(a.data[i]);
                score.Add(a.data[i]);
            }
            return score;
        }
        else
        {
            WriteToJson(pathname);
            return new List<float>();
        }
        //Debug.Log(calculatescore(score));
      
        // displayscore.text = "Energypoints: " + score.ToString();
    }
    public static string calculatescore(List<float> list)
    {
        float score = 0;
        foreach (float i in list)
        {
            score += i;
        }
        return score.ToString();
    }
    public static string calculatescore()
    {
        float score = 0;
        foreach (float i in Levelscores)
        {
            score += i;
        }
        return score.ToString();
    }
    [SerializeField]
    public class container
    {
        public List<float> data;
    }

}


