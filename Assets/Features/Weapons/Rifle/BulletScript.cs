using Unity.Mathematics;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float travelVelocity = 2f;
    private Rigidbody2D rigidbody2D;
    void Awake()
    {
        this.rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void SetInitialVelocity(Vector2 velocity)
    {
        rigidbody2D.linearVelocity = (Vector2)(transform.up * travelVelocity) + velocity;

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
