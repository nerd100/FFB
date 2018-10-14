using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour {

    public Text highScore;
    private float runningPointsCD=0.03f;
    private bool runningPointsWait;
    private int basicAddScore = 1;
    public int globalScore;
    public GameObject panel;
    public TextMeshProUGUI score;
    public GameObject speechBubble;
    public static bool gameIsRunning;
    private bool speechBubbleActive = false;
    private bool firstSpeech = true;

    //Music
    public AudioClip musicFile;
    public GameObject audioPrefab;
    public static bool playSong = false;
    public AudioMixer audioMixer;

    // Use this for initialization
    void Start () {
        globalScore = 0;
        panel.SetActive(false);
        gameIsRunning = true;

        if (playSong == false)
        { //falls der Song nicht gespielt wird, dann starte ihn
            audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume", 0.0f));
            GameObject audioGameObject = Instantiate(audioPrefab, Vector3.zero, Quaternion.identity);
            audioGameObject.GetComponentInChildren<AudioSource>().clip = musicFile;
            audioGameObject.GetComponentInChildren<AudioSource>().Play();
            playSong = true;
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (speechBubbleActive) //activate SpeechBubble after a short delay
        {
            speechBubble.SetActive(true);
            speechBubbleActive = false;
            firstSpeech = false;
        }
        else if(firstSpeech){
            StartCoroutine(waitForTheSpeechBubble());
        }
            
        


        if (checkIsPlayerAlive())
        {

            if (!runningPointsWait)
            {
                AddRunningPoints();
            }
        }
        else {
            PlayerPrefs.SetInt("roundScore", globalScore);
            panel.SetActive(true);
            score.text = "Score: " + globalScore;
            gameIsRunning = false;
            print("GAMEOVER");
        }
	}

    void AddRunningPoints()
    {
        globalScore += basicAddScore;
        highScore.text =  globalScore.ToString();
        runningPointsWait = true;
        StartCoroutine(AddRunningPointsCo());
    }

    public bool checkIsPlayerAlive()
    {
        if (GameObject.FindGameObjectWithTag("player")) {
            return true;
        }
        else
        {
            return false; ;
        }
        
    }

    IEnumerator AddRunningPointsCo()
    {
        yield return new WaitForSeconds(runningPointsCD);
        runningPointsWait = false;
    }

    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        resetScene();
    }
    public void restartScene()
    {
        SceneManager.LoadScene("Game");
        resetScene();
    }

    private void resetScene()
    {
        EnemySpawner.enemySpeed = 2.0f;
        GameManager.gameIsRunning = true;
        playSong = false;
    }

    IEnumerator waitForTheSpeechBubble()
    {
        yield return new WaitForSeconds(1f);
        speechBubbleActive = true;
    }

    

}
