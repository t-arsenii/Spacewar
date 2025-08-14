using System;
using UnityEngine;

public class WeaponUserController : MonoBehaviour, IWeaponUserController
{
     private IEquipmentController equipmentController;
     private Rigidbody2D rigidBody;
     [SerializeField] Transform shootingTransformPoint;
     private event Action<WeaponModel> OnSelectedWeaponAmmoChange;
     private void Start()
     {
          equipmentController = this.GetComponent<IEquipmentController>();
          rigidBody = this.GetComponent<Rigidbody2D>();
     }
     private void Update()
     {
          UpdateWeaponCooldown();
     }
     private void FixedUpdate()
     {

     }

     public void Shoot()
     {
          if (!CanShoot()) return;
          WeaponModel selectedWeapon = equipmentController.GetSelectedEquipement();
          ShootProjectile(selectedWeapon.WeaponProjectilePrefab);
          if (selectedWeapon != equipmentController.GetDefaultEquipement())
          {
               selectedWeapon.RemoveAmmo();
               OnSelectedWeaponAmmoChange?.Invoke(selectedWeapon);
          }
          selectedWeapon.ResetCurrentCooldown();

     }
     private void ShootProjectile(GameObject projectileGameObject)
     {
          var projectile = Instantiate<GameObject>(projectileGameObject, shootingTransformPoint.position, shootingTransformPoint.rotation);
          projectile.GetComponent<IProjectileController>().SetInitialVelocity(rigidBody.linearVelocity);
     }
     private void UpdateWeaponCooldown()
     {
          WeaponModel? selectedWeapon = equipmentController.GetSelectedEquipement();
          if (selectedWeapon is null)
          {
               return;
          }
          selectedWeapon.UpdateWeaponCurrentCooldwon(Time.deltaTime);
     }
     private bool CanShoot()
     {
          WeaponModel selectedWeapon = equipmentController.GetSelectedEquipement();
          if (selectedWeapon is null)
          {
               return false;
          }
          Debug.Log($"{selectedWeapon.weaponData.WeaponType}: {selectedWeapon.CurrentAmmo}");
          return (selectedWeapon.IsReloaded() && selectedWeapon.CurrentAmmo > 0);
     }

     public void AddOnSelectedWeaponAmmoChangeHandler(Action<WeaponModel> ammoChangeHandler)
     {
          OnSelectedWeaponAmmoChange += ammoChangeHandler;
     }
}

public interface IWeaponUserController
{
     public void Shoot();
     public void AddOnSelectedWeaponAmmoChangeHandler(Action<WeaponModel> ammoChangeHandler);
}