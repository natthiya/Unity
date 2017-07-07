using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamecontroller : MonoBehaviour {

    public GameObject enemy1;
    public int enemynum;  //จำนวนการมาของศัตรู
    public float waitetime; //รอเวลามา
    public Vector2 area;
    public float waite;  //จำนวนการรอ
    public float startwaite; //รอก่อนเริ่มเกมส์
    public Text gameoverText;
    public Text restartText;
    public Text scoreText;
    public static int score;
    public bool gameover; //ค่าเป็นจริงเท็จ
    private bool restart;
    public GameObject point;
    private PalyerControler player;
    public GameObject enemy2;
    public GameObject Boss;
    bool enemyboss;

    void Start()
    {
        enemyboss = false;
        gameover = false;  //เปิดเกมส์มายังไม่จบ
        restart = false;
        gameoverText.text = "";  //เป็นตัวมาเป็นค่าว่ายังไม่มีข้อความ
        restartText.text = "";
        scoreText.GetComponent<Text>();
        score = 0;
        StartCoroutine(Randomenemy());
        InvokeRepeating("AddEnemy", 2f, 5f);
        player = FindObjectOfType<PalyerControler>();
    }

    public void GameOver()
    {
        gameoverText.text = "GameOver";
        gameover = true;

    }

    void Update()
    {
        scoreText.text = "Score: " + score.ToString();

        if (gameover)
        {
            restart = true;
            restartText.text = "'R'For Restart!";
        }
        if (restart) //restartเป็นจริง
        {
            if (Input.GetKeyDown(KeyCode.R))  //กด R ไหม
            {
                Application.LoadLevel(Application.loadedLevel); //ถ้ากด app โหลดมาใหม่
            }
        }
        if (score > 1 && score % 10 == 0 && enemyboss == false)
        {
            Instantiate(Boss, new Vector2(area.x, (Random.Range(-area.y, area.y))), Quaternion.identity);
            enemyboss = true;
        }
    }

    public static void Addscore(int scorevalue)
    {
        score += scorevalue;  

    }

    IEnumerator Randomenemy()
    {
        yield return new WaitForSeconds(startwaite); //รอก่อนเริ่มเกมส์
        while (true)
        {
            for (int i = 0; i < enemynum; i++)
            {
                Vector2 emPosition = new Vector2(area.x, (Random.Range(-area.y, area.y)));
                Quaternion emRotation = Quaternion.identity;
                Instantiate(enemy1, emPosition, emRotation);
                yield return new WaitForSeconds(waitetime);
            }
            yield return new WaitForSeconds(waite); //รอถัดไป
        }
    }
    void AddEnemy()
    {
        if (gameover == false)
        {
            Vector2 emPosition = new Vector2(area.x, (Random.Range(-area.y, area.y)));
            Instantiate(enemy2, emPosition, Quaternion.identity);
        }
        else
        {
            CancelInvoke("AddEnemy");
        }
    }

    public void Replay()
    {
      GameOver();
    }
}
