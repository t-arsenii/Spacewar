using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
     private event Action<WeaponModel> OnWeaponChange;
     public List<WeaponModel> EquipementSlots { get; private set; } = new();
     private int maxEquipementSlots = 1;
     public WeaponModel? SelectedWeapon { get; private set; } = null;
     public WeaponModel? DefaultWeapon { get; private set; } = null;
     public EquipementModel SetMaxEquipementSlots(int maxEquipementSlots)
     {
          this.maxEquipementSlots = maxEquipementSlots;
          return this;
     }
     public void AddOnWeaponChangeHandler(Action<WeaponModel> weaponChangeHandler)
     {
          OnWeaponChange += weaponChangeHandler;
     }
     public void AddWeapon(WeaponModel weaponModel)
     {
          if (EquipementSlots.Count >= maxEquipementSlots)
          {
               return;
          }
          EquipementSlots.Add(weaponModel);
     }
     public void AddWeapon(WeaponModel weaponModel, int equipementSlot)
     {
          throw new NotImplementedException();
     }
     public void AddOrOverwriteWeapon(WeaponModel weaponModel)
     {
          if (EquipementSlots.Count < maxEquipementSlots)
          {
               EquipementSlots.Add(weaponModel);
               return;
          }
          EquipementSlots[EquipementSlots.Count - 1] = weaponModel;
          SelectEquipementSlot(EquipementSlots.Count - 1);
     }
     public EquipementModel SetDefaultWeapon(int defaultWeaponIndex, WeaponModel defaultWeapon)
     {
          if (defaultWeaponIndex > maxEquipementSlots - 1)
          {
               Debug.LogWarning($"{typeof(EquipementModel)}: Default weapon index is out of range");
               return this;
          }
          EquipementSlots.Insert(defaultWeaponIndex, defaultWeapon);
          this.DefaultWeapon = defaultWeapon;
          return this;
     }
     public void SelectEquipementSlot(int equipementSlotIndex)
     {
          if (equipementSlotIndex < 0 || equipementSlotIndex >= EquipementSlots.Count)
          {
               return;
          }
          SelectedWeapon = EquipementSlots.ElementAt(equipementSlotIndex);
          OnWeaponChange?.Invoke(SelectedWeapon);
     }
}