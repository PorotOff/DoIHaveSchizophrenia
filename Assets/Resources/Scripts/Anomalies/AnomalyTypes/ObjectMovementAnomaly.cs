using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectMovementAnomaly : MonoBehaviour, IAnomaly
{
    private Rigidbody objectRigidbody;
    private ObjectMovementAnomalyConfig anomalyConfig;
    
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        objectRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    public void Initialize(ObjectMovementAnomalyConfig config)
    {
        anomalyConfig = config;
    }

    public void Occur()
    {
        objectRigidbody.constraints = RigidbodyConstraints.None;
        
        Vector3 randomDirection = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(0f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;
        
        objectRigidbody.AddForce(randomDirection * 5, ForceMode.Impulse);
    }

    public void Fix()
    {
        objectRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        objectRigidbody.linearVelocity = Vector3.zero;
        objectRigidbody.angularVelocity = Vector3.zero;

        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
