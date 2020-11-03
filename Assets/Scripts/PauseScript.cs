using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseScript : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject pauseCanvas;
    public Animator fadeOut;
    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale=0f;
    }
    public void Continue()
    {
        Time.timeScale=1f;
        pauseUI.SetActive(!pauseUI.activeSelf);
    }
    public void Settings()
    {
        //settingsUI.SetActive(!settingsUI.activeSelf);
    }
    public void Exit()
    {
        StartCoroutine("ExitIE");
    }
    public IEnumerator ExitIE()
    {
        Time.timeScale=1f;
        pauseCanvas.transform.localScale=new Vector3(0,0,0);
        fadeOut.SetBool("FadeOut",true);
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Menu");  
    }
}
