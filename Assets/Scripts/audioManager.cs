using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioSource Hub_bio;
    public AudioSource Hub_coal;
    public AudioSource Hub_compleet;
    public AudioSource Hub_wind;
    public AudioSource Hub_nuclear;
    public AudioSource Hub_solar;
    public AudioSource clickPlay;

   


    public void playBio()
    {
        Hub_bio.Play();
    }

    public void playCoal()
    {
        Hub_coal.Play();
    }

    public void playCompleet()
    {
        Hub_compleet.Play();
    }

    public void playWind()
    {
        Hub_wind.Play();
    }
    public void playSolar()
    {
        Hub_solar.Play();
    }

    public void playNuclear()
    {
        Hub_nuclear.Play();
    }

    public void playClick()
    {
        clickPlay.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Energybots_Wind") != null)
        {
            playWind();
            Debug.Log("i'm here");
            //it exists
        } 

        if (GameObject.Find("Energybots_Solar") != null)
        {
            playSolar();
            Debug.Log("i'm here");
            //it exists
        }
<<<<<<< Updated upstream

=======
 
>>>>>>> Stashed changes

        if (GameObject.Find("Energybots_Nuclear") != null)
        {
            playNuclear();
            Debug.Log("i'm here");
            //it exists
        }
<<<<<<< Updated upstream

=======
    
>>>>>>> Stashed changes

        if (GameObject.Find("Energybots_Coal") != null)
        {
            playCoal();
            Debug.Log("i'm here");
            //it exists
        }
<<<<<<< Updated upstream

=======
    
>>>>>>> Stashed changes

        if (GameObject.Find("Energybots_Bio") != null)
        {
            playBio();
            Debug.Log("i'm here");
            //it exists
        }
<<<<<<< Updated upstream

=======
      
>>>>>>> Stashed changes

       /* if (GameObject.Find("Energybots_Wind", "Energybots_Bio", "Energybots_Coal", "Energybots_Nuclear", "Energybots_Solar") != null)
        {
            playCompleet();
            Debug.Log("we're here");
            //it exists
        }
        else
        {
            Debug.Log("not here");
        }*/
    }


}
