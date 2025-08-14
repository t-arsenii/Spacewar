using System;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EquipmentController : MonoBehaviour, IEquipmentController
{
     private EquipementModel equipement;
     [SerializeField] private WeaponDataSO defaultWeaponSO;
     void Awake()
     {
          equipement = new EquipementModel().SetMaxEquipementSlots(2).SetDefaultWeapon(0, new WeaponModel(defaultWeaponSO));
          equipement.SelectEquipementSlot(0);
     }

     public void PickupItem(WeaponModel weapon)
     {
          equipement.AddOrOverwriteWeapon(weapon);
     }

     public void SelectEquipement(int equipementSlot)
     {
          equipement.SelectEquipementSlot(equipementSlot);
     }
     public void AddOnWeaponChangeHandler(Action<WeaponModel> OnWeaponChangeHandler)
     {
          equipement.AddOnWeaponChangeHandler(OnWeaponChangeHandler);
     }

     public WeaponModel GetEquipementBySlotIndex(int index)
     {
          throw new NotImplementedException();
     }

     public WeaponModel GetSelectedEquipement()
     {
          return equipement.SelectedWeapon;
     }
     public WeaponModel? GetDefaultEquipement()
     {
          return equipement.DefaultWeapon;
     }
}

interface IEquipmentController
{
     public void PickupItem(WeaponModel item);
     public void SelectEquipement(int equipementSlotId);
     public WeaponModel? GetEquipementBySlotIndex(int index);
     public WeaponModel? GetSelectedEquipement();
     public WeaponModel? GetDefaultEquipement();
     public void AddOnWeaponChangeHandler(Action<WeaponModel> OnWeaponChangeHandler);
}