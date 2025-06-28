using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
     Rifle,
     Railgun,
     RocketLauncher
}
public class EquipementModel
{
     private WeaponType DefaultWeapon = WeaponType.Rifle;
     private WeaponType? AdditionalWeapon;

     public void SetAdditionalWeapon(WeaponType weaponType)
     {
          AdditionalWeapon = weaponType;
     }
}
