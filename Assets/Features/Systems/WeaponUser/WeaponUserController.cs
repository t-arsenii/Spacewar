using UnityEngine;

public class WeaponUserController : MonoBehaviour
{
     private IEquipmentController equipmentController;
     [SerializeField] Transform shootingTransformPoint;
     [SerializeField] GameObject bulletGameObject;
     [SerializeField] GameObject rocketGameObject;
     [SerializeField] GameObject laserBeamGameObject;

     private void Start()
     {
          equipmentController = this.GetComponent<IEquipmentController>();
     }
     private void FixedUpdate()
     { 

     }

     public void Shooting()
     {
          if (equipmentController.SelectedWeapon == SelectedWeapon.DefaultWeapon)
          {
               WeaponShooting(bulletGameObject);
               return;
          }

          if (equipmentController.AdditionalWeapon == WeaponType.RocketLauncher)
          {
               WeaponShooting(rocketGameObject);
               return;
          }

          if (equipmentController.AdditionalWeapon == WeaponType.Railgun)
          {
               WeaponShooting(laserBeamGameObject);
          }
     }
     private void WeaponShooting(GameObject projectileGameObject)
     {
          if (weaponCurrentCooldown >= weaponCooldown)
          {
               if (!Input.GetKey(KeyCode.Space)) return;

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
}