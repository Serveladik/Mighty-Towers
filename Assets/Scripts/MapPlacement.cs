using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class MapPlacement : MonoBehaviour
{
    private Vector3 offset = new Vector3(0,0.5f,0);
    public Color highlightTile;
    private Renderer tileRender;
    private Color defaultTileColor;
    public GameObject turret;
    public TurretTemplate turretTemplate;
    public bool isUpgraded;
    BuildMechanics buildMechanics;
    
    void Start()
    {
        buildMechanics = BuildMechanics.instance;
        tileRender = GetComponent<Renderer>();
        defaultTileColor = tileRender.material.color;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + offset;
    }
    void BuildTurret(TurretTemplate template)
    {
        if(PlayerStats.money < template.price)
        {
           //Debug.Log("Not enough money!");
           return;
        }
        else
        {
            PlayerStats.money -=template.price;
        }
        GameObject turret = (GameObject) Instantiate(template.turretPrefab,GetBuildPosition(),Quaternion.identity);
        this.turret = turret;
        turretTemplate = template;
        GameObject buildEffectInst = (GameObject)Instantiate(buildMechanics.buildEffect,GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffectInst,2f);
    }
   void OnMouseEnter()
   {
       if(EventSystem.current.IsPointerOverGameObject())
       {
           return;
       }
       if(!buildMechanics.CheckBuild)
       {
           //Debug.Log("CANT BUILD HERE!");
           return;
       }

       if(buildMechanics.CheckMoney)
       {
           tileRender.material.color = highlightTile;
       }
       else
       {
           tileRender.material.color = Color.red;
       }
       
   }
   public void UpgradeTurret()
   {
       if(PlayerStats.money < turretTemplate.upgradePrice)
        {
           Debug.Log("Not enough money!");
           return;
        }
        else
        {
            PlayerStats.money -= turretTemplate.upgradePrice;
        }
        //Destroy old turret
        Destroy(this.turret);
        this.turretTemplate = turretTemplate;
        
        GameObject turret = (GameObject) Instantiate(turretTemplate.upgradePrefab,GetBuildPosition(),Quaternion.identity);
        this.turret = turret;
        GameObject buildEffectInst = (GameObject)Instantiate(buildMechanics.buildEffect,GetBuildPosition(), Quaternion.identity);
        
        Destroy(buildEffectInst,2f);
        isUpgraded=true;
   }
   public void SellTurret()
   {
        PlayerStats.money += turretTemplate.GetSellPrice();

        GameObject sellEffectInst = (GameObject)Instantiate(buildMechanics.sellEffect,GetBuildPosition(), Quaternion.identity);
        Destroy(sellEffectInst,2f);

        Destroy(this.turret);
        turretTemplate=null;
   }
   void OnMouseExit()
   {
       tileRender.material.color = defaultTileColor;
   }
   void OnMouseDown()
   {
       if(EventSystem.current.IsPointerOverGameObject())
       {
           return;
       }
       if(turret!=null)
       {
           //Debug.Log("Tile is Busy");
           buildMechanics.SelectedPlace(this);
           return;
       }
       if(!buildMechanics.CheckBuild)
       {
           //Debug.Log("CANT BUILD HERE!");
           return;
       }
    BuildTurret(buildMechanics.GetTurretToBuild());

   }

    
}
