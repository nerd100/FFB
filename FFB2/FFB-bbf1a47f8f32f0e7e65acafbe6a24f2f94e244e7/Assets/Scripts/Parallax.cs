using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {


    public GameObject layer1;
    public GameObject layer2;
    public GameObject layer3;

    private float layer1Speed;
    private float layer2Speed;
    private float layer3Speed;


    // Use this for initialization
    void Start () {
        layer1Speed = 1.0f;
        layer2Speed = 0.3f;
        layer3Speed = 0.1f;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.gameIsRunning)
        {
            print(Time.deltaTime);
            layer1.transform.position = new Vector3(layer1.transform.position.x - layer1Speed * Time.deltaTime, layer1.transform.position.y, layer1.transform.position.z);
            layer2.transform.position = new Vector3(layer2.transform.position.x - layer2Speed * Time.deltaTime, layer2.transform.position.y, layer2.transform.position.z);
            layer3.transform.position = new Vector3(layer3.transform.position.x - layer3Speed * Time.deltaTime, layer3.transform.position.y, layer3.transform.position.z);
        }
    }
}
