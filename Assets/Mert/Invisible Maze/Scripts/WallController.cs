using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Start()
    {
        // Get the MeshRenderer component on this wall object
        meshRenderer = GetComponent<MeshRenderer>();
        
        // Initially make the wall invisible
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
        }
    }

    public void MakeVisible()
    {
        // Enable the MeshRenderer to make the wall visible
        if (meshRenderer != null)
        {
            meshRenderer.enabled = true;
        }
    }
}
