using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseUI;
    void Update()
    {
        
    }
    public void Pause()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);
        if(pauseUI.activeSelf)
        {
            Time.timeScale=0f;
        }
        else
        {
            Time.timeScale=1f;
        }
    }
    public void Settings()
    {
        //settingsUI.SetActive(!settingsUI.activeSelf);
    }

}
