using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PalyerControler : MonoBehaviour {

    private Rigidbody2D rb; //ควบคุมการเคลื่อนที่ ตำแหน่ง
    public float speed; //ความเร็ว
    public GameObject shoot;  //แทนกระสุน
    public Transform shootpoint; //แทนตำแหน่ง
    public float fireRate; //ตังรั้งเวลายิง
    private float nextFire; //เวลาที่เราจะยิงนัดต่อไป
    public Boundary boundary;
    private Gamecontroller gamecontroller;
    public int down;
    public int score;
    private int add;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // rbรับค่าRigidbody2D
    }
    //มีความเร็วคงที่ 50ครั้งต่อวิ //update ทำงานตามความเร็วเครื่อง
    void FixedUpdate()
    {   
        //ขอบเขตที่สามารถบินได้
        rb.position = new Vector2(
           Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
           Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax)
        );

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //การเคลื่อนที่ x,y
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed; //เคลื่อนที่ตามความเร็ว
    }
    //ยิง
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shoot, shootpoint.position, shootpoint.rotation); // เพิ่มวัถตุเพิ่มลูกกระสุน
        }
        if (Life.playerlifes == 0)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Life.heart(down);
        }
        if (other.tag == "Boss")
        {
            Destroy(other.gameObject);
            Life.heart(down);
        }
        if (other.tag == "Embullet")
        {
            Destroy(other.gameObject);
            Life.heart(down);
        }
        if (other.tag == "Life")
        {
            Destroy(other.gameObject);
            Life.heart(add, score);
        }
       
    }
}


