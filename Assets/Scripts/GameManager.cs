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

	// Use this for initialization
	void Start () {
        globalScore = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (!runningPointsWait)
        {
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
}
