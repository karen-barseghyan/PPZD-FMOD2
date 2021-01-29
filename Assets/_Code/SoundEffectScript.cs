using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using FMOD;
using FMODUnity;

public class SoundEffectScript: MonoBehaviour {
  [SerializeField] BoxCollider2D bc;
  [SerializeField] Rigidbody2D rb;
  /* [SerializeField] AudioSource BackgroundAudio;
   [SerializeField] Slider MainVolumeSlider;
   [SerializeField] Slider MusicVolumeSlider;
   [SerializeField] Slider EffectsVolumeSlider;
   [SerializeField] AudioMixerSnapshot OutsideForestDay;
   [SerializeField] AudioMixerSnapshot OutsideForestDusk;
   [SerializeField] AudioMixerSnapshot OutsideForestNight;
   [SerializeField] AudioMixerSnapshot InsideForestDay;
   [SerializeField] AudioMixerSnapshot InsideForestDusk;
   [SerializeField] AudioMixerSnapshot InsideForestNight;
   public AudioMixer BackgroundAudioMixer;
   */

  [SerializeField] FMODUnity.StudioEventEmitter Day;
  [SerializeField] FMODUnity.StudioEventEmitter Dusk;
  [SerializeField] FMODUnity.StudioEventEmitter Night;
  [SerializeField] FMODUnity.StudioEventEmitter Inside;
  [SerializeField] FMODUnity.StudioEventEmitter Outside;
  

  [SerializeField] GameObject PlayerPosition;

  string currentTime = "Day";
  string playerStatus = "";

  int activated = 0;

  bool DayInsideActive = false;
  bool DayOutsideActive = false;
  bool DuskInsideActive = false;
  bool DuskOutsideActive = false;
  bool NightInsideActive = false;
  bool NightOutsideActive = false;

bool inside = true;
bool outside = false;
  /*
  FMOD.Studio.EventInstance Night;
  FMOD.Studio.EventInstance Dusk;
  FMOD.Studio.EventInstance Day;
  FMOD.Studio.EventInstance Inside;
  FMOD.Studio.EventInstance Outside;
  */


  public void Start() {
    /*  MainVolumeSlider.onValueChanged.AddListener(delegate {
        ValueChangeCheck();
      });
      MusicVolumeSlider.onValueChanged.AddListener(delegate {
        ValueChangeCheck();
      });
      EffectsVolumeSlider.onValueChanged.AddListener(delegate {
        ValueChangeCheck();
      });
      changeSnapshot();
      */
    // FMOD.Studio.EventInstance Day = RuntimeManager.CreateInstance("snapshot:/Day");
    //  Day.start();

  }

  void Awake() {
    DayNightController.TimeOfDayChangedEvent += OnTimeOfDayChanged;
    checkPosition();
 Day.Play();
  }

  void OnDestroy() {
    DayNightController.TimeOfDayChangedEvent -= OnTimeOfDayChanged;
  }

  /*  void setMainVolume(float value01) {
      if (value01 > 0) {
        BackgroundAudioMixer.SetFloat("MainVolume", 20 * Mathf.Log10(value01));
      }
      else {
        BackgroundAudioMixer.SetFloat("MainVolume", -80);
      }
    }

    void setMusicVolume(float value02) {
      if (value02 > 0) {
        BackgroundAudioMixer.SetFloat("MusicVolume", 20 * Mathf.Log10(value02));
      }
      else {
        BackgroundAudioMixer.SetFloat("MusicVolume", -80);
      }
    }

    void setEffectsVolume(float value03) {
      if (value03 > 0) {
        BackgroundAudioMixer.SetFloat("EffectsVolume", 20 * Mathf.Log10(value03));
      }
      else {
        BackgroundAudioMixer.SetFloat("EffectsVolume", -80);
      }
    }

    public void ValueChangeCheck() {
      setMainVolume(MainVolumeSlider.value);
      setMusicVolume(MusicVolumeSlider.value);
      setEffectsVolume(EffectsVolumeSlider.value);
    }
  */
  void OnTriggerStay2D(Collider2D other) {
    playerStatus = "Inside";
    if (activated == 0) {
      //InsideForestDay.TransitionTo(0.3f);
    }
  }

  void OnTriggerExit2D(Collider2D other) {
    if (activated == 0) {
      // OutsideForestDay.TransitionTo(0.3f);
    }
    playerStatus = "Outside";
  }

  void OnTimeOfDayChanged(TimeOfDay timeOfDay) {

    /*
     Night = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Night");
     Dusk = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Sunset");
     Day = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Day");
    Inside = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Inside");
    Outside = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Outside");
    */
    switch (timeOfDay) {
    case TimeOfDay.Day:
      // FMODUnity.RuntimeManager.Play(turnDay);
      Night.Stop();
      Day.Play();

      // Day.start();
      // Day.setParameterByName("ID", 50f);
      currentTime = "Day";

      break;
    case TimeOfDay.Sunset:
      Day.Stop();
      Dusk.Play();
      // activated = 1;
      //  FMODUnity.RuntimeManager.PlayOneShot(turnSunset);
      currentTime = "Dusk";
      //   Dusk.start();
      //  Dusk.setParameterByName("IS", 50f);

      break;
    case TimeOfDay.Night:
      currentTime = "Night";
       Dusk.Stop();
      Night.Play();

      // FMODUnity.RuntimeManager.PlayOneShot(turnNight);  
      // Night.start();
      // Night.setParameterByName("IN", 50f);

      break;
    }
  }

  void checkPosition() {


        if (PlayerPosition.transform.position.x < 2)
      {
       // UnityEngine.Debug.Log("insideForest");
        Outside.Stop();
        Inside.Play();
      }

        if (PlayerPosition.transform.position.x > 2)
      {
       // UnityEngine.Debug.Log("outsideForest");
        Inside.Stop();
        Outside.Play();
      }

  }

  void Update() {
    checkPosition();
  }

}