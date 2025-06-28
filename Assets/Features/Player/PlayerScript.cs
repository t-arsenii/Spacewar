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
    private const float rifleCooldown = 0.75f;
    private float rifleCurrentCooldown = 0f;
    private bool rifleOnCooldown = false;

    [SerializeField] Transform shootingTransformPoint;
    [SerializeField] GameObject bulletGameObject;
    private void Awake()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        healthController = GetComponent<HealthController>();

        rigidBody.linearDamping = 0.25f;
        rigidBody.angularDamping = 0.25f;

    }
    private void Start()
    {
    }

    private void Update()
    {
        RifleShooting();
        TestHealth();
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
    private void TestHealth()   
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            healthController.RemoveHealth(5);
        }
    }

}