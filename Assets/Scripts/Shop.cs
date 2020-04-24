using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretTemplate standartTurret;
    public TurretTemplate splashTurret;
    public TurretTemplate laserTurret;

    BuildMechanics buildMechanics;
    void Start()
    {
        buildMechanics = BuildMechanics.instance;
    }
    public void BuyStandartTurret()
    {
        buildMechanics.ChooseTurretToBuy(standartTurret);
    }
    public void BuySplashTurret()
    {
        buildMechanics.ChooseTurretToBuy(splashTurret);
    }
    public void BuyLaserTurret()
    {
       buildMechanics.ChooseTurretToBuy(laserTurret);
    }
    public void BuyAirTurret()
    {
        Debug.Log("AirBOUGHT");
    }
}
