using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlayButton : MonoBehaviour
{
    public GameObject SelectLevel;
    public GameObject mainMenu;
    public Animator menuAnim;
    public Animator levelSelectAnim;
    void Awake()
    {
        //Time.timeScale=1f;
    }
    public void PlayBtn()
    {
        StartCoroutine("PlayButton");
    }
    public void BackBtn()
    {
        StartCoroutine("BackButton");
    }
    public void BackSettingsBtn()
    {
        StartCoroutine("BackSettingsButton");
    }
    public void EnterSettingsBtn()
    {
        StartCoroutine("EnterSettingsButton");
    }
   public IEnumerator PlayButton()
   {
       menuAnim.SetBool("Play",true);
       yield return new WaitForSecondsRealtime(1f);
       mainMenu.SetActive(false);
       SelectLevel.SetActive(true);
   }
   public IEnumerator BackButton()
   {
       menuAnim.SetBool("Play",false);
       yield return new WaitForSecondsRealtime(0.5f);
       mainMenu.SetActive(true);
       SelectLevel.SetActive(false);
   }

   
   public IEnumerator EnterSettingsButton()
   {
    menuAnim.SetBool("PauseFadeOut",true);
    yield return new WaitForSecondsRealtime(0.5f);
    mainMenu.SetActive(false);
    SelectLevel.SetActive(true);
   
   }
   public IEnumerator BackSettingsButton()
   {
    levelSelectAnim.SetBool("SettingsOut",true);
    yield return new WaitForSecondsRealtime(0.5f);
    SelectLevel.SetActive(false);
    mainMenu.SetActive(true);
    
   }
}
