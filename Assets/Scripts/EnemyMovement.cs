using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float enemySpeed = 2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float newXPosition = this.transform.position.x - Time.deltaTime * enemySpeed;
        this.transform.position = new Vector3(newXPosition, this.transform.position.y,0f);
    }
}
