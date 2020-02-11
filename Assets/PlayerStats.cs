using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public static int money;
    public int startMoney = 100;

    void Start()
    {
        money = startMoney;
    }
}
