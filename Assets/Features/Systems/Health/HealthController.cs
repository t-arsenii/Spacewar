using UnityEngine;

public class HealthController : MonoBehaviour, IHealthController
{
    private HealthModel Health;
    [SerializeField] float maxHealth;

     public float CurrentHealth => Health.CurrentHealth;

     public void ApplyDamage(float damage)
    {
        Health.RemoveHp(damage);
    }

    public float GetCurrentHealth()
    {
        return Health.CurrentHealth;
    }

    void Start()
    {
        Health = new();
        Health.SetMaxHealth(maxHealth);
    }
}
public interface IHealthController
{
    void ApplyDamage(float damage);
    float CurrentHealth { get; }
}