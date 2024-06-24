using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public Restarter restarter; // Reference to the Restarter script

    private void Start()
    {
        // Ensure the button is assigned and add the listener for the click event
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClicked);
            Debug.Log("Button listener added");
        }
        else
        {
            Debug.LogWarning("Button component not found on the GameObject.");
        }

        // Ensure the Restarter script is assigned
        if (restarter == null)
        {
            Debug.LogWarning("Restarter script not assigned.");
        }
    }

    // Method to handle button click
    private void OnButtonClicked()
    {
        Debug.Log("Button clicked");
        if (restarter != null)
        {
            restarter.LoadNextPrefab();
        }
        else
        {
            Debug.LogWarning("Restarter script not assigned.");
        }
    }
}