using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RugController : MonoBehaviour
{
    public Transform targetPosition; // Set this to the position you want to check against
    public float proximityThreshold = 6.03f; // Distance within which the player is considered "near" the target
    public GameObject winUI; // Assign your WinUI GameObject here in the Inspector

    private void Start()
    {
        // Ensure the WinUI is disabled at the start
        if (winUI != null)
        {
            winUI.SetActive(false);
        }
    }

    private void Update()
    {
        CheckPlayerProximity();
    }

    private void CheckPlayerProximity()
    {
        // Debug.Log(Vector3.Distance(transform.position, targetPosition.position));
        if (Vector3.Distance(transform.position, targetPosition.position) <= proximityThreshold)
        {
            // Debug.Log(1111);
            ActivateWinUI();
        }
    }

    private void ActivateWinUI()
    {
        if (winUI.activeSelf==false)
        {
            winUI.SetActive(true);
        }
        
    }
}
