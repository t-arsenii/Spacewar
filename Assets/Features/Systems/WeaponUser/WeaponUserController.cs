using Unity.VisualScripting;
using UnityEngine;

public class WeaponUserController : MonoBehaviour, IWeaponUserController
{
     private IEquipmentController equipmentController;
     private Rigidbody2D rigidBody;
     private float weaponCooldown = 0.5f;
     private float weaponCurrentCooldown = 0;
     [SerializeField] Transform shootingTransformPoint;
     private void Start()
     {
          equipmentController = this.GetComponent<IEquipmentController>();
          rigidBody = this.GetComponent<Rigidbody2D>();
          equipmentController.AddOnWeaponChangeHandler(SetWeaponCooldown);
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

          // if (equipmentController.SelectedWeapon == SelectedWeapon.DefaultWeapon)
          // {
          //      ShootProjectile(bulletGameObject);
          // }
          // else if (equipmentController.AdditionalWeapon == WeaponType.RocketLauncher)
          // {
          //      ShootProjectile(rocketGameObject);
          // }
          // else if (equipmentController.AdditionalWeapon == WeaponType.Railgun)
          // {
          //      ShootProjectile(laserBeamGameObject);
          // }
          ResetWeaponCooldown();
     }
     private void ShootProjectile(GameObject projectileGameObject)
     {
          if (weaponCurrentCooldown >= weaponCooldown)
          {
               if (Input.GetKey(KeyCode.Space)) return;

               var bullet = Instantiate<GameObject>(projectileGameObject, shootingTransformPoint.position, shootingTransformPoint.rotation);
               bullet.GetComponent<IProjectileController>().SetInitialVelocity(rigidBody.linearVelocity);
          }

          if (weaponCurrentCooldown >= weaponCooldown)
          {
               weaponCurrentCooldown = 0;
               return;
          }

          weaponCurrentCooldown += Time.deltaTime;
     }
     private void UpdateWeaponCooldown()
     {
          if (weaponCurrentCooldown < weaponCooldown)
          {
               weaponCurrentCooldown += Time.deltaTime;
          }
     }
     private void SetWeaponCooldown(float cooldown)
     {
          weaponCooldown = cooldown;
     }
     private bool CanShoot()
     {
          return weaponCurrentCooldown > weaponCooldown;
     }
     private void ResetWeaponCooldown()
     {
          weaponCurrentCooldown = 0;
     }

}

public interface IWeaponUserController
{
     public void Shoot();
}