using Platformer.Gameplay;
using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeMechanic : MonoBehaviour
{

    public Text textTimer;
    public float seconds = 120;

    // Update is called once per frame
    void Update()
    {
        if (seconds > 0)
        {
            seconds -= Time.deltaTime;
            
        }
        else
        {
            seconds = 0;
        }
        DisplayTime(seconds);
    }



    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        textTimer.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

}