using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    private int startMoney = 80000;

    public static int lives;
    public int startLives;

    public static int RoundsPlayed;

    private void Start()
    {
        money = startMoney;
        Debug.Log("Money set to startMoney: " + startMoney);

        lives = startLives;

        RoundsPlayed = 0;
    }
}
