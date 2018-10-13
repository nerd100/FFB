using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeEnemy : MonoBehaviour {

    /*
     * [0] prefab autoscooter
     * [1] prefab ballon
     * [2] prefab clown
     * 
    */
    public GameObject[] enemyPool;

    /*
     * index 0 - EMPTY SLOT
     * index 1   AUTOSCOOTER SLOT
     * index 2   BALLOON SLOT
     * index 3   CLOWN SLOT
    */
    private Vector4[] enemyPermutations = new Vector4[15] {
        new Vector4 (0, 0, 0, 0),
        new Vector4 (0, 0, 0, 1),
        new Vector4 (0, 0, 0, 2),
        new Vector4 (0, 0, 2, 0),
        new Vector4 (0, 2, 0, 0),
        new Vector4 (2, 0, 0, 0),
        new Vector4 (0, 0, 2, 2),
        new Vector4 (2, 0, 0, 2),
        new Vector4 (2, 2, 0, 0),
        new Vector4 (2, 2, 2, 0),
        new Vector4 (0, 0, 2, 1),
        new Vector4 (2, 0, 0, 1),
        new Vector4 (3, 3, 3, 3),
        new Vector4 (3, 3, 3, 3),
        new Vector4 (3, 3, 3, 3),
    };

    /* EnemyArray
     * Slot0 []
     * Slot1 []
     * Slot2 []
     * Slot3 []
     * 
     * Slot4 reserved for clown
    */

    private GameObject slot0;
    private GameObject slot1;
    private GameObject slot2;
    private GameObject slot3;
    private GameObject slot4;


    // Use this for initialization
    void Start () {
        GameObject[] slots = new GameObject[4];
        slot0 = this.transform.GetChild(0).gameObject;
        slot1 = this.transform.GetChild(1).gameObject;
        slot2 = this.transform.GetChild(2).gameObject;
        slot3 = this.transform.GetChild(3).gameObject;
        slot4 = this.transform.GetChild(4).gameObject;
        slots[0] = slot0;
        slots[1] = slot1;
        slots[2] = slot2;
        slots[3] = slot3;

        int randomEnemyPermutation = Random.Range(0, enemyPermutations.Length - 1);
        Vector4 selectedConstellation = enemyPermutations[randomEnemyPermutation];
        if (selectedConstellation[0] == 3)
        {
            //Create Clown
            GameObject go = Instantiate(enemyPool[2], slot4.transform.position, slot4.transform.rotation);
            go.transform.parent = slot4.transform;
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (selectedConstellation[i] == 1)
                {
                    //Create Autoscooter
                    GameObject go = Instantiate(enemyPool[0], slots[i].transform.position, slots[i].transform.rotation);
                    go.transform.parent = slots[i].transform;
                }
                if (selectedConstellation[i] == 2)
                {
                    //Create Ballon
                    GameObject go = Instantiate(enemyPool[1], slots[i].transform.position, slots[i].transform.rotation);
                    go.transform.parent = slots[i].transform;
                }
            }
        }

	}

	// Update is called once per frame
	void Update () {
		
	}
}
