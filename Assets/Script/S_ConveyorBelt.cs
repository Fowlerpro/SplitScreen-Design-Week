using NUnit.Framework;
using UnityEngine;

public class S_ConveyorBelt : MonoBehaviour
{
    [Header("Do Physics Movement?")]
    [SerializeField]
    bool doPhysicsMovement;

    [Header("Teleporting Settings")]
    [SerializeField]
    Transform pointToTeleportTo;

    [Header("Physics movement settings")]
    [SerializeField]
    float forceX = 10;
    [SerializeField]
    float forceZ = 0;

    private void OnTriggerStay(Collider other)
    {
        //Physics movement behaviors
        if (!other.gameObject.CompareTag("Player") && other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rB) && doPhysicsMovement)
        {
            Vector3 force = new Vector3(forceX, 0, forceZ);

            rB.AddForce(force, ForceMode.Force);
        }
        //Teleporting behaviors
        else if (!other.gameObject.CompareTag("Player") && !doPhysicsMovement)
        {
            other.transform.position = pointToTeleportTo.position;
        }
    }
}
