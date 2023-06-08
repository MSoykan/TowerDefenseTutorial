using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    private int StartMoney = 80000;

    public static int Lives;
    public int StartLives;

    public static int RoundsPlayed;

    private void Start()
    {
        Money = StartMoney;
        Debug.Log("Money set to startMoney: " + StartMoney);

        Lives = StartLives;

        RoundsPlayed = 0;
    }
}
