using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    public List<GameObject> prefabs; // List to hold the prefabs
    private int currentPrefabIndex = 0; // Index to track the current prefab

    void Start()
    {
        // Load the current prefab index from PlayerPrefs
        currentPrefabIndex = PlayerPrefs.GetInt("CurrentPrefabIndex", 0);
        Debug.Log("Loaded CurrentPrefabIndex: " + currentPrefabIndex);

        // Check the restart reason
        string restartReason = PlayerPrefs.GetString("RestartReason", "Normal");
        Debug.Log("RestartReason: " + restartReason);

        if (restartReason == "Normal")
        {
            // Load the first prefab
            currentPrefabIndex = 0;
            PlayerPrefs.SetInt("CurrentPrefabIndex", currentPrefabIndex);
            PlayerPrefs.Save();
            Debug.Log("Set CurrentPrefabIndex to 0 for normal start");
        }

        // Load the current prefab
        LoadCurrentPrefab();

        // Clear the restart reason for next normal start
        PlayerPrefs.SetString("RestartReason", "Normal");
        PlayerPrefs.Save();
    }

    public void LoadNextPrefab()
    {
        // Increment the prefab index and wrap around if necessary
        currentPrefabIndex = (currentPrefabIndex + 1) % prefabs.Count;
        Debug.Log("Next Prefab Index: " + currentPrefabIndex);

        // Save the new prefab index to PlayerPrefs
        PlayerPrefs.SetInt("CurrentPrefabIndex", currentPrefabIndex);
        PlayerPrefs.SetString("RestartReason", "Button");
        PlayerPrefs.Save();

        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void LoadCurrentPrefab()
    {
        if (prefabs.Count > 0)
        {
            // Instantiate the current prefab
            GameObject instance = Instantiate(prefabs[currentPrefabIndex]);
            Debug.Log("Instantiated prefab: " + instance.name);
        }
        else
        {
            Debug.LogWarning("No prefabs assigned to the list.");
        }
    }

    public void ReloadSamePrefab()
    {
        // Save the current prefab index to PlayerPrefs
        PlayerPrefs.SetInt("CurrentPrefabIndex", currentPrefabIndex);
        PlayerPrefs.SetString("RestartReason", "Enemy");
        PlayerPrefs.Save();

        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}