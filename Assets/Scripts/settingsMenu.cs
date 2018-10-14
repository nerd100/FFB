using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class settingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public Slider MusicSlider;

    void Start()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("volume", 0.0f);//wird erst aufgerufen wenn das Optionsmenu geöffnet wird und dann nur einmal
    }

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
        //PlayerPrefs.Save ();
    }
}
