using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {

    public float speed;
    public float duration;
    public float gravity;
    Vector3 startPosition;
    Vector3 endPosition;


    float amplitudeX = 10.0f;
    float amplitudeY = 1.5f;
    float omegaX = 1.0f;
    float omegaY = 3.0f;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
        speed = 1.5f;
        gravity = 0.0f;
             
	}
	
	// Update is called once per frame
	void Update () {
        //speed = Mathf.Pow(gameObject.transform.position.x, 2);
        //gravity -= speed;
        //gameObject.transform.position += new Vector3(speed * Time.deltaTime, gravity * Time.deltaTime * 0.1f, 0.0f);

        duration += Time.deltaTime;
        float x = amplitudeX * Mathf.Cos(omegaX * duration);
        float y = Mathf.Abs(amplitudeY * Mathf.Sin(omegaY * duration));
        gameObject.transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, y-1.5f, 0);
        if(duration > 3)
        {
            Destroy(this.gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "clown")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
