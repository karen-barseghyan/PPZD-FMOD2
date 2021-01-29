using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using FMOD;
using FMODUnity;

public class DayNightController : MonoBehaviour {
    public static event Action<TimeOfDay> TimeOfDayChangedEvent = delegate { };

    TimeOfDay timeOfDay;

    public TimeOfDay TimeOfDay {
        get => timeOfDay;
        set {
            if (timeOfDay != value) {
                TimeOfDayChangedEvent(value);
                timeOfDay = value;
            }
        }
    }

    public void GotoNextStage() {


  

        TimeOfDay = (TimeOfDay) (((int) timeOfDay + 1) % 3);
        UnityEngine.Debug.Log("Time of day is: " + timeOfDay);
        
    //if(UnityEngine.Debug.Log(timeOfDay) == "Day"){
     // Night.release();
     // Day.start();
     // UnityEngine.Debug.Log("Time of day is: " + timeOfDay);
    }
/*
    if(timeOfDay=="Sunset"){
      Day.release();
      Dusk.start();
    }

      if(timeOfDay=="Night"){
      Dusk.release();
      Night.start();
    }
*/
    
}