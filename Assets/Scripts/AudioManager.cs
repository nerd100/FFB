using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour {

    public AudioMixer audioMixer;

    public AudioClip musicFile;
    public GameObject audioPrefab;
    public static bool playSong = false;
    public Slider MusicSlider;
    // Use this for initialization
    void Start()
    {
        if (playSong == false)
        { //falls der Song nicht gespielt wird, dann starte ihn
            audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume", 0.0f));
            GameObject audioGameObject = Instantiate(audioPrefab, Vector3.zero, Quaternion.identity);
            audioGameObject.GetComponentInChildren<AudioSource>().clip = musicFile;
            audioGameObject.GetComponentInChildren<AudioSource>().Play();
            playSong = true;
        }

    }
}
