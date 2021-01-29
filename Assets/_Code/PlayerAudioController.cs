using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class PlayerAudioController : PlayerSubsystem {
    [FMODUnity.EventRef]
    public string jumpSound;
    [FMODUnity.EventRef]
    public string footstepSound;
   //bool playerIsMoving;
    [FMODUnity.EventRef]
    public string deathSound;
    [FMODUnity.EventRef]
    public string attackSound;
    [FMODUnity.EventRef]
    public string landSound;
    

    public override void HandleEvent(PlayerEventType eventType) {
        switch (eventType) {
            case PlayerEventType.Jump:
              //  Debug.Log ("Jump");
             //   FMODUnity.RuntimeManager.PlayOneShot(jumpSound);              
                break;
            case PlayerEventType.Landing:
              //  Debug.Log ("Land");
             //   FMODUnity.RuntimeManager.PlayOneShot(landSound);    
                break;
            case PlayerEventType.Death:
              //  Debug.Log ("Death");
              //  FMODUnity.RuntimeManager.PlayOneShot(deathSound); 
                break;
            case PlayerEventType.Attack:
              //  Debug.Log ("Attack");
              //  FMODUnity.RuntimeManager.PlayOneShot(attackSound); 
                break;
            case PlayerEventType.Footstep:
              //  Debug.Log ("Footstep");
             //   FMODUnity.RuntimeManager.PlayOneShot(footstepSound); 
                break;
        }
    }


    }

