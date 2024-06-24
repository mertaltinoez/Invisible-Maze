using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject gameEndingUI; // Assign your game ending UI canvas or panel here

    void OnTriggerEnter(Collider other)
    {
        // Check if the object we collided with has the tag "jumpy"
        if (other.CompareTag("jumpy"))
        {
            // Trigger the game-ending UI
            TriggerGameEndingUI();
        }
    }

    private void TriggerGameEndingUI()
    {
        if (gameEndingUI != null)
        {
            gameEndingUI.SetActive(true); // Activates the game ending UI
            // Optionally, you can pause the game or add other game ending logic here
            //Time.timeScale = 0f; // Pauses the game
        }
        else
        {
            Debug.LogWarning("Game ending UI not assigned.");
        }
    }
}