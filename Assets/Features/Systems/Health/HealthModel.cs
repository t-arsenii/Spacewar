using System;
using UnityEngine;

public class HealthModel
{
     const float DEFAULT_HEALTH = 100f;
     public float CurrentHealth { get; private set; } = DEFAULT_HEALTH;
     public float MaxHealth { get; private set; } = DEFAULT_HEALTH;
     private event Action OnDeath;
     public void SetMaxHealth(float healPoints)
     {
          MaxHealth = healPoints;
          CurrentHealth = MaxHealth;
     }
     public void AddOnDeathEventHandler(Action eventHandler)
     {
          OnDeath += eventHandler;
     }
     public void RemoveHp(float damage)
     {
          if (damage >= CurrentHealth)
          {
               CurrentHealth = 0f;
               OnDeath?.Invoke();
               return;
          }

          CurrentHealth -= damage;
     }
     public void AddHp(float healPoints)
     {
          if (CurrentHealth + healPoints >= MaxHealth)
          {
               CurrentHealth = MaxHealth;
               return;
          }
          CurrentHealth += healPoints;
     }
}
