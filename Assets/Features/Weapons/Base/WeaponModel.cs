using System;
using UnityEngine;
public class WeaponModel
{
     public WeaponDataSO weaponData { get; private set; }
     public float CurrentCooldown { get; private set; }
     public float CurrentAmmo { get; private set; }
     public GameObject WeaponProjectilePrefab => weaponData.ProjectilePrefab;

     public WeaponModel(WeaponDataSO _weaponDataSO)
     {
          weaponData = _weaponDataSO;
          CurrentCooldown = 0;
          CurrentAmmo = _weaponDataSO.MaxAmmo;
     }
     public void UpdateWeaponCurrentCooldwon(float deltaTime)
     {
          if (CurrentCooldown >= weaponData.FireRate)
          {
               return;
          }
          CurrentCooldown += deltaTime;
     }
     public bool IsReloaded()
     {
          return CurrentCooldown >= weaponData.FireRate;
     }
     public void ResetCurrentCooldown()
     {
          CurrentCooldown = 0;
     }
     public void RemoveAmmo(int ammoAmount = 1)
     {
          if (CurrentAmmo <= 0)
          {
               return;
          }
          CurrentAmmo -= ammoAmount;
     }
}