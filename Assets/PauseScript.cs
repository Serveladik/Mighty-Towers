using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }

}
