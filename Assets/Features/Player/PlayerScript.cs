using Unity.VisualScripting;
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
    private void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        rigidBody.linearDamping = 0.25f;
        rigidBody.angularDamping = 0.25f;
        // Debug.Log("Spaceship is flying through space!");        
    }

    // Update is called once per frame
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
            Debug.Log("Spaceship turning left!");
            transform.Rotate(0f, 0f, 1f * rotateSpeed);
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Spaceship turning right!");
            transform.Rotate(0f, 0f, -1f * rotateSpeed);
            return;
        }

        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddForce(transform.up * pushForce);
            return;
        }
    }
}