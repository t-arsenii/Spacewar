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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D.linearVelocity = (Vector2)(transform.up * travelVelocity);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Bullet");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
    }
}
