using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storyboard : MonoBehaviour
{
    public List<Sprite> plaatjes;
    public Image story;
    int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && i <= plaatjes.Count ){
            story.sprite = plaatjes[i];
            i++;

        }
        if(plaatjes.Count == i)
        {
            SceneManagerScript BOB = new SceneManagerScript();
            BOB.LoadScene(2);
        }
    }
}
