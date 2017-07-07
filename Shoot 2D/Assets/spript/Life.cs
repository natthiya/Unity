using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour {

    public int maxhealth;
    public static int playerlifes;
    Text text;
    Gamecontroller gamecontroller;
    public int scorevalue;

    void Start()
    {
        text = GetComponent<Text>();
        playerlifes = maxhealth;
        gamecontroller = FindObjectOfType<Gamecontroller>();
    }
    void Update()
    {
        if (playerlifes <= 0)
        {
            gamecontroller.Replay();
        }
        if (playerlifes >= 0)
        {
            text.text = "X " + playerlifes;
        }
    }
    public static void heart(int down)
    {
        playerlifes--;
    }
    public static void heart(int add, int score)
    {
        playerlifes++;
        //Gamecontroller gcl = new Gamecontroller();
        Gamecontroller.Addscore(score);
    }
}