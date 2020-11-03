using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeSettingsAwake : MonoBehaviour
{
    public Slider soundsVolumeSlider;
    public Text   soundsTextValue;

    public Slider musicVolumeSlider;
    public Text   musicTextValue;


 void Awake()
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
//////////////////////////////////////////////////////////////////////////////////
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
}
