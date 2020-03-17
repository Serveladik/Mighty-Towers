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
        Time.timeScale=1f;
    }
    public void PlayBtn()
    {
        StartCoroutine("PlayButton");
    }
    public void BackBtn()
    {
        StartCoroutine("BackButton");
    }
   public IEnumerator PlayButton()
   {
       menuAnim.SetBool("Play",true);
       yield return new WaitForSeconds(1f);
       mainMenu.SetActive(false);
       SelectLevel.SetActive(true);
   }
   public IEnumerator BackButton()
   {
       menuAnim.SetBool("Play",false);
       levelSelectAnim.SetBool("LoadingLevel",true);
       yield return new WaitForSeconds(0.5f);
       mainMenu.SetActive(true);
       SelectLevel.SetActive(false);
   }
}
