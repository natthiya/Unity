using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;
    public float speed2;

    void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;

        if (Gamecontroller.score >= 50)
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * speed2;
        }
    }		
}
