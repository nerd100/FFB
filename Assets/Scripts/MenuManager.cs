using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public TextMeshProUGUI highscoreTextMesh;
    public int highscore;
    public GameObject settingsPanel;
    public float tempVolume;
    public GameObject audio;

    // Use this for initialization
    void Start () {
        audio = GameObject.FindGameObjectWithTag("audio");
        highscore = PlayerPrefs.GetInt("highscore", 0);
        if (PlayerPrefs.GetInt("roundScore", 0) > highscore)
        {
            highscore = PlayerPrefs.GetInt("roundScore");
            PlayerPrefs.SetInt("highscore", highscore);
        }
        highscoreTextMesh.text = "Highscore\n" + highscore.ToString();  //TODO userprefs

    }
	
    public void nextScene()
    {
        tempVolume = PlayerPrefs.GetFloat("volume", 0.0f);  //die Lautstärke soll nicht bei jedem Neustart zurückgesetzt werden
        PlayerPrefs.DeleteAll(); //delete Scores and Words from last round
        PlayerPrefs.SetFloat("volume", tempVolume);
        //DontDestroyOnLoad(audio); //play the song
        AudioManager.playSong = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void openSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }
    public void closeSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
