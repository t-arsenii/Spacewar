using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EquipmentController : MonoBehaviour, IEquipmentController
{
     private EquipementModel equipement;

     public SelectedWeapon SelectedWeapon => equipement.SelectedWeapon;

     public WeaponType? AdditionalWeapon => equipement.AdditionalWeapon;

     void Awake()
     {
          equipement = new EquipementModel();
     }

     public void PickupWeapon(WeaponType item)
     {
          equipement.SetAdditionalWeapon(item);
     }

     public void SelectWeapon(SelectedWeapon selectedWeapon)
     {
          if (selectedWeapon != SelectedWeapon.AdditionalWeapon)
          {
               equipement.SetSelectedWeapon(selectedWeapon);
               return;
          }

          if (AdditionalWeapon is null)
          {
               return;
          }
          equipement.SetSelectedWeapon(selectedWeapon);
     }
}

interface IEquipmentController
{
     public void PickupWeapon(WeaponType item);
     public void SelectWeapon(SelectedWeapon selectedWeapon);
     public SelectedWeapon SelectedWeapon { get; }
     public WeaponType? AdditionalWeapon { get; }
}