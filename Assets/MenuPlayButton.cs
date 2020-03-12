using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlayButton : MonoBehaviour
{
    public Animator menuAnim;
    void Awake()
    {
        Time.timeScale=1f;
    }
    public void PlayBtn()
    {
        StartCoroutine("PlayButton");
    }
   public IEnumerator PlayButton()
   {
       menuAnim.SetBool("Play",true);
       yield return new WaitForSeconds(2f);
       SceneManager.LoadScene("Level1");
   }
}
