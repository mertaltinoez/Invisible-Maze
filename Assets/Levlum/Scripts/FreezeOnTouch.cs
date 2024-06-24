using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeAndStickSphereOnTouch : MonoBehaviour
{
    private Rigidbody rb;
    private bool isFrozen = false;
    private Vector3 frozenPosition;

    void Start()
    {
        // Get the Rigidbody component attached to this object.
        rb = GetComponent<Rigidbody>();

        // Ensure the Rigidbody is not null.
        if (rb == null)
        {
            Debug.LogError("No Rigidbody component found on this object.");
        }
    }

    void Update()
    {
        // If the object is frozen, keep it at the frozen position and continuously reset velocities.
        if (isFrozen)
        {
            transform.position = frozenPosition;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the other object has the tag "DeadZone"
        if (other.CompareTag("DeadZone"))
        {
            // Stop all motion.
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Make the Rigidbody kinematic to stop it from receiving any more physics updates.
            rb.isKinematic = true;

            // Record the position where the player should be frozen.
            frozenPosition = transform.position;
            isFrozen = true;
        }
    }
}
