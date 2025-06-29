using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
     Rifle,
     Railgun,
     RocketLauncher
}

public enum SelectedWeapon
{
     DefaultWeapon,
     AdditionalWeapon
}
public class EquipementModel
{
     private readonly WeaponType DefaultWeapon = WeaponType.Rifle;
     public WeaponType? AdditionalWeapon { get; private set; } = null;
     public SelectedWeapon SelectedWeapon { get; private set; } = SelectedWeapon.DefaultWeapon;

     public void SetAdditionalWeapon(WeaponType weaponType)
     {
          AdditionalWeapon = weaponType;
     }
     public void SetSelectedWeapon(SelectedWeapon selectedWeapon)
     {

          if (selectedWeapon == SelectedWeapon.DefaultWeapon)
          {
               SelectedWeapon = selectedWeapon;
               return;
          }

          if (AdditionalWeapon is not null)
          {
               SelectedWeapon = selectedWeapon;
          }
     }
}
