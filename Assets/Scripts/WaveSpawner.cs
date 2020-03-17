using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
    public WaveInfo[] enemyType;
    public Transform spawnPosition;
    public float waveTime = 4;
    //private float countdown = 2f;
    private int difficulty=0;
    private float waveTimer=1f;
    

public Text waveText;
 
    void Start()
    {
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
        StartCoroutine(SpawnWave());
        waveTimer = waveTime;
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
        
        //waveNumber++;
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy,spawnPosition.position,spawnPosition.rotation);
    }
}
