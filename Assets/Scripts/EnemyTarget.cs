using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTarget : MonoBehaviour
{
    [HideInInspector]
    public float speed=10f;
    public int bounty = 10;
    public float health=100;
    public float startSpeed =10;
    public GameObject enemy;
    public ParticleSystem deathVFX;
    public GameObject deathEffect;
    //public GameObject endBase;
    private Material enemyMat;
    void Start()
    {
        speed = startSpeed;
        enemyMat = gameObject.GetComponentInParent<Renderer>().material; 
    }

    public void TakeDamage(float damage)
    {
        
        health-=damage;
        if(health<=0)
        {
            
            Die();
        }

    }
    public void Slow(float slowing)
    {
        speed = startSpeed * (1f-slowing);
        
    }
    void Die()
    {
        PlayerStats.money+=bounty;
        deathVFX.GetComponent<ParticleSystemRenderer>().material = enemyMat;
        GameObject deathFX = (GameObject)Instantiate(deathEffect,transform.position,Quaternion.identity);
        Destroy(deathFX,2f);
        Destroy(this.enemy);
    }
   
    
}
