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
    private GameObject turret;
    BuildMechanics buildMechanics;
    
    void Start()
    {
        buildMechanics = BuildMechanics.instance;
        tileRender = GetComponent<Renderer>();
        defaultTileColor = tileRender.material.color;
    }
   void OnMouseEnter()
   {
       if(EventSystem.current.IsPointerOverGameObject())
       {
           return;
       }
       if(buildMechanics.BuildTurret()==null)
       {
           return;
       }
       tileRender.material.color = highlightTile;
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
       if(buildMechanics.BuildTurret()==null)
       {
           return;
       }
       if(turret!=null)
       {
           Debug.Log("Tile is Busy");
           return;
       }
    GameObject choosenTurret = BuildMechanics.instance.BuildTurret();
    turret = (GameObject)Instantiate(choosenTurret,transform.position+offset,transform.rotation);

   }

    void Update()
    {
       
    }
}
