using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public TextMeshProUGUI highscoreTextMesh;
    public int highscore;

	// Use this for initialization
	void Start () {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
