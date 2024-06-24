using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class SphereController : MonoBehaviour
{
    public TextMeshProUGUI endGameText; // Assign this via the inspector

    private void OnCollisionEnter(Collision collision)
    {
        // Check for collision with a Wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            WallController wallController = collision.gameObject.GetComponent<WallController>();
            if (wallController != null)
            {
                wallController.MakeVisible();
            }
        }
        
        // Check for collision with an object tagged as "End"
        if (collision.gameObject.CompareTag("End"))
        {
            // Find all objects with EnemyController and freeze them
            EnemyController[] enemies = FindObjectsOfType<EnemyController>();
            foreach (EnemyController enemy in enemies)
            {
                Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
                if (enemyRb != null)
                {
                    enemyRb.isKinematic = true; // Make the enemy's Rigidbody kinematic
                }
            }

            // Display the end game text
            if (endGameText != null)
            {
                endGameText.text = "You've reached the end!";
                endGameText.gameObject.SetActive(true);
            }
        }
    }
}
