using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text highScore;
    private float runningPointsCD=0.03f;
    private bool runningPointsWait;
    private int basicAddScore = 1;
    public int globalScore;
<<<<<<< HEAD
<<<<<<< HEAD
    public GameObject panel;
    public TextMeshProUGUI score;
    public GameObject speechBubble;
    public static bool gameIsRunning;
    private bool speechBubbleActive = false;
    private bool firstSpeech = true;
    // Use this for initialization
    void Start () {
=======
=======
>>>>>>> parent of 464643a... parallax, menu, statemachine

	// Use this for initialization
	void Start () {
>>>>>>> parent of 464643a... parallax, menu, statemachine
        globalScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
        if (speechBubbleActive) //activate SpeechBubble after a short delay
        {
            speechBubble.SetActive(true);
            speechBubbleActive = false;
            firstSpeech = false;
        }
        else if(firstSpeech){
            StartCoroutine(waitForTheSpeechBubble());
        }
            
        


        if (!runningPointsWait)
        {
=======

        if (!runningPointsWait)
        {
>>>>>>> parent of 464643a... parallax, menu, statemachine
            AddRunningPoints();
        }
	}

    void AddRunningPoints()
    {
        globalScore += basicAddScore;
        highScore.text =  globalScore.ToString();
        runningPointsWait = true;
        StartCoroutine(AddRunningPointsCo());
    }

    IEnumerator AddRunningPointsCo()
    {
        yield return new WaitForSeconds(runningPointsCD);
        runningPointsWait = false;
    }
<<<<<<< HEAD
<<<<<<< HEAD

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

    }

    IEnumerator waitForTheSpeechBubble()
    {
        yield return new WaitForSeconds(1f);
        speechBubbleActive = true;
    }

=======
>>>>>>> parent of 464643a... parallax, menu, statemachine
=======
>>>>>>> parent of 464643a... parallax, menu, statemachine
}
