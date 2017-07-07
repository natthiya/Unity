using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroud : MonoBehaviour {
    public float speed;
    float bg;
    float bg1;
    
    void Start () {
        bg = transform.position.x;
        bg1 = GameObject.Find ("Background1").transform.position.x;
	}
	
	void Update () {
        transform.position = new Vector2 (transform.position.x + speed, transform.position.y);
        if (transform.position.x < (bg1 * -1f))
        {
            transform.position = new Vector2(bg1, transform.position.y);
        }		
	}
}
