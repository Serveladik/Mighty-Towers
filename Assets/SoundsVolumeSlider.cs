using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsVolumeSlider : MonoBehaviour
{
    public AudioSource audio;
    [Header("Inputs")]
    public Slider soundsVolumeSlider;
    public Text soundsTextValue;
    
       public void SoundsChangeVolume()
       {
           audio.volume=soundsVolumeSlider.value;
           soundsTextValue.text = soundsVolumeSlider.value.ToString();
           PlayerPrefs.SetFloat("SoundsVolume",soundsVolumeSlider.value);
       }
    }
