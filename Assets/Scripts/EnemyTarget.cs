using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTarget : MonoBehaviour
{
    private GameObject enemy;
    //public GameObject endBase;
    NavMeshAgent navMesh;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(GameObject.FindGameObjectWithTag("EndBase").transform.position);
    }

    public void OnTriggerEnter(Collider deadZone)
    {
        if(deadZone.gameObject.tag=="EndBase")
        {
            GameObject.Destroy(this.gameObject);
            Debug.Log("DEAD");
        }
    }
    
}
