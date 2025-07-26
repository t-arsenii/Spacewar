using UnityEngine;

public class RocketProjectileController : MonoBehaviour, IProjectileController
{
    [SerializeField] private float travelVelocity = 4f;
    [SerializeField] private float damage = 5f;
    [SerializeField] private float pushForce = 100f;
    [SerializeField] private float explosionRadius = 20f;
    private Rigidbody2D Rigidbody2D;
    public void SetInitialVelocity(Vector2 velocity)
    {
        Rigidbody2D.linearVelocity = (Vector2)(transform.up * travelVelocity) + velocity;

    }
    void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        IDammagableController dammagable = collision.gameObject.GetComponent<IDammagableController>();
        if (dammagable is not null)
        {
            Explode();
        }
        if (collision.gameObject.layer != LayerMask.NameToLayer("IgnoreProjectile"))
        {
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        Vector2 explosionPosition = transform.position;

        Collider2D[] hits = Physics2D.OverlapCircleAll(explosionPosition, explosionRadius);

        foreach (var hit in hits)
        {
            var damageable = hit.GetComponent<IDammagableController>();
            if (damageable != null)
            {
                damageable.ApplyDamage(damage);
            }

            if (hit.attachedRigidbody != null)
            {
                Vector2 forceDir = (hit.transform.position - transform.position).normalized;
                hit.attachedRigidbody.AddForce(forceDir * pushForce);
            }
        }
    }
}
