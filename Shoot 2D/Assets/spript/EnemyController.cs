using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float speed2;
    GameObject player;
    public GameObject enemybullet;
    public float timeStartShoot;
    public float timeLoopShoot;
    public int scorevalue;

    public virtual void Start()
    {
        InvokeRepeating("OnShooting", timeStartShoot, timeLoopShoot);  //ยานปิดตัวมายิงเลย ผ่านไป 1วิยิง1นัด    
    }

    void OnShooting()
    {
        Instantiate(enemybullet, transform.position, Quaternion.identity);

    }

    public virtual void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        if (Gamecontroller.score >= 50)
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * speed2;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(gameObject); //ลบตัวเอง
            Gamecontroller.Addscore(scorevalue);   
        }
    }
}