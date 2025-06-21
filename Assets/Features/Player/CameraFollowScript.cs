    using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offest = new Vector3(0f, 0f, -10f);
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.025f;
    [SerializeField] private Transform target;
    void LateUpdate()
    {
        Vector3 targetPosition = target.position + offest;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        Debug.Log(smoothTime);
    }
}
