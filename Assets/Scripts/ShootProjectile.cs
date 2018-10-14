using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour {


    Vector2 spawnPosition;
    public GameObject[] projectiles;

    // Use this for initialization
    void Start () {
        spawnPosition = GetComponentInParent<Transform>().position;
    }
	

    public void Shoot()
    {
        int randomPrefab = Random.Range(0, 2);
        GameObject clone = Instantiate(projectiles[randomPrefab], transform.position, transform.rotation);
        clone.transform.position = spawnPosition;
    }



}
