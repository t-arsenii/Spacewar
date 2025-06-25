using UnityEngine;

public class DamageableController : MonoBehaviour
{
    [SerializeField] IHealthController HealthController;
    [SerializeField] Collider2D DamageCollider2D;
    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<BulletScript>();
    }
}
