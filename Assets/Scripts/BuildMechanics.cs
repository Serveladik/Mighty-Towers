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
    private TurretTemplate turretTemplate;
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
    public bool CheckBuild {get {return  turretTemplate != null;}}
    public void BuildTurretOn(MapPlacement map)
    {
        if(PlayerStats.money < turretTemplate.price)
        {
           Debug.Log("Not enough money!");
        }
        PlayerStats.money -=turretTemplate.price;

        GameObject turret = (GameObject) Instantiate(turretTemplate.turretPrefab,map.GetBuildPosition(),Quaternion.identity);
        map.turret = turret;
        
    }
    public void ChooseTurretToBuy(TurretTemplate turret)
    {
        turretTemplate = turret;
    }
}
