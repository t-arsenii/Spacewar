using UnityEngine;
public class WeaponModel
{
     public WeaponDataSO weaponData { get; private set; }
     public float CurrentCooldown { get; private set; }
     public float CurrentAmmo { get; private set; }

     public WeaponModel(WeaponDataSO _weaponDataSO)
     {
          weaponData = _weaponDataSO;
          CurrentCooldown = 0;
          CurrentAmmo = _weaponDataSO.MaxAmmo;
     }
}