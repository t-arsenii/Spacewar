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
     }
}