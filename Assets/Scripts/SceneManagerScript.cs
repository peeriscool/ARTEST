using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    #region SingleTon

    public static SceneManagerScript Inctance { set; get; }

    #endregion

    
    void Start()
    {
        Inctance = this;
        //write to json file 
        //List<float> a = new List<float>();
        //a.Add(69f);
        //a.Add(420f);
        //a.Add(1.555555f);
        //pointsystem.WriteToJson(a);
    }

   public void LoadScene(int load)
    {
        SceneManager.LoadScene(load, LoadSceneMode.Single);
    }
    public void HideCanvas(Canvas hide)
    {
        hide.enabled = false;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

  
}
