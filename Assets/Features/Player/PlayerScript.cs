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
    private const float rifleCooldown = 0.75f;
    private float rifleCurrentCooldown = 0f;
    private bool rifleOnCooldown = false;
    private bool rocketLauncherOnCooldown = false;
    private const float rocketLauncherCooldown = 0.75f;
    private float rocketLauncherCurrentCooldown = 0f;
    [SerializeField] Transform shootingTransformPoint;
    [SerializeField] GameObject bulletGameObject;
    [SerializeField] GameObject rocketGameObject;
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
        TestHealth();
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
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            equipmentController.SelectWeapon(SelectedWeapon.AdditionalWeapon);
            return;
        }
    }
    private void Shooting()
    {
        if (equipmentController.SelectedWeapon == SelectedWeapon.DefaultWeapon)
        {
            RifleShooting();
            return;
        }

        if (equipmentController.AdditionalWeapon == WeaponType.RocketLauncher)
        {
            RocketLauncherShooting();
            return;
        }
    }
    private void RifleShooting()
    {
        if (!rifleOnCooldown)
        {
            if (!Input.GetKey(KeyCode.Space)) return;

            var bullet = Instantiate<GameObject>(bulletGameObject, shootingTransformPoint.position, shootingTransformPoint.rotation);
            bullet.GetComponent<BulletController>().SetInitialVelocity(rigidBody.linearVelocity);

            rifleOnCooldown = true;
            return;
        }

        if (rifleCurrentCooldown >= rifleCooldown)
        {
            rifleOnCooldown = false;
            rifleCurrentCooldown = 0;
            return;
        }

        rifleCurrentCooldown += Time.deltaTime;
    }
    private void RocketLauncherShooting()
    {
        if (!rocketLauncherOnCooldown)
        {
            if (!Input.GetKey(KeyCode.Space)) return;

            var rocket = Instantiate<GameObject>(rocketGameObject, shootingTransformPoint.position, shootingTransformPoint.rotation);
            rocket.GetComponent<RocketController>().SetInitialVelocity(rigidBody.linearVelocity);

            rocketLauncherOnCooldown = true;
            return;
        }

        if (rocketLauncherCurrentCooldown >= rocketLauncherCooldown)
        {
            rocketLauncherOnCooldown = false;
            rocketLauncherCurrentCooldown = 0;
            return;
        }

        rocketLauncherCurrentCooldown += Time.deltaTime;
    }
    private void TestHealth()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            healthController.RemoveHealth(5);
        }
    }

}