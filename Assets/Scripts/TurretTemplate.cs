﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretTemplate
{
    
   public GameObject turretPrefab;
   public int price;

   public GameObject upgradePrefab;
   public int upgradePrice;


   public int GetSellPrice()
   {
      return price / 2;
   }
}
