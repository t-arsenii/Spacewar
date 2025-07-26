using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
     private Rigidbody2D rigidBody;
     private IHealthController healthController;
     private IEquipmentController equipmentController;
     private float weaponCooldown = 0.75f;
     private float weaponCurrentCooldown = 0f;
     [SerializeField] Transform shootingTransformPoint;
     [SerializeField] GameObject bulletGameObject;
     [SerializeField] GameObject rocketGameObject;
     [SerializeField] GameObject laserBeamGameObject;
     private void Awake()
     {
          rigidBody = this.GetComponent<Rigidbody2D>();
          healthController = GetComponent<HealthController>();
          equipmentController = GetComponent<IEquipmentController>();
          rigidBody.linearDamping = 0.25f;
          rigidBody.angularDamping = 0.25f;

     }
     private void Start()
     {
     }

     private void Update()
     {
          Shooting();
     }
     private void FixedUpdate(){}
     
     private void Shooting()
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