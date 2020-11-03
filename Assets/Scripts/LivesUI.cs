using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text livesUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesUI.text = "Lives: " + PlayerStats.lives.ToString();
    }
}
