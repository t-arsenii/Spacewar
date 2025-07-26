using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
     private Rigidbody2D rigidBody;
     private IEquipmentController equipmentController;
     [SerializeField] private float maxSpeed = 5f;

     [SerializeField] private float rotateSpeed = 1f;
     [SerializeField] private float pushForce = 1f;

     void Awake()
     {
          rigidBody = this.GetComponent<Rigidbody2D>();
          equipmentController = this.GetComponent<IEquipmentController>();
     }

     void Start()
     {

     }
     void Update()
     {
          EquipementSelect();
     }
     void FixedUpdate()
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
          if (Input.GetKey(KeyCode.S))
          {
               rigidBody.linearVelocity = Vector2.Lerp(rigidBody.linearVelocity, Vector2.zero, 0.1f);
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
}
