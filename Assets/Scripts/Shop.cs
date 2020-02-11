using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretTemplate standartTurret;
    public TurretTemplate splashTurret;
    BuildMechanics buildMechanics;
    void Start()
    {
        buildMechanics = BuildMechanics.instance;
    }
    public void BuyStandartTurret()
    {
        //Debug.Log("FIrstBOUGHT");
        buildMechanics.ChooseTurretToBuy(standartTurret);
    }
    public void BuySplashTurret()
    {
        //Debug.Log("SplashBOUGHT");
        buildMechanics.ChooseTurretToBuy(splashTurret);
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
