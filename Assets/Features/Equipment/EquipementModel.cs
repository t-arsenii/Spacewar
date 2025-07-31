using System;
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
     // private readonly WeaponType DefaultWeapon = WeaponType.Rifle;
     // public WeaponType? AdditionalWeapon { get; private set; } = null;
     // public SelectedWeapon SelectedWeapon { get; private set; } = SelectedWeapon.DefaultWeapon;
     private List<WeaponModel> EquipementSlots = new();
     private int maxEquipementSlots = 1;
     private WeaponModel? selectedWeapon = null;
     private WeaponModel? defaultWeapon = null;
     public EquipementModel SetMaxEquipementSlots(int maxEquipementSlots)
     {
          this.maxEquipementSlots = maxEquipementSlots;
          return this;
     }
     public void AddWeaponToEquipementSlot(WeaponModel weaponModel)
     {
          if (EquipementSlots.Count >= maxEquipementSlots)
          {
               return;
          }
          EquipementSlots.Add(weaponModel);
     }
     public void AddWeaponToEquipementSlot(WeaponModel weaponModel, int equipementSlot)
     {
          throw new NotImplementedException();
     }
     public EquipementModel SetDefaultWeapon(int defaultWeaponIndex, WeaponModel defaultWeapon)
     {
          if (defaultWeaponIndex > maxEquipementSlots - 1)
          {
               Debug.LogWarning($"{typeof(EquipementModel)}: Default weapon index is out of range");
               return this;
          }
          EquipementSlots.Insert(defaultWeaponIndex, defaultWeapon);
          this.defaultWeapon = defaultWeapon;
          return this;
     }
}