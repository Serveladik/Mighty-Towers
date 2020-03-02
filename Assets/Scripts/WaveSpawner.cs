using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawnPosition;
    public float waveTime = 4;
    private float countdown = 2f;
    private int waveNumber=0;
    private float waveTimer=1f;
    // Update is called once per frame

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
            
            waveNumber++;
            for(int i = 0; i < 1; i++)
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
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemy,spawnPosition.position,spawnPosition.rotation);
    }
}
