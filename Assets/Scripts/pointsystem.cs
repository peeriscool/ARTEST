//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//[System.Serializable]
//public static class pointsystem
//{
//    public static List<List<float>> Levelscores = new List<List<float>>(); //save list of floats for each level
//    private static int leveltime; //sync level duration

//    public static int Leveltime { get { return leveltime; } set { leveltime = value; } }

//    public static void SavePoints(List<float> points)
//    {
//        Levelscores.Add(points);
//       // WriteToJson(points);
//    }
//    public static List<List<float>> GetAllscore()
//    {
//        return Levelscores;
//    }
//    public static List<float> Getlevelscore(int sceneindex)
//    {
//        return Levelscores[sceneindex];
//    }

//    public static void WriteToJson(List<float> score)
//    {
//        container leveldata = new container();
//        leveldata.data = new List<float>();
//        foreach (float i in score)
//        {
//           // Debug.Log(i);
//            leveldata.data.Add(i);    
//        }
//        string jsonfile = JsonUtility.ToJson(leveldata);
//        Debug.Log(leveldata);
//        Debug.Log(Application.persistentDataPath);
//        System.IO.File.WriteAllText(Application.persistentDataPath + "/Leveldata.json", jsonfile);
        
//    }
//    public static List<float> getjson()
//    {
//        container a = JsonUtility.FromJson<container>(System.IO.File.ReadAllText(Application.persistentDataPath + "/Leveldata.json"));
//        List<float> score = new List<float>();
//        //foreach (float i in a.data) { score += i; }
//        for (int i = 0; i < a.data.Count; i++)
//        {
//       //     Debug.Log(a.data[i]);
//            score.Add(a.data[i]);
//        }

//        //Debug.Log(calculatescore(score));
//        return score;
//        // displayscore.text = "Energypoints: " + score.ToString();
//    }
//    public static string calculatescore(List<float> list)
//    {
//        float score = 0;
//        foreach (float i in list)
//        {
//            score += i;
//        }
//        return score.ToString();
//    }
//    public static string calculatescore()
//    {
//        float score = 0;
//        foreach (float i in Levelscores[0])
//        {
//            score += i;
//        }
//        return score.ToString();
//    }
//}
//[SerializeField]
//public class container
//    {
//    public List<float> data;
//    }

