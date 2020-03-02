using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverUI;
    void Update()
    {
        if(gameOver==true)
        return;
        
        if(PlayerStats.lives <=0)
        {
            GameOver();
        }
    }
void Start()
{
    gameOver=false;
}
    void GameOver()
    {
        gameOver=true;
        gameOverUI.SetActive(true);
        return;
    }
}
