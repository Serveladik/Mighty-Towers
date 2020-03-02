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
    private MapPlacement selectedPlace;
    public GameObject buildEffect;
    public MapUI mapUI;
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
    public bool CheckMoney {get {return  PlayerStats.money >= turretTemplate.price;}}
    public void BuildTurretOn(MapPlacement map)
    {
        if(PlayerStats.money < turretTemplate.price)
        {
           Debug.Log("Not enough money!");
           return;
        }
        else
        {
            PlayerStats.money -=turretTemplate.price;
        }
        GameObject turret = (GameObject) Instantiate(turretTemplate.turretPrefab,map.GetBuildPosition(),Quaternion.identity);
        map.turret = turret;
        GameObject buildEffectInst = (GameObject)Instantiate(buildEffect,map.GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffectInst,2f);
    }
    public void SelectedPlace(MapPlacement place)
    {
        if(selectedPlace==place)
        {
            DeselecMapMenu();
            return;
        }
        selectedPlace = place;
        turretTemplate=null;
        mapUI.SetTurretToMenu(place);
    }
    public void ChooseTurretToBuy(TurretTemplate turret)
    {
        turretTemplate = turret;
        DeselecMapMenu();
    }

    public void DeselecMapMenu()
    {
        selectedPlace=null;
        mapUI.HideMapMenu();
    }
}
