using System;
using UnityEngine;

public class HealthController : MonoBehaviour, IHealthController
{
    private HealthModel Health;
    [SerializeField] float maxHealth;

    public float CurrentHealth => Health.CurrentHealth;

    public void RemoveHealth(float damage)
    {
        Health.RemoveHp(damage);
    }

    public float GetCurrentHealth()
    {
        return Health.CurrentHealth;
    }

    void Awake()
    {
        Health = new();
        Health.SetMaxHealth(maxHealth);
    }

    public void AddOnHealthChangeEventHandler(Action<float> OnHelahtChangeEventHandler)
    {
        Health.AddOnHealthChangeEventHandler(OnHelahtChangeEventHandler);
    }

    public void AddOnDeathEventHandler(Action OnDeathentHandler)
    {
        Health.AddOnDeathEventHandler(OnDeathentHandler);
    }
}
public interface IHealthController
{
    void RemoveHealth(float damage);
    float CurrentHealth { get; }
    public void AddOnHealthChangeEventHandler(Action<float> OnHelahtChangeEventHandler);
    public void AddOnDeathEventHandler(Action OnDeathentHandler);
}