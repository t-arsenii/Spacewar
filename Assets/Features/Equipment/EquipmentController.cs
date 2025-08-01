using System;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EquipmentController : MonoBehaviour, IEquipmentController
{
     private EquipementModel equipement;
     [SerializeField] private WeaponDataSO defaultWeaponSO;

     private event Action<float> OnWeaponChange;

     void Awake()
     {
          equipement = new EquipementModel().SetMaxEquipementSlots(2).SetDefaultWeapon(0, new WeaponModel(defaultWeaponSO));
     }

     public void PickupWeapon(WeaponModel weapon)
     {
          equipement.AddWeaponToEquipementSlot(weapon);
     }

     public void SelectWeapon(SelectedWeapon selectedWeapon)
     {
          // if (selectedWeapon != SelectedWeapon.AdditionalWeapon)
          // {
          //      equipement.SetSelectedWeapon(selectedWeapon);
          //      return;
          // }

          // if (AdditionalWeapon is null)
          // {
          //      return;
          // }
          // equipement.SetSelectedWeapon(selectedWeapon);
          // //TODO: Pile of shit code, passing weapon cooldowns to a WeaponUserController
          // switch (AdditionalWeapon)
          // {
          //      case WeaponType.Rifle:
          //           OnWeaponChange.Invoke(0.5f);
          //           break;
          //      case WeaponType.Railgun:
          //           OnWeaponChange.Invoke(0.5f);
          //           break;
          //      case WeaponType.RocketLauncher:
          //           OnWeaponChange.Invoke(0.5f);
          //           break;
          // }
     }
     public void AddOnWeaponChangeHandler(Action<float> OnWeaponChangeHandler)
     {
          OnWeaponChange += OnWeaponChangeHandler;
     }
}

interface IEquipmentController
{
     public void PickupWeapon(WeaponType item);
     public void SelectWeapon(SelectedWeapon selectedWeapon);
     // public SelectedWeapon SelectedWeapon { get; }
     // public WeaponType? AdditionalWeapon { get; }
     public void AddOnWeaponChangeHandler(Action<float> OnWeaponChangeHandler);
}