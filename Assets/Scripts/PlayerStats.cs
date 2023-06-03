using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    private int startMoney = 400;

    private void Start()
    {
        money = startMoney;
        Debug.Log("Money set to startMoney: " + startMoney);
    }
}
