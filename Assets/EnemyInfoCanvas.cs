using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfoCanvas : MonoBehaviour
{
   public Transform Camera;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(Camera,Vector3.up);
    }
}
