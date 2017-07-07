using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyController
{
    public int lifes;

    // Use this for initialization
    public override void Start ()
    {
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            lifes -= 1;
            if (lifes <= 0)
            {
                Destroy(gameObject);      
            }
            Gamecontroller.Addscore(scorevalue);
        }
    }
}
