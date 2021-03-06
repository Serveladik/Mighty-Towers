﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;
    private Transform enemy;
    public float speed=80f;
    public float splashRange = 0f;
    public GameObject hitParticles;
    public void Seeking(Transform _enemy)
    {
        enemy=_enemy;
    }
    void ShootLogic()
    {
        if(enemy == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = enemy.position - transform.position;
        float distance = speed*Time.deltaTime;
        if(direction.magnitude<=distance)
        {
            HitEnemy();
            return;
        }
        transform.Translate(direction.normalized * distance, Space.World);
    }
    void HitEnemy()
    {
        GameObject effect = (GameObject)Instantiate(hitParticles,transform.position,transform.rotation);
        Destroy(effect,2f);
        if(splashRange>0f)
        {
            Explode();
        }
        else
        {
            hitDamage(enemy);
        }
        Destroy(gameObject);
    }
    void Explode()
    {
        Collider[] enemiesInSplash = Physics.OverlapSphere(transform.position,splashRange);
        foreach(Collider splashTragets in enemiesInSplash)
        {
            if(splashTragets.tag =="Enemy")
            {
                hitDamage(splashTragets.transform);
            }
        }
    }
    void hitDamage(Transform enemy)
    {
        EnemyTarget e = enemy.GetComponent<EnemyTarget>();
        
        if(e!=null)
        {
            e.TakeDamage(damage);
        }
        //Destroy(enemy.gameObject);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,splashRange);
    }
    void Update()
    {
        ShootLogic();
    }
}
