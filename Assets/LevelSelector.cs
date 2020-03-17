using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public Animator animation;
    
   public void SelectScene(string level)
   {
        StartCoroutine(LoadScene(level));
   }


    public IEnumerator LoadScene(string level)
    {
        animation.SetBool("LoadingLevel",true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(level);
    }

}
