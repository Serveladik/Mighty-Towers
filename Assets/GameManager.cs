using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject victoryCanvas;
    public static bool gameOver;
    public GameObject gameOverUI;
    public Animator animation;
    
    public int unlockNextLevel = 2;
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
    public void Completelevel()
    {
        victoryCanvas.SetActive(true);
        PlayerPrefs.SetInt("Level",unlockNextLevel);
        Time.timeScale=1;
        animation.SetBool("Victory",true);
        
    }
    
    
}
