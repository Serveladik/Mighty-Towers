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
   
    public void SelectedPlace(MapPlacement place)
    {
        if(selectedPlace==place)
        {
            DeselectMapMenu();
            return;
        }
        selectedPlace = place;
        turretTemplate=null;
        mapUI.SetTurretToMenu(place);
    }
    public void ChooseTurretToBuy(TurretTemplate turret)
    {
        turretTemplate = turret;
        DeselectMapMenu();
    }

    public void DeselectMapMenu()
    {
        selectedPlace=null;
        mapUI.HideMapMenu();
    }
    public TurretTemplate GetTurretToBuild()
    {
        return turretTemplate;
    }
}
