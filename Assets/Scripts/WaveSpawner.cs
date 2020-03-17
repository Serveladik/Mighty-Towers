using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyType;
    public WaveInfo[] waves;
    public Transform spawnPosition;
    public float waveTime = 4;
    private float countdown = 2f;
    private int waveNumber=0;
    private float waveTimer=1f;
    

public Text waveText;
 
    void Start()
    {
        waveTime=1;
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
    
    if(waveTimer>=0)
    {
        
        waveTimer-=Time.deltaTime;
        waveText.text = "Next Wave: " + string.Format("{0:00.00}",waveTimer);
    }
    
    
    
 }

    IEnumerator SpawnWave()
    {
        
        //yield return new WaitForSeconds(0.5f);
        while (true)
        {
            waveTime=5;
            
            for(int i = 0; i < waveNumber; i++)
            {
                PlayerStats.rounds++;
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(waveTime);
            waveTimer=waveTime+0.5f;
            waveNumber++;
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyType,spawnPosition.position,spawnPosition.rotation);
    }
}
