using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyContainer;
    public float spawnTimer = 2.5f;
    private bool enemyContainerSpawned = false;


	// Use this for initialization
	void Start () {
        

	}
	
	// Update is called once per frame
	void Update () {

 
        if (!enemyContainerSpawned)
        {
            enemyContainerSpawned = true;
            StartCoroutine(SpawnEnemy());
        }

    }
    IEnumerator SpawnEnemy()
    {
        GameObject go = Instantiate(enemyContainer, this.transform.position, this.transform.rotation);
        go.transform.parent = GameObject.FindGameObjectWithTag("HoldAllEnemies").transform;
        yield return new WaitForSeconds(spawnTimer);
        enemyContainerSpawned = false;
       
    }


   

}
