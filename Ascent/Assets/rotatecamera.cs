using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float rotationSpeed = 0.1f;

    private Transform currentTarget;

    void Start()
    {
        // Start by setting the initial target
        currentTarget = pointA;
    }

    void Update()
    {
        // Rotate the camera towards the current target
        RotateTowardsTarget(currentTarget);
    }

    void RotateTowardsTarget(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly rotate towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * 0.01f);

        // Check if camera is facing the target approximately
        if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
        {
            // If camera is almost facing the target, switch to the other target
            currentTarget = (currentTarget == pointA) ? pointB : pointA;
        }
    }
}
