using System;
using UnityEngine;

public class DamageableController : MonoBehaviour, IDammagableController
{
     private IHealthController HealthController;
     private event Action OnDamageTaken;
     private bool IsDead = false;
     void Awake()
     {
          HealthController = GetComponent<HealthController>();
     }
     void LateUpdate()
     {
          if (IsDead)
          {
               Destroy(gameObject);
          }
     }
     void Start()
     {
          HealthController.AddOnDeathEventHandler(() =>
          {
               IsDead = true;
          });
     }
     public void ApplyDamage(float damage)
     {
          HealthController.RemoveHealth(damage);
          OnDamageTaken?.Invoke();
     }

     public void AddOnDamageAppliedEventHandler()
     {
          throw new NotImplementedException();
     }
}
interface IDammagableController
{
     void ApplyDamage(float damage);
     void AddOnDamageAppliedEventHandler();
}