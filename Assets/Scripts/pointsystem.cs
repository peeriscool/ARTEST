using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public static class pointsystem
{
    private static List<List<float>> Levelscores; //save list of floats for each level
    private static int leveltime; //sync level duration

    public static int Leveltime { get { return leveltime; } set { leveltime = value; } }

    public static void SavePoints(List<float> points)
    {
        Levelscores.Add(points);
    }
    public static List<List<float>> GetAllscore()
    {
        return Levelscores;
    }
    public static List<float> Getlevelscore(int sceneindex)
    {
        return Levelscores[sceneindex];
    }

    public static void WriteToJson(List<float> score)
    {
        container leveldata = new container();
        leveldata.data = new List<float>();
        foreach (float i in score)
        {
            Debug.Log(i);
            leveldata.data.Add(i);    
        }
        string jsonfile = JsonUtility.ToJson(leveldata, true);
        Debug.Log(leveldata);
        Debug.Log(Application.persistentDataPath);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/Leveldata.json", jsonfile);
        
    }
}
[SerializeField]
public class container
    {
    public List<float> data;
    }
