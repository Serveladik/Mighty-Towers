using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
public AudioSource audio;
[Header("Inputs")]
public Slider musicVolumeSlider;
public Text musicTextValue;
   
void Start()
{
    if(PlayerPrefs.HasKey("MusicVolume"))
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        musicTextValue.text = musicVolumeSlider.value.ToString();
    }
    else
    {
        musicVolumeSlider.value = 0.5f;
        musicTextValue.text = musicVolumeSlider.value.ToString();
    }
    
    
}
public void MusicChangeVolume()
   {
       audio.volume=musicVolumeSlider.value;
       musicTextValue.text = musicVolumeSlider.value.ToString();
       PlayerPrefs.SetFloat("MusicVolume",musicVolumeSlider.value);
   }
}
