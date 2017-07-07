using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomlife : MonoBehaviour {

    public GameObject addlife;
    public int num;  //จำนวนการ
    public float waitetime; //รอเวลามา
    public Vector2 area;
    public float startwaite; //รอก่อนเริ่มเกมส์
   
    void Start () {
        StartCoroutine(Randomenemy());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
   
    IEnumerator Randomenemy()
    {
        yield return new WaitForSeconds(startwaite); //รอก่อนเริ่มเกมส์
        while (true)
        {
            for (int i = 0; i < num; i++)
            {
                Vector2 lifePosition = new Vector2(area.x, (Random.Range(-area.y, area.y)));
                Quaternion lifeRotation = Quaternion.identity;
                Instantiate(addlife, lifePosition, lifeRotation);
                yield return new WaitForSeconds(waitetime);
            }
        }
    }
}
