using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Info : MonoBehaviour
{

    public float score;
    public float timeval;
    public float pickupsval;

    public Scene level;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(GameObject.Find("InfoObject"));
        score = 0;
        timeval = 0;
        pickupsval = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float count = 0;
        level = SceneManager.GetActiveScene();

        if (GameObject.Find("Player") != null)
        {
            count = GameObject.Find("Player").GetComponent<PlayerControl>().pickups;
            pickupsval = count;
        }

        if (GameObject.Find("TimeText") != null)
        {
            count = GameObject.Find("TimeText").GetComponent<Timer>().time;
            timeval = count;
        }

    }
}
