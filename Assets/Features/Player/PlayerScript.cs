using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float pushForce = 1f;
    [SerializeField] float rotateSpeed = 1f;
    [SerializeField] float maxSpeed = 5f;
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
        EquipementSelect();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        PlayerMovenemt();
        if (rigidBody.linearVelocity.magnitude > maxSpeed)
        {
            rigidBody.linearVelocity = rigidBody.linearVelocity.normalized * maxSpeed;
        }
    }
    private void PlayerMovenemt()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, 1f * rotateSpeed);
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -1f * rotateSpeed);
            return;
        }

        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddForce(transform.up * pushForce);
            return;
        }
    }
    private void EquipementSelect()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            equipmentController.SelectWeapon(SelectedWeapon.DefaultWeapon);
            weaponCooldown = 0.75f;
            weaponCurrentCooldown = 0;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            equipmentController.SelectWeapon(SelectedWeapon.AdditionalWeapon);
            if (equipmentController.AdditionalWeapon == WeaponType.RocketLauncher)
            {
                weaponCooldown = 0.75f;
                weaponCurrentCooldown = 0;
                return;
            }

            if (equipmentController.AdditionalWeapon == WeaponType.Railgun)
            {
                weaponCooldown = 0.75f;
                weaponCurrentCooldown = 0;
                return;
            }

            return;
        }
    }
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
            bullet.GetComponent<BulletProjectileController>().SetInitialVelocity(rigidBody.linearVelocity);

            return;
        }

        if (weaponCurrentCooldown >= weaponCooldown)
        {
            weaponCurrentCooldown = 0;
            return;
        }

        weaponCurrentCooldown += Time.deltaTime;
    }
}