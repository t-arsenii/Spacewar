using UnityEngine;
using System;
public class ObjectsCrashController : MonoBehaviour, ICrashController
{
     private IDammagableController damageableController;
     [SerializeField] private float speedOfImpact = 3f;
     [SerializeField] private float impactDamage = 5f;
     void Awake()
     {
          damageableController = GetComponent<IDammagableController>();
     }
     void OnCollisionEnter2D(Collision2D collision)
     {
          float relativeImpactSpeed = collision.relativeVelocity.magnitude;
          ICrashController crashController = collision.gameObject.GetComponent<ICrashController>();
          if (crashController is null)
          {
               return;
          }
          if (damageableController is null)
          {
               return;
          }
          if (relativeImpactSpeed >= speedOfImpact)
          {
               damageableController.ApplyDamage(impactDamage);
          }
     }
}

interface ICrashController
{

}