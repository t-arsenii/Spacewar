using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int playerHp = 100;
    [SerializeField] float pushForce = 1f;
    [SerializeField] float rotateSpeed = 1f;
    [SerializeField] float maxSpeed = 5f;
    private Rigidbody2D rigidBody;

    [SerializeField] Transform shootingTransformPoint;
    [SerializeField] GameObject bulletGameObject;
    private void Awake()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        rigidBody.linearDamping = 0.25f;
        rigidBody.angularDamping = 0.25f;

    }
    private void Start()
    {
    }

    private void FixedUpdate()
    {
        Movement();
        Shooting();
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
    private void Shooting()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        Instantiate<GameObject>(bulletGameObject, shootingTransformPoint.position, shootingTransformPoint.rotation);
    }
}