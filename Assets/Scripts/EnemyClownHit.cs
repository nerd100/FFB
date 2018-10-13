using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClownHit : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "projectile")
        {
            Destroy(this);
        }
    }
    
}
