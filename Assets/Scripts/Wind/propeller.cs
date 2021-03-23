using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class propeller : MonoBehaviour
{

    public float duration;
    public float targetVolume;
    string windvol;
    
   public AudioMixer audioMixer;

    public int SceneIndex;
   // private object fadeoutSnapshot;
    private AudioMixerSnapshot startingSnapshot;
    private AudioMixerSnapshot fadeoutSnapshot;

    // Start is called before the first frame update
    private enum AudioGroups
    {
        wind,
        coal,
        hub
    };

    private void Start()
    {
        fadeoutSnapshot = audioMixer.FindSnapshot("FadeOut");
        startingSnapshot = audioMixer.FindSnapshot("Starting");
    }
    // Update is called once per frame
    void Update()
    {
        float db = MicInput.MicLoudnessinDecibels; 
        if (db < 1 && db > -10f)
        {
            transform.Rotate(0, 0, 45 * Time.deltaTime * -2, Space.Self);
        }
   
    }
    public void SnapshotStarting()
    {
        startingSnapshot.TransitionTo(.5f);
    }
    public void SnapshotFadeOut()
    {
        fadeoutSnapshot.TransitionTo(.5f);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bird")
        {
            SnapshotFadeOut();
            Debug.Log("HIT");
            Gamemanager.Instance.TakeDamage();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
