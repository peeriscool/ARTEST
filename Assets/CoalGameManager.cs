using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoalGameManager : MonoBehaviour
{
    public GameObject[] hearts;
    public int life;

    bool immune;

    public static CoalGameManager Instance
    {
        get;
        private set;
    }
    void Start()
    {
        immune = false;
    }
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void TakeDamage()
    {
        if (immune)
        {
            return;
        }
        immune = true;

        life = life - 1;

        if (life < 1)
        {
            hearts[2].gameObject.GetComponent<Image>().enabled = false;
            //Destroy(hearts[0].gameObject);
        }
        else if (life < 2)
        {
            hearts[1].gameObject.GetComponent<Image>().enabled = false;
            //Destroy(hearts[1].gameObject);
        }
        else if (life < 3)
        {
            hearts[0].gameObject.GetComponent<Image>().enabled = false;
            //Destroy(hearts[2].gameObject);
        }

        StartCoroutine(TakeDamageC());
    }

    IEnumerator TakeDamageC()
    {
        yield return new WaitForSeconds(0.2f);
        immune = false;
    }
}
