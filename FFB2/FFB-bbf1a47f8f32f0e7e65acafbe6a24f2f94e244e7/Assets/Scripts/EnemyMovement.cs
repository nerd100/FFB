using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private Camera mainCamera;
    private EnemySpawner enemyManager;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    // Use this for initialization
    void Start () {
        enemyManager = GameObject.FindObjectOfType<EnemySpawner>();
	}
	
	// Update is called once per frame
	void Update () {
        float newXPosition = this.transform.position.x - Time.deltaTime * EnemySpawner.enemySpeed;
        this.transform.position = new Vector3(newXPosition, this.transform.position.y,0f);

        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < 0)
            Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
