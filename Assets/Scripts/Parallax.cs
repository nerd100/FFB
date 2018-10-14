using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour {


    public GameObject layer1;
    public GameObject layer2;
    public GameObject layer3;

    
    private float layer1Speed = 1f;
    private float layer2Speed =2f;
    private float layer3Speed=3f;

    public GameObject forgroundBude;
    public GameObject middlegroundBude;

    private float forgroundSpawnPointX = 11.0f;
    private float forgroundSpawnPointY = -4.0f;

    private float middlegroundSpawnPointX = 11.0f;
    private float middlegroundSpawnPointY = -1.5f;

    List<Sprite> budenSprites = new List<Sprite>();
    private Object[] budenImages;

    Sprite randomSprite;

    private bool spawnBudeGlobal = true;
    private bool spawnBudeFor = true;
    private bool spawnBudeMiddel = true;

    Vector3 startPos1;
    Vector3 startPos2;
    Vector3 startPos3;
    // Use this for initialization

    void Start () {
        budenImages = Resources.LoadAll("Buden", typeof(Sprite));
        startPos1 = layer1.transform.position;
        startPos2 = layer2.transform.position;
        startPos3 = layer3.transform.position;

        foreach (var t in budenImages)
        {
            budenSprites.Add((Sprite)t);
        }

    }

    // Update is called once per frame
    void Update () {
        if (GameManager.gameIsRunning)
        {

            //layer1.GetComponent<RectTransform>().transform.position = new Vector3(layer1.GetComponent<RectTransform>().transform.position.x + layer1Speed * Time.deltaTime, layer1.GetComponent<RectTransform>().transform.position.y, layer1.GetComponent<RectTransform>().transform.position.z);

            //layer1.transform.position = new Vector3(layer1.transform.position.x - layer1Speed * Time.deltaTime, layer1.transform.position.y, layer1.transform.position.z);
            //layer2.transform.position = new Vector3(layer2.transform.position.x - layer2Speed * Time.deltaTime, layer2.transform.position.y, layer2.transform.position.z);
            // layer3.transform.position = new Vector3(layer3.transform.position.x - layer3Speed * Time.deltaTime, layer3.transform.position.y, layer3.transform.position.z);
            // 
            float newPos1 = Mathf.Repeat(layer1Speed * Time.time, 40.96f);
           layer1.transform.position = startPos1 + Vector3.left * newPos1;

            float newPos2 = Mathf.Repeat(layer2Speed * Time.time, 40.96f);
            layer2.transform.position = startPos2 + Vector3.left * newPos2;

            float newPos3 = Mathf.Repeat(layer3Speed * Time.time, 40.96f);
            layer3.transform.position = startPos3 + Vector3.left * newPos3;

            if (spawnBudeGlobal) {
                spawnBudeGlobal = false;
                randomSprite = budenSprites[Random.Range(0, budenSprites.Count)];

                if (randomSprite.name.Contains("for") && spawnBudeFor)
                {
                    spawnBudeFor = false;
                    GameObject bude = Instantiate(forgroundBude, new Vector3(forgroundSpawnPointX, forgroundSpawnPointY, 0), transform.rotation);
                    bude.GetComponent<SpriteRenderer>().sprite = randomSprite;
                    //bude.transform.position = new Vector3(bude.transform.position.x - layer1Speed * Time.deltaTime, bude.transform.position.y - layer1Speed * Time.deltaTime, bude.transform.position.z);
                    //bude.transform.parent = layer1.transform;

                    StartCoroutine(spawnBudenTimeoutForGround());
                }
                else if(spawnBudeMiddel) 
                {
                    spawnBudeMiddel = false;
                    GameObject bude = Instantiate(middlegroundBude, new Vector3(middlegroundSpawnPointX, middlegroundSpawnPointY, 0), transform.rotation);
                    bude.GetComponent<SpriteRenderer>().sprite = randomSprite;
                    //bude.transform.position = new Vector3(bude.transform.position.x - layer2Speed * Time.deltaTime, bude.transform.position.y - layer2Speed * Time.deltaTime, bude.transform.position.z);
                    //bude.transform.parent = layer2.transform;

                    StartCoroutine(spawnBudenTimeoutMiddelGround());
                }

                StartCoroutine(spawnBudenTimeoutGlobal());
            }
        }
    }

    IEnumerator spawnBudenTimeoutGlobal()
    {
        yield return new WaitForSeconds(5);
        spawnBudeGlobal = true;
    }

    IEnumerator spawnBudenTimeoutForGround()
    {
        yield return new WaitForSeconds(5);
        spawnBudeFor = true;
    }
    IEnumerator spawnBudenTimeoutMiddelGround()
    {
        yield return new WaitForSeconds(10);
        spawnBudeMiddel = true;
    }
}
