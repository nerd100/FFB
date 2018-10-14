using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {


    private float scrollSpeed;
    public Renderer rend;
    void Start()
    {
        scrollSpeed = GameObject.FindObjectOfType<Parallax>().layer1Speed;
        rend = GetComponent<Renderer>();
    }
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        //rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
