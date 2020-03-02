using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUI : MonoBehaviour
{
   private MapPlacement turretMenu;
   public GameObject mapUi;
   public void SetTurretToMenu(MapPlacement turretMenu)
   {

       this.turretMenu = turretMenu;
       transform.position = turretMenu.GetBuildPosition();
       mapUi.SetActive(true);
   }

    public void HideMapMenu()
    {
        mapUi.SetActive(false); 
    }

}
