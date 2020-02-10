using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildMechanics buildMechanics;
    void Start()
    {
        buildMechanics = BuildMechanics.instance;
    }
    public void BuyFirstTurret()
    {
        //Debug.Log("FIrstBOUGHT");
        buildMechanics.ChooseTurretToBuy(buildMechanics.standartPrefab);
    }
    public void BuySplashTurret()
    {
        //Debug.Log("SplashBOUGHT");
        buildMechanics.ChooseTurretToBuy(buildMechanics.splashPrefab);
    }
    public void BuyAirTurret()
    {
        Debug.Log("AirBOUGHT");
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
