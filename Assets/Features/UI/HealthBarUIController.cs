using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] Transform Target;

    void LateUpdate()
    {
        transform.position = Target.position;
        transform.rotation = Quaternion.identity;
    }
}
