using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour {


    Vector2 spawnPosition;
    public GameObject projectile;

    // Use this for initialization
    void Start () {
        spawnPosition = GetComponentInParent<Transform>().position;
    }
	

    public void Shoot()
    {
        GameObject clone = Instantiate(projectile, transform.position, transform.rotation);
        clone.transform.position = spawnPosition;
    }



}
