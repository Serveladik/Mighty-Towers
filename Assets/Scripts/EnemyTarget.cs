using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTarget : MonoBehaviour
{
    public int bounty = 10;
    public int speed;
    public int health=100;
    private Material enemyMat;
    private GameObject enemy;
    public ParticleSystem deathVFX;
    public GameObject deathEffect;
    //public GameObject endBase;
    NavMeshAgent navMesh;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        enemyMat = gameObject.GetComponentInChildren<Renderer>().material;
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.speed = speed;
       
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(GameObject.FindGameObjectWithTag("EndBase").transform.position);
    }
    public void TakeDamage(int damage)
    {
        health-=damage;
        if(health<=0)
        {
            
            Die();
        }

    }
    void Die()
    {
        PlayerStats.money+=bounty;
        deathVFX.GetComponent<ParticleSystemRenderer>().material = enemyMat;
        GameObject deathFX = (GameObject)Instantiate(deathEffect,transform.position,Quaternion.identity);
        Destroy(deathFX,2f);
        Destroy(this.gameObject);
    }
    public void OnTriggerEnter(Collider deadZone)
    {
        if(deadZone.gameObject.tag=="EndBase")
        {
            PlayerStats.lives-=1;
            GameObject.Destroy(this.gameObject);
            Debug.Log("DEAD");
        }
    }
    
}
