using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyTarget))]
public class EnemyMovement : MonoBehaviour
{
    
    public GameObject enemyObject;
    NavMeshAgent navMesh;
    Transform target;
    private EnemyTarget enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyTarget>();
        navMesh = GetComponentInParent<NavMeshAgent>();
        
        navMesh.speed = enemy.startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(navMesh!=null)
        {
            navMesh.SetDestination(GameObject.FindGameObjectWithTag("EndBase").transform.position);
            navMesh.speed = enemy.speed;
            enemy.speed = enemy.startSpeed;
        }
        
    }
    public void OnTriggerEnter(Collider deadZone)
    {
        if(deadZone.gameObject.tag=="EndBase")
        {
            PlayerStats.lives-=1;
            GameObject.Destroy(this.enemyObject);
            //Debug.Log("DEAD");
        }
    }
}
