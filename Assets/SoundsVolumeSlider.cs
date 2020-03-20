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
    void Start()
    {


        if(PlayerPrefs.HasKey("SoundsVolume"))
        {
            soundsVolumeSlider.value = PlayerPrefs.GetFloat("SoundsVolume");
            soundsTextValue.text = soundsVolumeSlider.value.ToString();
        }
        else
        {
            soundsVolumeSlider.value = 0.5f;
            soundsTextValue.text = soundsVolumeSlider.value.ToString();
        }

    }
       public void SoundsChangeVolume()
       {
           audio.volume=soundsVolumeSlider.value;
           soundsTextValue.text = soundsVolumeSlider.value.ToString();
           PlayerPrefs.SetFloat("SoundsVolume",soundsVolumeSlider.value);
       }
    }
