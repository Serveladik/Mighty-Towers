using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    public Transform turret;
    public Transform target;
    public float rotationSpeed=100f;
    float shortestDistance = Mathf.Infinity;
    [Header("Default bullets")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    [Header("Turret Stats")]
    public float range = 15f;
    public float fireSpeed =1f;
    private float fireTimer=0f;
    [Header("Laser Stats")]
    public bool useLaser=false;
    public LineRenderer lineRenderer;
    public ParticleSystem laserEffect;
    void Start()
    {
        turret = GetComponent<Transform>();
        InvokeRepeating("SearchTarget",0f,0.1f);
    }
    void Update()
    {
        
        Shoot();
        LookAtEnemy();
    }
    void SearchTarget()
    {
        

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy=null;
        shortestDistance = Mathf.Infinity;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position);
            if(distanceToEnemy<shortestDistance)
            {
                shortestDistance=distanceToEnemy; 
                nearestEnemy=enemy;
                
            }
        }
        if(nearestEnemy!=null && shortestDistance<=range)
        {
            
            target=nearestEnemy.transform;
            
            Debug.Log("Attack");
        }
        else
        {
            
            target=null;
            
        }
       
        
    }

   void Shoot()
   {
       if(useLaser==true)
       {
           Laser();
       }
       else
        {
            if(fireTimer<=0f && target!=null)
            {
                GameObject bulletGO = (GameObject)Instantiate(bulletPrefab,bulletSpawn.position,bulletSpawn.rotation);
                Bullet bullet = bulletGO.GetComponent<Bullet>();
                if(bullet!=null)
                {
                    bullet.Seeking(target);
                }
                fireTimer=1f/fireSpeed;   
            }
       }
       fireTimer-=Time.deltaTime;
   }
   void Laser()
   {
       //if(!lineRenderer.enabled)
       if(target!=null)
       {
        lineRenderer.enabled=true;
        laserEffect.Play();

        lineRenderer.SetPosition(0,bulletSpawn.position);
        lineRenderer.SetPosition(1,target.position);

        //Vector3 laserDir = bulletSpawn.position - target.position;
        
        laserEffect.transform.position = target.position;
        //laserEffect.transform.rotation = Quaternion.LookRotation(laserDir);
       }
        
        else
        {
            lineRenderer.enabled=false;
            laserEffect.Stop();
        }
   }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
    void LookAtEnemy()
    {
        if(target!=null && shortestDistance<=range)
        {
            Vector3 targetPostition = new Vector3(
                target.position.x, 
                this.transform.position.y, 
                target.position.z);
            //Debug.DrawLine(transform.position,target.transform.position,Color.red,1f);
            turret.transform.LookAt(targetPostition);
            //turret.transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(nearestEnemy.transform.position),Time.deltaTime*rotationSpeed);
        }
       
    }
}
