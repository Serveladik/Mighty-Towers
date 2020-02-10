using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMechanics : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject choosenTurret;
    public GameObject standartPrefab;
    public GameObject splashPrefab;
    public static BuildMechanics instance;
    void Awake()
    {
        if(instance !=null)
        {
            Debug.LogError("More than 1 BuildMechanics!");
        }
        instance = this;
    }
    

    void Update()
    {
        
    }
    public GameObject BuildTurret()
    {
        return choosenTurret;
    }
    public void ChooseTurretToBuy(GameObject turret)
    {
        choosenTurret = turret;
    }
}
