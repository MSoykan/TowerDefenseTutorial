using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    private int startMoney = 800;

    public static int lives;
    public int startLives;

    private void Start()
    {
        money = startMoney;
        Debug.Log("Money set to startMoney: " + startMoney);

        lives = startLives;
    }
    public int GetLives()
    {
        return lives;
    }
}
