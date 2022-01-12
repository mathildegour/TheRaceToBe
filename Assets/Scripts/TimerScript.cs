using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    float time;
    public float TimerInterval=5f;
    float tick;

    void Awake()
    {
        time = (int)Time.time;
        tick = TimerInterval;
    }

    void Update()
    {
        GetComponent<Text> ().text = "Time: " + string.Format("{0:0}:{1:00}", Mathf.Floor(time/60),time%60);
        time = (int)Time.time;

        if(time==tick)
        {
            tick = time + TimerInterval;
            //Execute le code du Timer
            ExecuteTimer();
        }
    }

    void ExecuteTimer()
    {
        //Debug.Log("Timer");
    }
}