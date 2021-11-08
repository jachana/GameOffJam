using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float smooth_time = 0.3F;
    [SerializeField]
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    private Vector3 offset = Vector3.zero;

    void Update()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.TransformPoint(new Vector3(-3, 3, -10));

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smooth_time);
    }
}
