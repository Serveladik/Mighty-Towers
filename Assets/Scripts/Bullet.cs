using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform enemy;
    public float speed=80f;
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
        Destroy(gameObject);
        Destroy(enemy.gameObject);
        
    }
    void Update()
    {
        ShootLogic();
    }
}
