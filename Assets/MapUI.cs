using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour
{
   private MapPlacement turretMenu;
   [Header("Upgrade")]
   public Text upgradePriceText;
   public Button upgradeButton;
   public GameObject mapUi;
   public void SetTurretToMenu(MapPlacement turretMenu)
   {
       
        Time.timeScale=0.3f;
         
        
       
       this.turretMenu = turretMenu;
       transform.position = turretMenu.GetBuildPosition();
       
       if(!turretMenu.isUpgraded)
       {
           upgradePriceText.text = "Upgrade:" + "\n" + turretMenu.turretTemplate.upgradePrice.ToString() +"$";
           upgradeButton.interactable = true;
       }
       else
       {
           upgradePriceText.text = "Upgrade:" + "\n" + "Max";
           upgradeButton.interactable = false;
       }
       mapUi.SetActive(true);
   }

    public void HideMapMenu()
    {
        Time.timeScale=1f;
        mapUi.SetActive(false); 
    }
    public void Upgrade()
    {
        turretMenu.UpgradeTurret();
        BuildMechanics.instance.DeselectMapMenu();
    }

    public void Sell()
    {
        turretMenu.SellTurret();
    }

    void Update()
    {
        Debug.Log(Time.timeScale);
    }

}
