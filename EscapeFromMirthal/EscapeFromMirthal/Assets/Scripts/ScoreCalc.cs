using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreCalc : MonoBehaviour
{

    public Text scoreText;
    public float score;

    public float time;
    public float powerups;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("InfoObject") == null) {
            print("its gone man");
        }
        else {
            print("YEAH");
        }
        time = GameObject.Find("InfoObject").GetComponent<Info>().timeval;
        powerups = GameObject.Find("InfoObject").GetComponent<Info>().pickupsval;
        score = time - (5.0F * powerups);
        print(score);
        scoreText.text = score.ToString();
    }
}
