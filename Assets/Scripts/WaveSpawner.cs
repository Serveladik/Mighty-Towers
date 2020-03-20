using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
    
    public GameManager gameManager;
    public WaveInfo[] enemyType;
    public Transform spawnPosition;
    public int waveNumber=1;
    public float waveTime = 4;
    //private float countdown = 2f;
    private int difficulty=0;
    private float waveTimer=1f;
    
    

public Text waveText;
 
    void Start()
    {
        gameManager = gameObject.GetComponent<GameManager>();
        waveTimer = waveTime;
        WaveTimer();
        StartCoroutine(SpawnWave());
    }
    void Update()
    {
        
        WaveTimer();
  
    }


 void WaveTimer()
 {
    if(waveTimer>0)
    { 
        waveTimer-=Time.deltaTime;
        waveText.text = "Next Wave: " + string.Format("{0:00.00}",waveTimer);
    } 
    if(waveTimer<=0)
    {
        
        if(waveNumber-1==PlayerStats.rounds)
        {
            
            Debug.Log("You won!");
            gameManager.Completelevel();
            StopCoroutine(SpawnWave());
        }
        else
        {
            StartCoroutine(SpawnWave());
            waveTimer = waveTime;
        }
        //Difficulty per waves
        if(difficulty<enemyType.Length-1)
        {
            if(PlayerStats.rounds>0 && PlayerStats.rounds%5==0)
            {
                difficulty++;
                return;
            }
        }
        Debug.Log("Difficulty: " + difficulty);
    }
 }

    IEnumerator SpawnWave()
    {
        PlayerStats.rounds++;
        WaveInfo wave = enemyType[difficulty];
        for(int i = 0; i < wave.count; i++)
        {
            
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
            
        }
        
        
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy,spawnPosition.position,spawnPosition.rotation);
    }
}
