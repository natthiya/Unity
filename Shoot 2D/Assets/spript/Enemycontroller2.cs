using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller2 : EnemyController
{
    GameObject player; //เคลื่อนที่ตามผู้เล่น
    private Rigidbody2D rb; //ควบคุมการเคลื่อนที่ของตัวเองใช้แค่ตัวเอง

    public override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>(); // rbรับค่าRigidbody2D
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
    }

    public override void FixedUpdate()
    {
        if (player != null) //ยังไม่ตาบย
        {
            float moveY = 0f;
            //// ผู้เล่นมี Y มากกว่าเรา
            if (Mathf.Round(player.transform.position.y) > Mathf.Round(transform.position.y))
            {
                moveY = 1f;
            }
            else if (Mathf.Round(player.transform.position.y) < Mathf.Round(transform.position.y))
            {
                moveY = -1f;
            }
            rb.velocity = new Vector2(-1f, moveY) * speed;
            if (Gamecontroller.score >= 100)
            {
                rb.velocity = new Vector2(-1f, moveY) * speed2;
            }
        }
    }
}