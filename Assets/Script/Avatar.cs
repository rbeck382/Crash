using UnityEngine;

public class Avatar : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform floatingChild;
    [SerializeField]
    private Vector3 followOffset;
    [SerializeField]
    private float followSpeed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float stopDistance = 0.5f;
    [SerializeField]
    private float floatAmplitude = 0.15f;
    [SerializeField]
    private float floatFrequency = 1.5f;
    private float initialY;
    private void Awake()
    {
        if (target == null) return;
        initialY = floatingChild.position.y;
    }
    private void LateUpdate()
    {
        if (target == null) return;
        Vector3 targetPosition = target.TransformPoint(followOffset);
        float distance = Vector3.Distance(transform.position, targetPosition);
        if(distance > stopDistance)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition,
            followSpeed * Time.deltaTime);
        }
        UpdateRotation();
        UpdateFloating();
    }
    private void UpdateRotation()
    {
        Quaternion targetRotation = Quaternion.LookRotation(target.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
            rotationSpeed * Time.deltaTime);
    }
    private void UpdateFloating()
    {
        float floatOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        float targetY = floatOffset + initialY;
        Vector3 position = floatingChild.position;
        position.y = targetY;
        floatingChild.position = position;
    }
}
