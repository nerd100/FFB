using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteInvisibleParallax : MonoBehaviour {

    private Camera mainCamera;

    float layer1Speed = 1.0f;
    float layer2Speed = 0.3f;

    void Awake()
    {
        mainCamera = Camera.main;
    }


    void Update()
    {
        if (this.gameObject.name.Contains("for"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - layer1Speed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - layer2Speed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        if (gameObject.transform.position.x < -15)
           Destroy(gameObject);
        
    }
}

