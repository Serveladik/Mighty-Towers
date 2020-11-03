using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesLeft : MonoBehaviour
{
    public Text wavesText;
    public WaveSpawner waveSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wavesText.text = "Waves Left: " + (-1*(PlayerStats.rounds - waveSpawner.waveNumber)-1).ToString();
    }
}
