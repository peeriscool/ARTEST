using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class propeller : MonoBehaviour
{
    public int SceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        
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
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bird")
        {
            SceneManager.LoadScene(SceneIndex,LoadSceneMode.Single);
        }
    }
}
