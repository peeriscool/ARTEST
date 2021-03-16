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

    public void QuitGame()
    {
        Application.Quit();
    }
}
