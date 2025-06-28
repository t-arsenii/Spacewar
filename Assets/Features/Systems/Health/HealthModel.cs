using System;
using UnityEngine;

public class HealthModel
{
     const float DEFAULT_MAX_HEALTH = 100f;
     public float CurrentHealth { get; private set; } = DEFAULT_MAX_HEALTH;
     public float MaxHealth { get; private set; } = DEFAULT_MAX_HEALTH;
     private event Action OnDeath;
     private event Action<float> OnCurrentHealthChange;
     public void SetMaxHealth(float hpCount)
     {
          MaxHealth = hpCount;
          CurrentHealth = MaxHealth;
     }
     public void AddOnDeathEventHandler(Action eventHandler)
     {
          OnDeath += eventHandler;
     }
     public void AddOnHealthChangeEventHandler(Action<float> OnHealthChangeHandler)
     {
          OnCurrentHealthChange += OnHealthChangeHandler;
     }
     public void RemoveHp(float hpCount)
     {
          if (hpCount < 0)
          {
               return;
          }
          if (hpCount >= CurrentHealth)
          {
               CurrentHealth = 0f;
               OnDeath?.Invoke();
               OnCurrentHealthChange?.Invoke(CurrentHealth);
               return;
          }

          CurrentHealth -= hpCount;
          OnCurrentHealthChange?.Invoke(CurrentHealth);

     }
     public void AddHp(float hpCount)
     {
          if (hpCount < 0)
          {
               return;
          }
          if (CurrentHealth + hpCount >= MaxHealth)
          {
               CurrentHealth = MaxHealth;
               OnCurrentHealthChange?.Invoke(CurrentHealth);
               return;
          }
          CurrentHealth += hpCount;
          OnCurrentHealthChange?.Invoke(CurrentHealth);

     }
}
