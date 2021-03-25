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
        string jsonfile = JsonUtility.ToJson(leveldata);
        Debug.Log(leveldata);
        Debug.Log(Application.persistentDataPath);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/Leveldata.json", jsonfile);
        
    }
    public static float ReadToJson()
    {
        Debug.Log(Application.persistentDataPath + "/Leveldata.json");
        container a = JsonUtility.FromJson<container>(System.IO.File.ReadAllText(Application.persistentDataPath + "/Leveldata.json"));
        float score = 0;
        //foreach (float i in a.data)
        //{
           
        //}
        for (int i = 0; i < a.data.Count; i++)
        {
            score += a.data[(int)i];
        }
        Debug.Log(score);
        return score;
        //displayscore.text = "Energypoints: " + score.ToString();
    }
}
[SerializeField]
public class container
    {
    public List<float> data;
    }




//ObjectMapper mapper = new ObjectMapper();
//String json = "[{\"name\":\"mkyong\", \"age\":37}, {\"name\":\"fong\", \"age\":38}]";

//try
//{

//    // 1. convert JSON array to Array objects
//    Person[] pp1 = mapper.readValue(json, Person[].class);

//System.out.println("JSON array to Array objects...");
//for (Person person : pp1)
//{
//    System.out.println(person);
//}

//// 2. convert JSON array to List of objects
//List<Person> ppl2 = Arrays.asList(mapper.readValue(json, Person[].class));

//System.out.println("\nJSON array to List of objects");
//ppl2.stream().forEach(x->System.out.println(x));

//// 3. alternative
//List<Person> pp3 = mapper.readValue(json, new TypeReference<List<Person>>() { });

//System.out.println("\nAlternative...");
//pp3.stream().forEach(x->System.out.println(x));

//        } catch (IOException e)
//{
//    e.printStackTrace();
//}
