using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPScounter : MonoBehaviour
{
    public Text fps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fps.text = "FPS: " + (1f / Time.unscaledDeltaTime).ToString("#.##"); 
    }
}
