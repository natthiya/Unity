using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embullet : MonoBehaviour {

    

    void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(gameObject); //ลบตัวเอง
            Destroy(other.gameObject); //ลบของที่ชน
        }
    }
}
