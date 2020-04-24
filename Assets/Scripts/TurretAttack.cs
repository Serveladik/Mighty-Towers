using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip shotClip;
    public Transform turret;
    public Transform target;
    private EnemyTarget targetEnemy;
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
    public int damageOverTime = 30;
    public float slow=10f;
    private float timer=0;
    public LineRenderer lineRenderer;
    public ParticleSystem laserEffect;
    void Start()
    {
        audio = GameObject.Find("SoundsManager").GetComponent<AudioSource>();
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
                targetEnemy = nearestEnemy.GetComponent<EnemyTarget>();          
            }
        }
        if(nearestEnemy!=null && shortestDistance<=range)
        {
            target=nearestEnemy.transform;
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
                audio.clip=shotClip;
                audio.PlayOneShot(shotClip);
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
       if(target==null)
       {
           timer=0;
       }
       if(target!=null)
       {
        timer-=Time.deltaTime;
        if(timer<=0)
        {
            audio.clip=shotClip;
            audio.PlayOneShot(shotClip);
            timer=0.3f;
        }
        targetEnemy.GetComponent<EnemyTarget>().TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slow);
        lineRenderer.enabled=true;
        laserEffect.Play();
        lineRenderer.SetPosition(0,bulletSpawn.position);
        lineRenderer.SetPosition(1,target.position);
        laserEffect.transform.position = target.position;
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
            turret.transform.LookAt(targetPostition);
        }
    }
}
