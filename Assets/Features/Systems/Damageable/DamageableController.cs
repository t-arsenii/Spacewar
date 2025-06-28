using System;
using UnityEngine;

public class DamageableController : MonoBehaviour, IDammagableController
{
    private IHealthController HealthController;
    [SerializeField] HealthController healthController;
    private event Action OnDamageTaken;
    void Awake()
    {
        HealthController = GetComponent<HealthController>();
    }
    void Start()
    {
        HealthController.AddOnDeathEventHandler(() =>
        {
            Destroy(gameObject);
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