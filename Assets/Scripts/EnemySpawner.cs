using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyContainer;
    public float spawnTimer = 2.5f;
    public float enemySpeed = 2f;
    private bool enemyContainerSpawned = false;
    private int speedMultiplicator = 0;
    private float speedBonus = 0.5f;
    private int increaseSpeedThreshold = 300;
    private float changeSpeedCD=2f;
    private bool changingSpeed;

    public GameManager gm;

	// Use this for initialization
	void Start () {
        gm = GameObject.FindObjectOfType<GameManager>();

	}
	
	// Update is called once per frame
	void Update () {
        
        if (!enemyContainerSpawned)
        {
            enemyContainerSpawned = true;
            StartCoroutine(SpawnEnemy());
        }

        if (!changingSpeed) {
            changeSpeedOnScore();
        }
    }
    IEnumerator SpawnEnemy()
    {
        GameObject go = Instantiate(enemyContainer, this.transform.position, this.transform.rotation);
        go.transform.parent = GameObject.FindGameObjectWithTag("HoldAllEnemies").transform;
        yield return new WaitForSeconds(spawnTimer);
        enemyContainerSpawned = false;
       
    }
    
    void changeSpeedOnScore()
    {
       
        if ((gm.globalScore % increaseSpeedThreshold) == 0)
        {
            changingSpeed = true;
            StartCoroutine(ChangeSpeedCo());
        }
            
    }
    IEnumerator ChangeSpeedCo()
    {
        speedMultiplicator += 1;
        enemySpeed += speedMultiplicator * speedBonus;
        Debug.Log(speedMultiplicator);
        yield return new WaitForSeconds(changeSpeedCD);
        changingSpeed = false;
    }


   

}
