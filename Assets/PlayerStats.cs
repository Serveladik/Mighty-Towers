using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public static int money;
    public int startMoney = 100;
    public static int lives;
    public int startLives = 20;

    void Start()
    {
        money = startMoney;
        lives=startLives;
    }
}
