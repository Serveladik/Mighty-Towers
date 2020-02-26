using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameOver = false;
    void Update()
    {
        if(gameOver==true)
        return;
        
        if(PlayerStats.lives <=0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver=true;
        Debug.Log("GameOver!");
        return;
    }
}
