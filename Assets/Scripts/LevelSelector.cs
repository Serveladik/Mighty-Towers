using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Animator animation;
    public Button[] levelButtons;

    void Start()
    {
        
        int levelProgress = PlayerPrefs.GetInt("Level",1);
        for ( ;levelProgress < levelButtons.Length; levelProgress++)
        {
            levelButtons[levelProgress].interactable  = false;
        }
    }
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
