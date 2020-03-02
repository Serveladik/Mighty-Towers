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
   void OnMouseEnter()
   {
       if(EventSystem.current.IsPointerOverGameObject())
       {
           return;
       }
       if(!buildMechanics.CheckBuild)
       {
           Debug.Log("CANT BUILD HERE!");
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
           Debug.Log("Tile is Busy");
           buildMechanics.SelectedPlace(this);
           return;
       }
       if(!buildMechanics.CheckBuild)
       {
           Debug.Log("CANT BUILD HERE!");
           return;
       }
    buildMechanics.BuildTurretOn(this);

   }

    void Update()
    {
       
    }
}
