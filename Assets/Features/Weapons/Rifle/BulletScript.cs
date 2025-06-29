using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour, IBulletController
{
    [SerializeField] private float travelVelocity = 2f;
    [SerializeField] private float damage = 5f;
    [SerializeField] private float pushForce = 100f;
    private Rigidbody2D Rigidbody2D;
    void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void SetInitialVelocity(Vector2 velocity)
    {
        Rigidbody2D.linearVelocity = (Vector2)(transform.up * travelVelocity) + velocity;

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        IDammagableController dammagable = collision.gameObject.GetComponent<IDammagableController>();
        IBulletController bulletController = collision.gameObject.GetComponent<IBulletController>();
        if (dammagable is not null)
        {
            dammagable.ApplyDamage(damage);
            if (collision.attachedRigidbody != null)
            {
                collision.attachedRigidbody.AddForce(Rigidbody2D.linearVelocity.normalized * pushForce);
            }
        }
        if (collision.gameObject.layer != LayerMask.NameToLayer("IgnoreProjectile"))
        {
            Destroy(gameObject);
        }
    }
}

interface IBulletController
{

}