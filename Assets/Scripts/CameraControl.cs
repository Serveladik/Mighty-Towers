using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
  
    private Vector3 startPos;
    public float zoomIn=10f;
    public float zoomOut=65f;
    private float step;
    public Camera cameraMain;
   
    
    public float panSensitivity = 10f;

   void Start()
   {
       //cameraMain = gameObject.GetComponent<Transform>();
   }
    void Update()
    {
        if(GameManager.gameOver)
        {
            this.enabled = false;
            return;
        }
        Pan();
        Zoom();
    }
    void Pan()
    {
        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
         Vector2 touchPos = Input.GetTouch(0).deltaPosition;
         transform.Translate(-touchPos.x * panSensitivity/100, -touchPos.y * panSensitivity/100,0);

         transform.position = new Vector3(
            Mathf.Clamp(transform.position.x,-60f,-20f),
            Mathf.Clamp(transform.position.y,55,55),
            Mathf.Clamp(transform.position.z,-30f,10f)
            );
         
        }
    }

    

    void Zoom()
    {
        if(Input.touchCount==2)
        {
            Touch touchFirst = Input.GetTouch(0);
            Touch touchSecond = Input.GetTouch(1);

            Vector2 touchFirstPos = touchFirst.position - touchFirst.deltaPosition;
            Vector2 touchSecondPos = touchSecond.position - touchSecond.deltaPosition;

            float firstMagnitude = (touchFirstPos - touchSecondPos).magnitude;
            float secondMagnitude = (touchFirst.position - touchSecond.position).magnitude;

            float difference = secondMagnitude - firstMagnitude;

            step = difference * 0.15f;
            
        }
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - step,zoomIn,zoomOut);

    }
    
}
