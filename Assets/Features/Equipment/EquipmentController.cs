using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EquipmentController : MonoBehaviour, IEquipmentController
{
     private EquipementModel equipement;
     void Awake()
     {
          equipement = new EquipementModel();
     }

     public void PickupWeapon(WeaponType item)
     {
          equipement.SetAdditionalWeapon(item);
     }
}

interface IEquipmentController
{
     public void PickupWeapon(WeaponType item);
}