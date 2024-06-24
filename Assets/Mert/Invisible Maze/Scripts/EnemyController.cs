using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Restarter restarter; // Reference to the Restarter script

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        // Check if the object we collided with has the tag "jumpy"
        if (collision.gameObject.CompareTag("jumpy"))
        {
            Debug.Log("Collided with a jumpy object");
            // Restart the scene with the same prefab
            if (restarter != null)
            {
                restarter.ReloadSamePrefab();
            }
            else
            {
                Debug.LogWarning("Restarter script not assigned.");
            }
        }
    }
}