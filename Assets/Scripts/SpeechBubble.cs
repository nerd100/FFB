using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeechBubble : MonoBehaviour {

    string sentence;
    List<char> charList = new List<char>();
    public TextMeshProUGUI textMeshSentence;
    private bool nextLetter = true;
    private bool speechBubbleActive = false;
    int counter = 0;

	// Use this for initialization
	void Start () {
        sentence = "I hate funfairs \n !!!";
        for(int i = 0; i < sentence.Length; i++)
        {
            charList.Add(sentence[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (speechBubbleActive)
        {
            if (nextLetter && (counter < sentence.Length))
            {

                textMeshSentence.text += charList[counter++];
                nextLetter = false;
                StartCoroutine(waitForTheNextLetter());

            }

            if (counter >= sentence.Length)
            {
                StartCoroutine(waitToCloseTheSpeechBubble());
            }
        }
        else
        {
            StartCoroutine(waitForTheSpeechBubble());
        }


	}
    IEnumerator waitForTheNextLetter()
    {
        yield return new WaitForSeconds(0.05f);
        nextLetter = true;
    }
    IEnumerator waitToCloseTheSpeechBubble()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
    IEnumerator waitForTheSpeechBubble()
    {
        yield return new WaitForSeconds(1f);
        speechBubbleActive = true;
    }
}
