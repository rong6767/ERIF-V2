using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ExitPlayModeOnUIActivation : MonoBehaviour
{
    public GameObject uiGameObject; // Assign your UI GameObject here in the Inspector
    private bool isCoroutineStarted = false;

    void Update()
    {
        // Check if the UI GameObject is active in the hierarchy and coroutine hasn't started yet
        if (uiGameObject != null && uiGameObject.activeInHierarchy && !isCoroutineStarted)
        {
            StartCoroutine(WaitAndExitPlayMode());
            isCoroutineStarted = true;
        }
    }

    private IEnumerator WaitAndExitPlayMode()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3);

        ExitPlayMode();
    }

    private void ExitPlayMode()
    {
        SceneManager.LoadScene("MainMenu");
    }
}