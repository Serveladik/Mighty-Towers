using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public Animator fadein;
    public string nextLevel = "Level02";
    public void LoadNextLevel()
    {
        StartCoroutine("LoadScene",nextLevel);
    }
    
    public IEnumerator LoadScene(string level)
    {
        //FadeIn
        fadein.SetBool("FadeOut",true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
}
