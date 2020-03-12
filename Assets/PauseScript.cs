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
        StartCoroutine("ExitIE");
    }

    public IEnumerator ExitIE()
    {
        Time.timeScale=1f;
        pauseCanvas.transform.localScale=new Vector3(0,0,0);
        fadeOut.SetBool("FadeOut",true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu"); 
        Debug.Log("MENU!");
    }

}
